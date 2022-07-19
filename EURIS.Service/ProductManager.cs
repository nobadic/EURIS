using System.Collections.Generic;
using System.Linq;
using EURIS.Entities;

namespace EURIS.Service
{
    public class ProductManager
    {
        private LocalDbEntities _context = new LocalDbEntities();

        public List<Product> GetProducts()
        {
            var products = (from item in _context.Product select item).ToList();
            return products;
        }
        public Product GetProductDetail(int id = 0)
        {
            var prodDetail = (from item in _context.Product select item).Where(s => s.Id == id).FirstOrDefault();
            return prodDetail;
        }
        public Product Create(Product prod)
        {
            _context.Product.Add(prod);
            _context.SaveChanges();
            return prod;
        }
        public Product IfExist(int id = 0)
        {
            var ifExist = (from item in _context.Product select item).Where(s => s.Id == id).FirstOrDefault();
            return ifExist;
        }
        public Product Delete(Product product)
        {
            _context.ProductCatalog.Where(p => p.ProductId == product.Id)
                  .ToList().ForEach(p => _context.ProductCatalog.Remove(p));
            _context.Product.Remove(product);
            _context.SaveChanges();
            return null;
        }
        public Product Edit(Product product)
        {
            _context.Entry(product).State = System.Data.EntityState.Modified;
            _context.SaveChanges();
            return product;
        }
    }
}
