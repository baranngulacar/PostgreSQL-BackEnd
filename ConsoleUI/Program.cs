﻿using System;
using Bussiness.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI;
class Program
{
    static void Main(string[] args)
    {
        //Data Transformation Object
        //IoC
        ProductTest();
        //CategoryTest();
    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        foreach (var category in categoryManager.GetAll())
        {
            Console.WriteLine(category.CategoryName + " " + category.CategoryId);
        }
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        var result = productManager.GetProductDetails();

        if (result.Succes)
        {
            foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            }
        }

        else
        {
            Console.WriteLine(result.Message);
        }

        foreach (var product in productManager.GetProductDetails().Data)
        {
            Console.WriteLine(product.ProductName + "/" + product.CategoryName);
        }

        Console.WriteLine("-----------------------------------");
    }
}
