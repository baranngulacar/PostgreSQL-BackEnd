using System;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Bussiness.Abstract
{
	public interface IProductService
	{
		IDataResult <List<Product>> GetAll();

        IDataResult <List<Product>> GetAllByCategoryId(int id);

		IDataResult <List<Product>> GetByUnitPrice(decimal min, decimal max);

        IDataResult <List<ProductDetailDto>> GetProductDetails();

        IDataResult <Product> GetById(int productId);

		IResult Add(Product product);
    }
}

