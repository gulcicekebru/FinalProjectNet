using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //Globallar için _ şeklinde yazılır genelde.
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1,CategoryId=1,ProductName="Kalem", UnitPrice=50, UnitsInStock=500},
                new Product{ProductId=2,CategoryId=2,ProductName="Defter", UnitPrice=65, UnitsInStock=100},
                new Product{ProductId=3,CategoryId=1,ProductName="Tükenmez Kalem", UnitPrice=70, UnitsInStock=1000},
                new Product{ProductId=4,CategoryId=2,ProductName="Kitap", UnitPrice=105, UnitsInStock=300},
                new Product{ProductId=4,CategoryId=3,ProductName="Kulaklık", UnitPrice=2000, UnitsInStock=50}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query Bilmeseydik

            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if(product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }

            //    _products.Remove(productToDelete);
            //}

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);

                _products.Remove(productToDelete);

        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName= product.ProductName;
            productToUpdate.UnitPrice= product.UnitPrice;
            productToUpdate.CategoryId= product.CategoryId;
            productToUpdate.UnitsInStock= product.UnitsInStock;
        }
    }
}
