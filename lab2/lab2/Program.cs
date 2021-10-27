using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            menu();
        }

        static void menu()
        {
            int choice;
            while (true)
            {
                {
                    Console.WriteLine("Выберите пункт:");
                    Console.WriteLine("1)Простмотреть данные");
                    Console.WriteLine("2)Добавить данные");
                    Console.WriteLine("3)Удалить данные");
                    Console.WriteLine("4)Изменить данные");
                    Console.WriteLine("5)Поиск данных ");
                    Console.WriteLine("6)Сортировка данных по цене:");
                    Console.WriteLine("0)Выйти");
                    while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 6)
                    {
                        Console.WriteLine("Ошибка! Введите число от 0 до 6.");
                    }
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            showAll();
                            break;
                        case 2:
                            Console.Clear();
                            add();
                            break;
                        case 3:
                            Console.Clear();
                            delete();
                            break;
                        case 4:
                            Console.Clear();
                            update();
                            break;
                        case 5:
                            Console.Clear();
                            searchByName();
                            break;
                        case 6:
                            Console.Clear();
                            sortByPrice();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                           break;
                    }
                    Console.Write("\nНажмите любую клавишу...");
                    Console.ReadLine();
                    Console.Clear();
                }

            }
        }

        static void showAll()
        {
            FileService service = new FileService();
            List<Veg> objects = service.readFile();
            if (objects.Count < 1)
            {
                Console.WriteLine("Нет данных");
            }
            foreach(var obj in objects)
            {
                Console.WriteLine($"Id: {obj.Id}, Название: {obj.Name}, Цена: {obj.Price}, Количество: {obj.Quantity}");
            }
        }

        static void add()
        {
            Veg veg = inputData();
            veg.Id = 1;
            FileService service = new FileService();
            try
            {
                List<Veg> objects = service.readFile();
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
        static void delete()
        {
            showAll();
            FileService service = new FileService();
            List<Veg> objects = service.readFile();
            if (objects.Count > 1)
            {
                objects.Sort((o1, o2) => o1.Id.CompareTo(o2.Id));
                Console.WriteLine("Введите ID записи, которую хотите изменить");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id) || id < 0 || id > objects.Last().Id)
                {
                    Console.WriteLine($"Ошибка! Введите число от 1 до {objects.Last().Id}.");
                }
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
                }
                else
                {
                    Console.WriteLine("Записи с таким ID не найдено");
                }
            }
        }
        static void update() 
        {
            showAll();
            FileService service = new FileService();
            List<Veg> objects = service.readFile();
            if (objects.Count > 1)
            {
                objects.Sort((o1, o2) => o1.Id.CompareTo(o2.Id));
                Console.WriteLine("Введите ID записи, которую хотите изменить");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id) || id < 0 || id > objects.Last().Id)
                {
                    Console.WriteLine($"Ошибка! Введите число от 1 до {objects.Last().Id}.");
                }
                if (objects.Exists(o => o.Id == id))
                {
                    Veg veg = inputData();
                    List<Veg> newObjects = new List<Veg>();
                    foreach (var obj in objects)
                    {
                        if (obj.Id == id)
                        {
                            veg.Id = id;
                            newObjects.Add(veg);
                        }
                        else
                        {
                            newObjects.Add(obj);
                        }
                    }
                    service.rewriteFile(newObjects);
                }
                else
                {
                    Console.WriteLine("Записи с таким ID не найдено");
                }
            }
        }
        static void searchByName() 
        {
            FileService service = new FileService();
            List<Veg> objects = service.readFile();
            if (objects.Count < 1)
            {
                Console.WriteLine("Нет данных");
            }
            else
            {
                string name;
                Console.WriteLine("Введите название");
                while (string.IsNullOrEmpty(name = Console.ReadLine()))
                {
                    Console.WriteLine("Ошибка! Введите название.");
                }
                if (!objects.Exists(ob => ob.Name.Equals(name)))
                {
                    Console.WriteLine("Записи с таким ID не найдено");
                }
                else
                {
                    foreach (var obj in objects)
                    {
                        if (obj.Name.Equals(name))
                        {
                            Console.WriteLine($"Id: {obj.Id}, Название: {obj.Name}, Цена: {obj.Price}, Количество: {obj.Quantity}");
                        }
                    }
                }
            }
        }
        static void sortByPrice()
        {
            FileService service = new FileService();
            List<Veg> objects = service.readFile();
            objects.Sort((o1, o2) => o2.Price.CompareTo(o1.Price));
            if (objects.Count < 1)
            {
                Console.WriteLine("Нет данных");
            }
            foreach (var obj in objects)
            {
                Console.WriteLine($"Id: {obj.Id}, Название: {obj.Name}, Цена: {obj.Price}, Количество: {obj.Quantity}");
            }
        }

        static Veg inputData()
        {
            Veg veg = new Veg();
            int quantity;
            float price;
            Console.WriteLine("Введите название");
            while (string.IsNullOrEmpty(veg.Name = Console.ReadLine()))
            {
                Console.WriteLine("Ошибка! Введите название.");
            }
            Console.WriteLine("Введите цену");
            while (!float.TryParse(Console.ReadLine(), out price) || price < 0 || price > 10000000)
            {
                Console.WriteLine($"Ошибка! Введите число от 0 до 10000000.");
            }
            veg.Price = price;
            Console.WriteLine("Введите количество");
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0 || quantity > 10000000)
            {
                Console.WriteLine($"Ошибка! Введите число от 0 до 10000000.");
            }
            veg.Quantity = quantity;
            return veg;
        }
    }

}
