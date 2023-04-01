using System;
using Bussiness.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace Bussiness.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İşKodları
            //Yetkisi var mı ?
            //Bana ürünleri verebilirsin. Kurallardan geçtim şu an.

            return _productDal.GetAll();
        }
    }
}

