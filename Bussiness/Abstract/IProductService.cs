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

		IDataResult <List<Product>> GetByUnitPrice(double min, double max);

        IDataResult <List<ProductDetailDto>> GetProductDetails();

        IDataResult <Product> GetById(int productId);

		IResult Add(Product product);

        IResult Update(Product product);
    }
}

