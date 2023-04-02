using System;
using Bussiness.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI;
class Program
{
    static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        foreach (var product in productManager.GetAll())
        {
            Console.WriteLine(product.ProductName);
        }

        Console.WriteLine("-----------------------------------");

        var data = productManager.GetById(3);
        Console.WriteLine(data.ProductId + " " + data.ProductName);
    }
}

// görüşürüz 