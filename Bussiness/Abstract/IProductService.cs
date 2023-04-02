using System;
using Entities.Concrete;

namespace Bussiness.Abstract
{
	public interface IProductService
	{
		List<Product> GetAll();
		Product GetById(int id);
	}
}

