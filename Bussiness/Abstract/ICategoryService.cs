using System;
using Entities.Concrete;
using Entities.DTOs;

namespace Bussiness.Abstract
{
	public interface ICategoryService
	{
		List<Category> GetAll();

		Category GetById(int categoryId);
    }

}

