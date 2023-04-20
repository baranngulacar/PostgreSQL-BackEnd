using System;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.products
                             join c in context.categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {

                                 ProductId = p.ProductId,

                                 ProductName = p.ProductName,

                                 CategoryName = c.CategoryName,

                                 UnıtsInStock = p.UnitsInStock

                             };

                             return result.ToList();
            }
        }
    }
}
