using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.Services
{

   

    public class InvoiceService : IInvoiceService
    {
        private readonly InvoiceDbContext _context;

        public InvoiceService(InvoiceDbContext context)
        {
            _context = context;
        }
        public void Create(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Invoice> GetAll()
        {
            
            return _context.Invoices.Include(i => i.Client).Include(i => i.InvoiceProductList.Select(item => item.Product)).ToList();
        }

        public Invoice GetById(int id)
        {
            return _context.Invoices.Include(i => i.Client).Include(i => i.InvoiceProductList.Select(item => item.Product)).SingleOrDefault(i=>i.Id == id);

            

        }

        public void Update(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}