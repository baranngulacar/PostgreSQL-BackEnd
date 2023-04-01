using System;
using Entities.Concrete;

namespace DataAccess.Abstract
{
	public interface IProductDal
	{
		List<Product> GetAll();

		void Add(Product product);

		void Update(Product product);

		void Delete(Product product);

		List<Product> GetByCategory(int categoryId);
	}
}

