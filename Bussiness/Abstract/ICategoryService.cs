using System;
using System.Text;
using System.Collections.Generic;
using Entities.Concrete;
using Entities.DTOs;
using Core.Utilities.Results;

namespace Bussiness.Abstract
{
	public interface ICategoryService
	{
		IDataResult<List<Category>> GetAll();

		IDataResult<Category> GetById(int categoryId);
    }

}

