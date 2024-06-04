using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.Services
{

   

    public class ProductService : IProductService
    {
        private readonly InvoiceDbContext _context;

        public ProductService(InvoiceDbContext context)
        {
            _context = context;
        }
        public void Create(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.products.Find(id);
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.products.Include(x => x.Item).AsNoTracking().ToList();
              
        }

        public Product GetById(int id)
        {
           return _context.products.Find(id);
           
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}