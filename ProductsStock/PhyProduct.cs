using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje3
{
    [System.Serializable]
    internal class PhyProduct : Product, IInventory
    {
        public float shipping;
        private int stock;

        public PhyProduct(string name, float price, float shipping)
        {
            this.name = name;
            this.price = price;
            this.shipping = shipping;
            
        }

        public void AddEntrance()
        {
            Console.Clear();
            Console.WriteLine($"Enter the amount of product {name} to add to the inventory:");
            int prodQntt = int.Parse(Console.ReadLine());
            stock += prodQntt;
            Console.WriteLine("New amount registred.\nPress ENTER to continue:");
            Console.ReadLine();

        }

        public void AddShipment()
        {
            Console.Clear();
            Console.WriteLine($"Enter the amount of {name} to remove from the inventory:");
            int prodQntt = int.Parse(Console.ReadLine());
            stock -= prodQntt;
            Console.WriteLine("Stockpile changed.\nPress ENTER to continue:");
            Console.ReadLine();
        }

        public void Display()
        {
            
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Available in stock: {stock}");
            Console.WriteLine($"Shipping price: {shipping}");
            Console.WriteLine("---------------------------------");
        }
    }
}
