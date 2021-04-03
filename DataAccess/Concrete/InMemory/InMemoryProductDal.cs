using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _producs;//naming commention
        public InMemoryProductDal()
        {
            _producs = new List<Product>
            {//server dan geliyormus gibi 
                new Product{ProductId=1,CategoryId=1,ProductName="bardak",UnitPrice=15,UnitInStock=15},
                new Product{ProductId=2,CategoryId=2,ProductName="Kamera",UnitPrice=500,UnitInStock=3},
                new Product{ProductId=3,CategoryId=3,ProductName="Telefon",UnitPrice=1500,UnitInStock=2},
                new Product{ProductId=4,CategoryId=4,ProductName="Klavye",UnitPrice=150,UnitInStock=65},
                new Product{ProductId=5,CategoryId=5,ProductName="Fare",UnitPrice=85,UnitInStock=1},
            };
        }
            
        public void Add(Product product)
        {
            _producs.Add(product);
        }

        public void Delete(Product product)
        {
            // _producs.Remove(product); yanlıs arayüz de new lenince gönderilen product 
            //verileri aynı olsa bile databaseden gelenlerin referansı farklı
            //doğrusu için PrimaryKey kullanmalıyız Linq ile kolay

            //linq suz hali 
            /*
    Product productToDelete=null;
    foreach (var p in _producs)
    {
        if (product.ProductId == p.ProductId)
        {
            productToDelete = p;
        }
    }
    _producs.Remove(productToDelete);*/
            //LİNQ LANGUAGE INTEGRATED QUERY
            //linq lu version
            Product productToDelete = _producs.SingleOrDefault(p=>p.ProductId==product.ProductId );
            _producs.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _producs;
        }

        public List<Product> GetAllCatagory(int categoryid)
        {
            return _producs.Where(p => p.CategoryId == categoryid).ToList();
        }

        public void Update(Product product)//ekrandan gelen data ilk olarak listede databse de refereansı bulduk sonra atama 
        { //gönderilen id ye sahip ürünü listeden bul
            Product productToUpdate = _producs.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}
