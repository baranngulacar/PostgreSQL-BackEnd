using System;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        private Product? productToUpdate;

        //private List<Product> _products;

        public InMemoryProductDal()
        {
            //Oracle SqlServer, Postgres, MongoDb
            _products = new List<Product>

            {
                new Product{ProductID = 1, CategoryID = 1, ProductName ="Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product{ProductID = 2, CategoryID = 1, ProductName ="Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product{ProductID = 3, CategoryID = 2, ProductName ="Telefon", UnitPrice = 1500, UnitsInStock = 2},
                new Product{ProductID = 4, CategoryID = 2, ProductName ="Klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product{ProductID = 5, CategoryID = 2, ProductName ="Fare", UnitPrice = 85, UnitsInStock = 1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            Product productToDelete = null;

            foreach (var p in _products)
            {
                if (product.ProductID == p.ProductID)
                {
                    productToDelete = p;
                }

                _products.Remove(productToDelete);
            }
            productToDelete = _products.SingleOrDefault(p=> p.ProductID == product.ProductID);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public void Update(Product product)
        {   //Gönderdiğim ürün ID'sine sahip olan listedeki ürünü bul.
            productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);

            productToUpdate.ProductName = product.ProductName;

            productToUpdate.CategoryID = product.CategoryID;

            productToUpdate.UnitPrice = product.UnitPrice;

            productToUpdate.UnitsInStock = product.UnitsInStock; 
        }
    }
}

