using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace server
{
    class FileService
    {
        private string path = @"../../../veg.txt";
        public string readFile()
        {
            string data = null;
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader w = new StreamReader(fs, Encoding.Default);
                data = w.ReadToEnd();
                w.Close();
                fs.Close();
            }
            catch (Exception e) { }
            return data;
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
            }
            catch (Exception e) { }
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
            }
            catch (Exception e) { }
        }

    }
}
