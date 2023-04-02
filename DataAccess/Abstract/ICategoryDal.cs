using System;
using Entities.Concrete;

namespace DataAccess.Abstract
{
	public interface ICategoryDal
	{
        List<Category> GetAll();

        void Add(Category category);

        void Update(Category category);

        void Delete(Category category);

        List<Category> GetByCategory(int categoryId);
    }
}

