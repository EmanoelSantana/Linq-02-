using System;
using System.Linq;
using Linq02.Entites;
using System.Collections.Generic;

namespace Linq02
{
    class Program
    {
            static void Print<T>(string message, IEnumerable<T> collection)
        {
            System.Console.WriteLine(message);
            foreach(T obj in collection)
            {
                System.Console.WriteLine(obj);
            }
        }
        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2};
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1};
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1};

            List<Product> products = new List<Product>() 
            {
                new Product() { Id = 1, Name = "Computer", Price = 1100.00, Category = c2},
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
            var r1 = 
                from p in products
                where p.Category.Tier == 1 && p.Price < 900.0
                select p;
            Print("Tier 1 and Price < 900", r1);

            var r2 = 
                from p in products 
                where p.Category.Name == "Tools"
                select p.Name;
            Print("Name of products from TOOLS", r2);

            var r3 = 
                from p in products
                where p.Name[0] == 'C'
                select new  {
                    p.Name,
                    p.Category,
                    CategoryName = p.Category.Name
                };
            Print("Names started with 'C' and Anonymous Object", r3);

            var r4 = 
                from p in products
                where p.Category.Tier == 1
                orderby p.Name
                orderby p.Price
                select p;
            Print("Tier 1 order by price then by name", r4);

            var r5 = 
                (from p in r4
                select p).Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);

            var r6 = (from p in products select p).FirstOrDefault();
            Console.WriteLine("First or default test1: " + r6);

            var r7 = 
                (from p in products
                where p.Price > 3000.0
                select p).FirstOrDefault();
            Console.WriteLine("First or default test2: " + r7);
            Console.WriteLine(); 

            // Dentre as consultas r8 e r15, só fazer da forma que foi feita as r5/r6/r7

            var r16 = 
                from p in products 
                group p by p.Category;
            foreach (IGrouping<Category, Product> group in r16) {
                Console.WriteLine("Category " + group.Key.Name + ":");
                foreach (Product p in group) {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }
        }
    }
}