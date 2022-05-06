using LinqLambda.Entities;
using System.Linq;
using System;

namespace LinqLambda
{
    public class Program
    {
        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };

            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3 },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
                new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
                new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3 },
                new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = c3 },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 },
                new Product() { Id = 11, Name = "Level", Price = 70.0, Category = c1 }
            };


            // result 1 receives all products where a item is tier 1 and price less than 900
            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
            Print("TIER 1 AND PRICE < 900:", r1);

            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name); //Select allows me to print only the names
            Print("NAMES OF PRODUCTS FROM TOOLS", r2);
            Console.WriteLine();

            var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name }); //category name is a anonymous object
            Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", r3);

            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name); //OrderBy is ordering the prices ascending and ThenBy is reordering by name if there is objects with the same price
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4);

            var r5 = r4.Skip(2).Take(4); // skip the 2 fist objects and then print the four senquential objects
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);

            var r6 = products.FirstOrDefault();
            Console.WriteLine("First or default test1: " + r6);
            var r7 = products.Where(p => p.Price > 3000.0).FirstOrDefault(); //FirsOrDefault returns the first element of a sequence 
            Console.WriteLine("First or default test2: " + r7);
            Console.WriteLine();

            var r8 = products.Where(p => p.Id == 3).SingleOrDefault(); //Single of Default returns only one element or null. If where result is higher than 1 an excpetion is thrown
            Console.WriteLine("Single or default test1: " + r8);

            var r9 = products.Where(p => p.Id == 30).SingleOrDefault();  //Returning null
            Console.WriteLine("Single or default test2: " + r9);
            Console.WriteLine();

            var r10 = products.Max(p => p.Price); // Max returns the higher value 
            Console.WriteLine("Max price: " + r10);

            var r11 = products.Min(p => p.Price); // min returns the lower value
            Console.WriteLine("Min price: " + r11);

            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price); // Where is selecting all the products of category 1 and sum is makes the sum of all the elements of category 1
            Console.WriteLine("Category 1 Sum prices: " + r12);

            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price); // Avarage is returning all the products avarage 
            Console.WriteLine("Category 1 Average prices: " + r13);

            var r14 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average(); //DefaultIfEmpty is allows us to return a value if the values does not exist
            Console.WriteLine("Category 5 Average prices: " + r14);

            var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y); // returning the sum of all objects of the collection using Aggregate
            Console.WriteLine("Category 1 aggregate sum: " + r15);

            Console.WriteLine();

            var r16 = products.GroupBy(p => p.Category); //Grouping the objects by category
            foreach (IGrouping<Category, Product> group in r16)
            {
                Console.WriteLine("Category " + group.Key.Name + ":"); // Key is category
                foreach (Product p in group)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }

            static void Print<T>(string messege, IEnumerable<T> collection) // method to print something having a message and a generic collection of Enumerables 
            {
                Console.WriteLine(messege);
                foreach (T obj in collection) // foreach generic item in my collection of generics 
                {
                    Console.WriteLine(obj);
                }
                Console.WriteLine();
            }
        }
    }
}
