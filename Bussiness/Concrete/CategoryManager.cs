using System;
using Bussiness.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Bussiness.Concrete;

public class CategoryManager : ICategoryService
{
    ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public IResult Add(Category category)
    {
        _categoryDal.Add(category);
        return new SuccessResult($"Kategori eklendi: {category.CategoryName}");
    }

    public IDataResult<List<Category>> GetAll()
    {
        //İşKodları
        return new SuccessDataResult<List<Category>> (_categoryDal.GetAll());
    }

    public IDataResult<Category> GetById(int categoryId)
    {
        return new SuccessDataResult<Category> (_categoryDal.Get(c=>c.CategoryId == categoryId));
    }
}

