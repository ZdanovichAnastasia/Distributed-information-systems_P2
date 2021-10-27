using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace lab2
{
    class FileService
    {
        private string path = @"../../../../veg.txt";
        private delegate void Message();
        private Message message;
        public List<Veg> readFile()
        {
            List<Veg> objects = new List<Veg>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    string[] items = line.Split('|');
                    objects.Add(new Veg(Int32.Parse(items[0]), items[1], float.Parse(items[2]), Int32.Parse(items[3])));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error! {e.Message}");
                message = Fail;
                message();
            }
            return objects;
        }

        public void writeFile(Veg veg)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.Seek(0, SeekOrigin.End);
                StreamWriter w = new StreamWriter(fs, Encoding.Default);
                w.WriteLine($"{veg.Id}|{veg.Name}|{veg.Price}|{veg.Quantity}");
                w.Close();
                fs.Close();
                message = Success;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error! {e.Message}");
                message = Fail;
            }
            finally
            {
                message();
            }
        }

        public void rewriteFile(List<Veg> objects)
        {
            try
            {
                StreamWriter w = new StreamWriter(path, false);
                foreach (var veg in objects)
                {
                    w.WriteLine($"{veg.Id}|{veg.Name}|{veg.Price}|{veg.Quantity}");
                }
                w.Close();
                message = Success;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error! {e.Message}");
                message = Fail;
            }
            finally
            {
                message();
            }
        }

        private void Success()
        {
            Console.WriteLine("\n\tSuccess!\n");
        }

        private void Fail()
        {
            Console.WriteLine("\n\tFailed!\n");
        }
    }
}
