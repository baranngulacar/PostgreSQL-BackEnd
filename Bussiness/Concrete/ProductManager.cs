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

        public Product GetById(int id)
        {
            var res = _productDal.Get(c => c.ProductId == id);
            if(res != null && res.ProductId != 0) {
                return res;
            }
            return null;
        }
    }
}

