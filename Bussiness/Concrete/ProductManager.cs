using System;
using Bussiness.Abstract;
using Bussiness.Constants;
using Bussiness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Bussines;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Bussiness.Concrete
{   //Ürün iş mantığını yöneten sınıfımız
    public class ProductManager : IProductService
    {
         private IProductDal _productDal;
        private ICategoryService _categoryService;

        //Constructor methodumuz, bağımlılıkları enjekte ediyoruz.
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //Add methodu, yeni bir ürün eklemek için kullanılır.
        [ValidationAspect(typeof(ProductValidator))] 
        public IResult Add(Product product)
        {
            //İşKodlarımız - BussinessCodes
            //Validation - Kurallarımız, Doğrulama

            //Ürünü veritabanına ekliyoruz

            IResult result = BussinesRules.Run(CheckIfProductNameExists(product.ProductName),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfCategoryLimitExceded());

                if (result != null)
                {
                    return result;
                }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

            //Başarılı sonucu döndürüyoruz
        }

        //GetAll methodu, tüm ürünleri listeler
        public IDataResult<List<Product>> GetAll()
        {
            var data = _productDal.GetAll();

            //Eğer şu an saat 22.00 ise, bakım zamanı hatası döndürüyoruz
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            //Başarılı sonucu ve verileri döndürüyoruz
            return new SuccessDataResult<List<Product>>(data, "Ürün listesi getirildi.");
        }

        //GetAllByCategoryId methodu, belirli bir kategoriye ait ürünleri listeler
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            //Belirli bir kategoriye ait ürünleri veritabanından alıyoruz.
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        //GetById methodu, belirli bir ürünün detaylarını getirir.
        public IDataResult<Product> GetById(int ProductId)
        {
            //Belirli bir ürünün detaylarını veritabanından alıyoruz.
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == ProductId));
        }

        //GetByUnitPrice methodu, belirli bir fiyat aralığındaki ürünleri getirir.
        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            //Belrili bir fiyat aralığındaki ürünleri veritabanından alıyoruz.
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        //GetProductDetails methodu, ürünlerin detaylı bilgilerini getirir
        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            // Ürünlerin detaylı bilgilerini veritabanından alıyoruz
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<ProductDetailDto>> IProductService.GetProductDetails()
        {
            var data = _productDal.GetProductDetails();

            return new SuccessDataResult<List<ProductDetailDto>>(data, "Dto listesi getirildi");
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExsists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();
        }
    }
}
