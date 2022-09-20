using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje3
{
    [System.Serializable]
    internal class Course : Product, IInventory
    {
        public string author;
        private int vacancies;

        public Course(string name, float price, string author)
        {
            this.name = name;
            this.price = price;
            this.author = author;
            
        }

        public void AddEntrance()
        {
            Console.Clear();
            Console.WriteLine($"Add the amount of vacancies to the course {name}:");
            int prodQntt = int.Parse(Console.ReadLine());
            vacancies += prodQntt;
            Console.WriteLine("New amount registred.\nPress ENTER to continue:");
            Console.ReadLine();

        }

        public void AddShipment()
        {
            Console.Clear();
            Console.WriteLine($"Enter the amount to remove vacancies from the course {name}:");
            int prodQntt = int.Parse(Console.ReadLine());
            vacancies -= prodQntt;
            Console.WriteLine("New amount registred.\nPress ENTER to continue:");
            Console.ReadLine();
        }

        public void Display()
        {
            
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Remaining vacancies: {vacancies}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine("---------------------------------");
        }
    }
}
