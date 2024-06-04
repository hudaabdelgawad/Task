using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.Services
{

   

    public class ItemService : IItemService
    {
        private readonly InvoiceDbContext _context;

        public ItemService(InvoiceDbContext context)
        {
            _context = context;
        }
        public void Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.Items.Find(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public Item GetById(int id)
        {
           return _context.Items.Find(id);
           
        }

        public void Update(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}