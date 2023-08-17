using Business.Concrete;
using Entities.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
                
            }
            Product product1 = new Product();
            product1.ProductName = "Kamera";
            product1.UnitPrice = 502;
            product1.ProductId = 8;
            product1.CategoryId = 8;
            product1.UnitsInStock = 302;

            Console.WriteLine("---------------------------------");

            ProductManager productManager2 = new ProductManager(new InMemoryProductDal());
            productManager2.Add(product1);
            foreach (var product2 in productManager2.GetAll())
            {
                Console.WriteLine(product2.ProductName);

            }



        }
    }
}
