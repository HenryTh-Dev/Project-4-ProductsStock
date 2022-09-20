using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Proje3
{
    class MainMenu
    {   
        static List <IInventory> products = new List<IInventory>();
        enum Menu { List = 1, Add, Remove, Entrance, Shipment, Exit }
        static void Main(string[] args)
        {
            Load();
            var ChExit = false;
            while (!ChExit)
            {
                try
                {


                    Console.Clear();
                    Console.WriteLine("Inventory System");
                    Console.WriteLine("\n1-List\n2-Add\n3-Remove\n4-Stockpile Add\n5-Stockpile Remove\n6-Exit");
                    int ChMenu = int.Parse(Console.ReadLine());
                    Menu option = (Menu)ChMenu;
                    switch (option)
                    {
                        case Menu.List:
                            List();
                            break;
                        case Menu.Add:
                            AddProduct();
                            break;
                        case Menu.Remove:
                            Remove();
                            break;
                        case Menu.Entrance:
                            StockpileAdd();
                            break;
                        case Menu.Shipment:
                            StockpileRemove();
                            break;
                        case Menu.Exit:
                            ChExit = true;
                            break;
                    }
                }catch
                {
                    Console.Clear();
                    Console.WriteLine("Please select a number that is within the list\nPress enter to try again");
                    Console.ReadLine();
                }
            }
        }
        static void List()
        {
            Console.Clear();
            Console.WriteLine("Products list:");
            Console.WriteLine("---------------------------------");
            int i = 0; 
            foreach (IInventory item in products)
            {
                Console.WriteLine($"Index ID:{i}");
                item.Display();
                i++;
            }
            Console.ReadLine();
            Console.WriteLine("Press ENTER to return.");
        }
        static void Remove()
        {
            Console.Clear();
            Console.WriteLine("Products list:");
            Console.WriteLine("---------------------------------");
            int i = 0;
            foreach (IInventory item in products)
            {
                Console.WriteLine($"Index ID:{i}");
                item.Display();
                i++;
            }
            Console.WriteLine("Enter the index ID to remove the product:");
            int id = int.Parse(Console.ReadLine());
            products.RemoveAt(id);
            Console.WriteLine($"Product of ID {id} removed.\nPress ENTER to return");
            Console.ReadLine();
            Save();
        }
        static void StockpileAdd()
        {
            Console.Clear();
            Console.WriteLine("Products list:");
            Console.WriteLine("---------------------------------");
            int i = 0;
            foreach (IInventory item in products)
            {
                Console.WriteLine($"Index ID:{i}");
                item.Display();
                i++;
            }
            Console.WriteLine("Enter the index ID of the product that you want to add stock:");
            int id = int.Parse(Console.ReadLine());
            products[id].AddEntrance();
            Save();

        }
        static void StockpileRemove()
        {
            Console.Clear();
            Console.WriteLine("Products list:");
            Console.WriteLine("---------------------------------");
            int i = 0;
            foreach (IInventory item in products)
            {
                Console.WriteLine($"Index ID:{i}");
                item.Display();
                i++;
            }
            Console.WriteLine("Enter the index ID of the product that you want to remove stock:");
            int id = int.Parse(Console.ReadLine());
            products[id].AddShipment();
            Save();

        }
        enum MenuAdd { PhysicalProduct = 1, Ebook, Course, Back}
        static void AddProduct()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Select a option below to add a new product:");
                Console.WriteLine("\n1-Physical Product\n2-Ebook\n3-Course\n4-Back");
                int chMenuAdd = int.Parse(Console.ReadLine());
                MenuAdd optionAdd = (MenuAdd)chMenuAdd;
                switch (optionAdd)
                {
                    case MenuAdd.PhysicalProduct:
                        AddPhysicalProduct();
                        break;
                    case MenuAdd.Ebook:
                        AddEbook();
                        break;
                    case MenuAdd.Course:
                        AddCourse();
                        break;
                    case MenuAdd.Back:
                        
                        break;
                }
            }catch
            {
                Console.Clear();
                Console.WriteLine("Please use only numbers\nPress enter to try again");
                Console.ReadLine();
                AddProduct();
            }
        }
        static void AddPhysicalProduct()
        {
            Console.Clear();
            Console.WriteLine("Adding physical product:");
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Price: ");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("Shipping Price:");
            float shipping = float.Parse(Console.ReadLine());

            PhyProduct ph = new PhyProduct(name, price, shipping);
            products.Add(ph);
            Save();
        }
        static void AddEbook()
        {
            Console.Clear();
            Console.WriteLine("Adding Ebook:");
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Price: ");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("Author:");
            string author = Console.ReadLine();

            Ebook eb = new Ebook(name, price, author);
            products.Add(eb);
            Save();
        }
        static void AddCourse()
        {
            Console.Clear();
            Console.WriteLine("Adding Course:");
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Price: ");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("Author:");
            string author = Console.ReadLine();

            Course crs = new Course(name, price, author);
            products.Add(crs);
            Save();
        }
        static void Save()
        {
            FileStream stream = new FileStream("product.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();
            encoder.Serialize(stream, products);
            stream.Close();
        }
        static void Load()
        {
            FileStream stream = new FileStream("product.dat", FileMode.OpenOrCreate);
            try
            {
                BinaryFormatter encoder = new BinaryFormatter();

                products = (List<IInventory>)encoder.Deserialize(stream);

                if (products == null)
                {
                    products = new List<IInventory>();

                }


            }
            catch (Exception ex)
            {
                products = new List<IInventory>();

            }

            stream.Close();
        }


    }
}
