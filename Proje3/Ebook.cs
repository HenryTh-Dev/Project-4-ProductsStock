using System;

namespace Proje3
{
    [System.Serializable]
    internal class Ebook : Product, IInventory
    {
        public string author;
        private int salesQnt;

        public Ebook(string name, float price, string author)
        {
            this.name = name;
            this.price = price;
            this.author = author;
        }

        public void AddEntrance()
        {
            Console.Clear();
            Console.WriteLine("You can't add stock to a digital product.");
            Console.ReadLine();
        }

        public void AddShipment()
        {
            Console.Clear();
            Console.WriteLine("You can't remove stock to a digital product.");
            Console.ReadLine();
        }

        public void Display()
        {
            
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Sales: {salesQnt}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine("---------------------------------");
        }
    }
}
