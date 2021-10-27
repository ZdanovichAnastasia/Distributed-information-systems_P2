using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    internal class MainMenu
    {
        private int choice = 0;
        private List<string> regions = new List<string>();
        private List<Ad> ads = new List<Ad>();
        private Apartment apartment = new Apartment();

        private string xmlFileName = "apartments.xml";

        private delegate void Message();
        private Message message;

        internal MainMenu()
        {
            try
            {
                ads = apartment.FromXmlToList(xmlFileName);
                foreach (var ad in ads)
                {
                    if (!regions.Contains(ad.Region))
                        regions.Add(ad.Region);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error! {e.Message}");
            }
        }

        public void ShowMenu()
        {
            choice = 0;
            Console.WriteLine("\tMain menu");
            Console.WriteLine("1. Show apartments ads.");
            Console.WriteLine("2. Add new aparnment ad.");
            Console.WriteLine("3. Find apartment.");
            Console.WriteLine("0. Exit.");
            Console.WriteLine("Please choose menu variant:");
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 3)
            {
                Console.WriteLine("Error! Write number from 0 to 3.");
            }
            switch (choice)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    ShowApartmentAds();
                    break;
                case 2:
                    AddNewApartment();
                    break;
                case 3:
                    FindApartment();
                    break;
            }
        }

        private void ShowApartmentAds()
        {
            try
            {
                ShowRegionTable(regions);

                choice = 0;
                Console.WriteLine("Please choose region from table below and enter it's number or enter 0 to exit:");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > regions.Count)
                {
                    Console.WriteLine($"Error! Write number from 0 to {regions.Count}.");
                }
                if (choice == 0) ShowMenu();
                else WorkWithAds();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error! {e.Message}");
            }
        }

        private void AddNewApartment()
        {
            try
            {
                Console.WriteLine("\n\n\tAdding new apartment\n");

                ShowRegionTable(regions);
                string street, name;
                int price = 0, id = 1, house = 0, roomCount = 0, phone = 0;
                choice = 0;
                Console.WriteLine("Please choose region from table below and enter it's number:");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > regions.Count)
                {
                    Console.WriteLine($"Error! Write number from 1 to {regions.Count}.");
                }

                Console.WriteLine("\nPlease eneter street:");
                while (string.IsNullOrEmpty(street = Console.ReadLine()))
                {
                    Console.WriteLine("Error! Write street.");
                }
                Console.WriteLine("\nPlease enter number of house:");
                while (!int.TryParse(Console.ReadLine(), out house) || house < 1 || house > 10000000)
                {
                    Console.WriteLine($"Error! Write number from 1 to 10000000.");
                }
                Console.WriteLine("\nPlease enter count of room:");
                while (!int.TryParse(Console.ReadLine(), out roomCount) || roomCount < 1 || roomCount > 6)
                {
                    Console.WriteLine($"Error! Write number from 1 to 6.");
                }
                Console.WriteLine("\nPlease enter price:");
                while (!int.TryParse(Console.ReadLine(), out price) || price < 0 || price > 10000000)
                {
                    Console.WriteLine($"Error! Write number from 0 to 10000000.");
                }
                Console.WriteLine("\nPlease eneter name of owner:");
                while (string.IsNullOrEmpty(name = Console.ReadLine()))
                {
                    Console.WriteLine("Error! Write name of owner.");
                }
                Console.WriteLine("\nPlease enter phone number:");
                while (!int.TryParse(Console.ReadLine(), out phone) || phone < 1000000 || price > 9999999)
                {
                    Console.WriteLine($"Error! Write number, that consists of 7 digits.");
                }

                for (int i = 0; i < ads.Count; i++)
                {
                    if (ads.FirstOrDefault(a => a.Id == id) != null)
                        id++;
                }

                ads.Add(new Ad()
                {
                    Id = id,
                    Region = regions[choice - 1],
                    Street = street,
                    House = house,
                    RoomCount = roomCount,
                    Price = price,
                    Name = name,
                    Phone = phone,
                    WatchCount = 0
                });

                if (apartment.FromListToXml(ads, xmlFileName))
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
                ShowMenu();
            }
        }

        private void FindApartment()
        {
            Console.WriteLine("\n\n\tSearching apartment\n");
            ShowRegionTableForSearching();

            choice = 0;
            Console.WriteLine("Please choose region from table below and enter it's number:");
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > regions.Count + 1)
            {
                Console.WriteLine($"Error! Write number from 1 to {regions.Count + 1}.");
            }

            int maxPrice = 0;
            if (choice > regions.Count)
            {
                Console.WriteLine($"You choose all regions. Please enter max price:");
                while (!int.TryParse(Console.ReadLine(), out maxPrice) || maxPrice < 0 || maxPrice > 10000000)
                {
                    Console.WriteLine($"Error! Write number from 1 to 10000000.");
                }
                WorkWithMaxPriceAll(maxPrice);
            }
            else
            {
                Console.WriteLine($"You choose {regions[choice - 1]} region. Please enter max price:");
                while (!int.TryParse(Console.ReadLine(), out maxPrice) || maxPrice < 0 || maxPrice > 10000000)
                {
                    Console.WriteLine($"Error! Write number from 1 to 10000000.");
                }

                WorkWithMaxPricePartial(maxPrice);
            }

        }
  
        private void WorkWithMaxPriceAll(int maxPrice)
        {
            var selectedAds = new List<Ad>();
            int number = 0;
            Console.WriteLine("________________________________________________________________");
            Console.WriteLine("| № |    Region    |       Address      | Room | Price | Views |");
            Console.WriteLine("________________________________________________________________");
            foreach (var ad in ads)
            {
                if (ad.Price < maxPrice)
                {
                    number++;
                    Console.WriteLine($"|{number,3}|{ad.Region,14}|{ad.Street,14},{ad.House,5}|{ad.RoomCount,6}|{ad.Price,7}|{ad.WatchCount,7}|");
                    Console.WriteLine("________________________________________________________________");
                    selectedAds.Add(ad);
                }
            }
            Console.WriteLine("\n\n\n");

            choice = 0;
            Console.WriteLine("Please choose apartment ad number to read more info about apartment or enter 0 to exit:");
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > number)
            {
                Console.WriteLine($"Error! Write number from 0 to {number}.");
            }

            if (choice == 0) ShowMenu();
            else ShowApartmentInfo(ads.IndexOf(selectedAds[choice - 1]));
        }

        private void WorkWithMaxPricePartial(int maxPrice)
        {
            var selectedAds = new List<Ad>();
            int number = 0;
            Console.WriteLine("________________________________________________________________");
            Console.WriteLine("| № |    Region    |       Address      | Room | Price | Views |");
            Console.WriteLine("________________________________________________________________");
            foreach (var ad in ads)
            {
                if (ad.Price < maxPrice && ad.Region == regions[choice - 1])
                {
                    number++;
                    Console.WriteLine($"|{number,3}|{ad.Region,14}|{ad.Street,14},{ad.House,5}|{ad.RoomCount,6}|{ad.Price,7}|{ad.WatchCount,7}|");
                    Console.WriteLine("________________________________________________________________");
                    selectedAds.Add(ad);
                }
            }
            Console.WriteLine("\n\n\n");

            choice = 0;
            Console.WriteLine("Please choose apartment ad number to read more info about apartment or enter 0 to exit:");
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > number)
            {
                Console.WriteLine($"Error! Write number from 0 to {number}.");
            }

            if (choice == 0) ShowMenu();
            else ShowApartmentInfo(ads.IndexOf(selectedAds[choice - 1]));
        }

        private void WorkWithAds()
        {
            List<Ad> thisRegionAds = new List<Ad>();
            int number = 0;
            Console.WriteLine("________________________________________________________________");
            Console.WriteLine("| № |    Region    |       Address      | Room | Price | Views |");
            Console.WriteLine("________________________________________________________________");
            foreach (var ad in ads)
            {
                if (ad.Region == regions[choice - 1])
                {
                    number++;
                    Console.WriteLine($"|{number,3}|{ad.Region,14}|{ad.Street,14},{ad.House,5}|{ad.RoomCount,6}|{ad.Price,7}|{ad.WatchCount,7}|");
                    Console.WriteLine("________________________________________________________________");
                    thisRegionAds.Add(ad);
                }
            }
            Console.WriteLine("\n\n\n");

            choice = 0;
            Console.WriteLine("Please choose apartment ad number to read more info about apartment or enter 0 to exit:");
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > number)
            {
                Console.WriteLine($"Error! Write number from 0 to {number}.");
            }

            if (choice == 0) ShowMenu();
            else ShowApartmentInfo(ads.IndexOf(thisRegionAds[choice - 1]));
        }
       
        private void ShowRegionTable(List<string> regions)
        {
            int number = 0;
            Console.WriteLine("____________________");
            Console.WriteLine("| № |    Region    |");
            Console.WriteLine("____________________");
            foreach (var region in regions)
            {
                number++;
                Console.WriteLine($"|{number,3}|{region,14}|");
                Console.WriteLine("____________________");
            }
            Console.WriteLine("\n\n");
        }

        private void ShowRegionTableForSearching()
        {
            int number = 0;
            Console.WriteLine("____________________");
            Console.WriteLine("| № |    Region    |");

            Console.WriteLine("____________________");
            foreach (var region in regions)
            {
                number++;
                Console.WriteLine($"|{number,3}|{region,14}|");
                Console.WriteLine("____________________");
            }
            Console.WriteLine($"|{number + 1,3}|           All|");
            Console.WriteLine("____________________");
            Console.WriteLine("\n\n");
        }

        private void ShowApartmentInfo(int index)
        {
            ads[index].WatchCount++;

            Console.WriteLine("Region: " + ads[index].Region);
            Console.WriteLine("Street: " + ads[index].Street);
            Console.WriteLine("House number: " + ads[index].House);
            Console.WriteLine("Count of room: " + ads[index].RoomCount);
            Console.WriteLine("Price: " + ads[index].Price);
            Console.WriteLine("Owner name: " + ads[index].Name);
            Console.WriteLine("Phone: " + ads[index].Phone);
            Console.WriteLine("WatchCount" + ads[index].WatchCount);
            Console.WriteLine("\n\n\n");

            if (apartment.FromListToXml(ads, xmlFileName))
                message = Success;
            else message = Fail;
            message();

            Console.WriteLine("Do you want to save info in text file?");
            choice = 0;
            Console.WriteLine("1. Yes.");
            Console.WriteLine("2. No.");
            Console.WriteLine("Please choose menu variant:");
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
            {
                Console.WriteLine("Error! Write number from 1 to 2.");
            }
            switch (choice)
            {
                case 1:
                    SaveApartmentInTextFile(index);
                    break;
                case 2:
                    ShowMenu();
                    break;
            }
        }
        private void SaveApartmentInTextFile(int index)
        {
            try
            {
                string filename;
                Console.WriteLine("Please write file name:");
                while (string.IsNullOrEmpty(filename = Console.ReadLine()))
                {
                    Console.WriteLine("Error! Write file name.");
                }
                apartment.WriteRoomInfoInFile(filename, ads[index]);
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
                ShowMenu();
            }
        }

        private void Success()
        {
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine("\n\tSuccess!\n");
            Console.WriteLine("----------------------------------\n");
        }

        private void Fail()
        {
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine("\n\tFailed!\n");
            Console.WriteLine("----------------------------------\n");
        }
    }
}
