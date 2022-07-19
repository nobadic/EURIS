using System.Collections.Generic;
using System.Linq;
using EURIS.Entities;

namespace EURIS.Service
{
    public class CatalogManager
    {
        private LocalDbEntities _context = new LocalDbEntities();
       
        public List<Catalog> GetCatalogs()
        {
            var catalogs = (from item in _context.Catalog select item).ToList();
            return catalogs;
        }
        public List<ProductCatalog> GetProductCatalogs()
        {
            var productcatalogs = (from item in _context.ProductCatalog select item).ToList();
            return productcatalogs;
        }
        public Catalog GetCatalogDetail(int id = 0)
        {
            var prodDetail = (from item in _context.Catalog  select item).Where(s => s.Id == id).FirstOrDefault();
            return prodDetail;
        }
        public ProductCatalog GetProductCatalogDetail(int id = 0)
        {
            var prodDetail = (from item in _context.ProductCatalog select item).Where(s => s.CatalogId == id).FirstOrDefault();
            return prodDetail;
        }
        public Catalog Create(Catalog prod)
        {
            _context.Catalog.Add(prod);
            _context.SaveChanges();
            return prod;
        }
        public ProductCatalog CreatePC(ProductCatalog prod)
        {
            _context.ProductCatalog.Add(prod);
            _context.SaveChanges();
            return prod;
        }
        
        public Catalog IfExist(int id = 0)
        {
            var ifExist = (from item in _context.Catalog select item).Where(s => s.Id == id).FirstOrDefault();
            return ifExist;
        }
        public Catalog Delete(Catalog catalog)
        {

            _context.ProductCatalog.Where(p => p.CatalogId == catalog.Id)
               .ToList().ForEach(p => _context.ProductCatalog.Remove(p));
            _context.Catalog.Remove(catalog);
            _context.SaveChanges();
            return null;
        }
        public Catalog Edit(Catalog catalog)
        {
            _context.Entry(catalog).State = System.Data.EntityState.Modified;
            _context.SaveChanges();
            return catalog;
        }
    }
    public class CatalogProd
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<int> ProdId { get; set; }
    }
}
