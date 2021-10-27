using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace client
{
    public class Controller
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private BinaryFormatter formatter;

        public Controller()
        {
            //tcpClient = new TcpClient("localhost", 5555);
            //stream = tcpClient.GetStream();
            //formatter = new BinaryFormatter();
        }

        public bool tryConnection()
        {
            try
            {
                tcpClient = new TcpClient("localhost", 5555);
                stream = tcpClient.GetStream();
                formatter = new BinaryFormatter();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<Veg> getAllVegs()
        {
            String str = "read";
            formatter.Serialize(stream, str);

            String text = (String)formatter.Deserialize(stream);
            return getList(text);
        }

        public void create(String data)
        {
            String str = "create";
            formatter.Serialize(stream, str);

            formatter.Serialize(stream, data);
        }
        public void update(String data)
        {
            String str = "update";
            formatter.Serialize(stream, str);

            formatter.Serialize(stream, data);
        }

        public List<Veg> searchByName(string name)
        {
            String str = "searchByName";
            formatter.Serialize(stream, str);

            formatter.Serialize(stream, name);
            String text = (String)formatter.Deserialize(stream);

            return getList(text);
        }

        public List<Veg> delete(int id)
        {
            String str = "delete";
            formatter.Serialize(stream, str);

            formatter.Serialize(stream, id);
            String text = (String)formatter.Deserialize(stream);
            return getList(text);
        }

        public List<Veg> searchById(int id)
        {
            String str = "searchById";
            formatter.Serialize(stream, str);

            formatter.Serialize(stream, id);
            String text = (String)formatter.Deserialize(stream);
            
            return getList(text);
        }

        private List<Veg> getList(string text)
        {
            List<Veg> objects = null;
            if (text != "")
            {
                string[] lines = text.Split('\n');
                if (lines.Length > 0)
                {
                    objects = new List<Veg>();
                    Array.Resize(ref lines, lines.Length - 1);

                    foreach (var line in lines)
                    {
                        string[] items = line.Split('|');
                        objects.Add(new Veg(Int32.Parse(items[0]), items[1], float.Parse(items[2]), Int32.Parse(items[3])));
                    }
                }
            }
            return objects;
        }
    }
}
