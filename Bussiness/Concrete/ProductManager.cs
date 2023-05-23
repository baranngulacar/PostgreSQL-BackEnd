using System;
using Bussiness.Abstract;
using Bussiness.Constants;
using Bussiness.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Bussiness.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;


        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //İşKodlarımız - BussinessCodes
            //Validation - Kurallarımız, Doğrulama

            ValidationTool.Validate(new ProductValidator(),product);

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }


        public IDataResult<List<Product>> GetAll()
        {
            var data = _productDal.GetAll();
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(data, "Ürün listesi getirildi.");
        }


        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }


        public IDataResult<Product> GetById(int ProductId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == ProductId));
        }


        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }


        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        IDataResult<List<ProductDetailDto>> IProductService.GetProductDetails()
        {
            var data = _productDal.GetProductDetails();

            return new SuccessDataResult<List<ProductDetailDto>>(data, "Dto listesi getirildi");
        }
    }
}
