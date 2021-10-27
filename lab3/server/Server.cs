using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace server
{
    class Server
    {
        public TcpClient client;
        private BinaryFormatter formatter;
        private NetworkStream stream;
        public Server(TcpClient tcpClient)
        {
            client = tcpClient;
            formatter = new BinaryFormatter();
        }

        public void Process()
        {
            //NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] received = new byte[64];
                while (true)
                {
                    String cmd = (String)formatter.Deserialize(stream);
                    switch (cmd)
                    {
                        case "create":
                            {
                                create(stream);
                            }
                            break;
                        case "read":
                            {
                                FileService service = new FileService();
                                string data = service.readFile();
                                formatter.Serialize(stream, data);
                            }
                            break;
                        case "update":
                            {
                                update(stream);
                            }
                            break;
                        case "delete":
                            {
                                delete(stream);
                            }
                            break;
                        case "searchByName":
                            {
                                searchByName(stream);
                            }
                            break;
                        case "searchById":
                            {
                                searchById(stream);
                            }
                            break;
                        case "sort":
                            break;
                        default: break;
                    }

                }
            }
            catch(Exception e)
            {

            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }

        private void create(NetworkStream stream)
        {
            String data = (String)formatter.Deserialize(stream);
            string[] obj = data.Split('|');
            Veg veg = new Veg(1, obj[0], float.Parse(obj[1]), Int32.Parse(obj[2]));
            FileService service = new FileService();
            try
            {
                string text = service.readFile();
                List<Veg> objects = getList(text);
                if (objects.Count > 0)
                {
                    objects.Sort((o1, o2) => o1.Id.CompareTo(o2.Id));
                    veg.Id = objects.Last().Id + 1;
                }
            }
            catch (Exception e)
            {

            }
            service.writeFile(veg);
        }

        private void update(NetworkStream stream)
        {
            String data = (String)formatter.Deserialize(stream);
            string[] obj = data.Split('|');
            Veg veg = new Veg(Int32.Parse(obj[0]), obj[1], float.Parse(obj[2]), Int32.Parse(obj[3]));
            FileService service = new FileService();
            List<Veg> objects = getList(service.readFile());
            List<Veg> newObjects = new List<Veg>();
            foreach (var o in objects)
            {
                if (o.Id == veg.Id)
                {
                    newObjects.Add(veg);
                }
                else
                {
                    newObjects.Add(o);
                }
            }
            service.rewriteFile(newObjects);
        }


        private void searchByName(NetworkStream stream)
        {
            FileService service = new FileService();
            String name = (String)formatter.Deserialize(stream);
            List<Veg> objects = getList(service.readFile());
            string result = "";
            if (objects.Count > 1)
            {
                foreach (var obj in objects)
                {
                    if (obj.Name.Equals(name))
                    {
                        result = $"{obj.Id}|{obj.Name}|{obj.Price}|{obj.Quantity}\n";
                    }
                }

            }
            formatter.Serialize(stream, result);
        }

        

        private void searchById(NetworkStream stream)
        {
            FileService service = new FileService();
            Int32 id = (Int32)formatter.Deserialize(stream);
            List<Veg> objects = getList(service.readFile());
            string result = "";
            if (objects.Count > 1)
            {
                foreach (var obj in objects)
                {
                    if (obj.Id.Equals(id))
                    {
                        result = $"{obj.Id}|{obj.Name}|{obj.Price}|{obj.Quantity}\n";
                        break;
                    }
                }
            }
            formatter.Serialize(stream, result);
        }

        private void delete(NetworkStream stream)
        {
            FileService service = new FileService();
            Int32 id = (Int32)formatter.Deserialize(stream);
            List<Veg> objects = getList(service.readFile());
            string result = "";
            if (objects.Exists(o => o.Id == id))
            {
                List<Veg> newObjects = new List<Veg>();
                foreach (var obj in objects)
                {
                    if (obj.Id != id)
                    {
                        newObjects.Add(obj);
                    }
                }
                service.rewriteFile(newObjects);
                result = service.readFile();
            }
            formatter.Serialize(stream, result);
        }

        private List<Veg> getList(string text)
        {
            if (text != null)
            {
                string[] lines = text.Split('\n');
                List<Veg> objects = null;
                if (lines.Length > 1)
                {
                    objects = new List<Veg>();
                    Array.Resize(ref lines, lines.Length - 1);

                    foreach (var line in lines)
                    {
                        string[] items = line.Split('|');
                        objects.Add(new Veg(Int32.Parse(items[0]), items[1], float.Parse(items[2]), Int32.Parse(items[3])));
                    }
                }
                return objects;
            }
            return null;
        }
    }
}
