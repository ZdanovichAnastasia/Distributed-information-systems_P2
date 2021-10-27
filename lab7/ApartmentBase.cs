using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab7
{
    internal class ApartmentBase
    {
        protected string adsElement = "ads";
        protected string adElement = "ad";
        protected string idElement = "id";
        protected string regionElement = "region";
        protected string streetElement = "street";
        protected string houseElement = "house";
        protected string roomCountElement = "roomCount";
        protected string priceElement = "price";
        protected string nameElement = "name";
        protected string phoneElement = "phone";
        protected string watchCountElement = "watchCount";

        private string projectPath = @"../../";

        internal List<Ad> FromXmlToList(string filename)
        {
            try
            {
                var filePath = projectPath + filename;
                XDocument xdoc = XDocument.Load(filePath);
                var items = from xe in xdoc.Element(adsElement).Elements(adElement)
                            select new Ad
                            {
                                Id = int.Parse(xe.Element(idElement).Value),
                                Region = xe.Element(regionElement).Value,
                                Street = xe.Element(streetElement).Value,
                                House = int.Parse(xe.Element(houseElement).Value),
                                RoomCount = int.Parse(xe.Element(roomCountElement).Value),
                                Price = int.Parse(xe.Element(priceElement).Value),
                                Name = xe.Element(nameElement).Value,
                                Phone = int.Parse(xe.Element(phoneElement).Value),
                                WatchCount = int.Parse(xe.Element(watchCountElement).Value)
                            };
                return items.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return null;
            }
        }

        internal bool FromListToXml(List<Ad> ads, string filename)
        {
            try
            {
                var filePath = projectPath + filename;
                XDocument xdoc = XDocument.Load(filePath);
                XElement root = xdoc.Element(adsElement);

                foreach (var ad in ads)
                {
                    var flag = 0;
                    foreach (XElement xe in root.Elements(adElement).ToList())
                    {
                        if (ad.Id == int.Parse(xe.Element(idElement).Value))
                        {
                            flag++;

                            xe.Element(regionElement).Value = ad.Region;
                            xe.Element(streetElement).Value = ad.Street;
                            xe.Element(houseElement).Value = ad.House.ToString();
                            xe.Element(roomCountElement).Value = ad.RoomCount.ToString();
                            xe.Element(priceElement).Value = ad.Price.ToString();
                            xe.Element(nameElement).Value = ad.Name;
                            xe.Element(phoneElement).Value = ad.Phone.ToString();
                            xe.Element(watchCountElement).Value = ad.WatchCount.ToString();
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        var xe = new XElement(adElement);
                        xe.Add(
                                new XElement(idElement, ad.Id),
                                new XElement(regionElement, ad.Region),
                                new XElement(streetElement, ad.Street),
                                new XElement(houseElement, ad.House),
                                new XElement(roomCountElement, ad.RoomCount),
                                new XElement(priceElement, ad.Price),
                                new XElement(nameElement, ad.Name),
                                new XElement(phoneElement, ad.Phone),
                                new XElement(watchCountElement, ad.WatchCount)
                            );
                        root.Add(xe);
                    }
                }
                xdoc.Save(filePath);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return false;
            }
        }

        internal bool WriteRoomInfoInFile(string filename, Ad ad)
        {
            try
            {
                string filepath = projectPath + filename + ".txt";
                string roomFile="Region: " + ad.Region + "\n" +
                        "Street: " + ad.Street + "\n" +
                        "House number: " + ad.House + "\n" +
                        "Count of room: " + ad.RoomCount + "\n" +
                        "Price: " + ad.Price + "\n" +
                        "Owner name: " + ad.Name + "\n" +
                        "Phone: " + ad.Phone;
               using (StreamWriter writer = new StreamWriter(filepath))
                {
                    writer.WriteLine(roomFile);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return false;
            }
        }

        protected virtual bool TryFindIfAdsElementExist(string param)
        {
            try
            {
                if (adsElement == param)
                    return true;
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return false;
            }
        }
    }
}
