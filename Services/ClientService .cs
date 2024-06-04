using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.Services
{

   

    public class ClientService : IClientService
    {
        private readonly InvoiceDbContext _context;

        public ClientService(InvoiceDbContext context)
        {
            _context = context;
        }
        public void Create(Client clint)
        {
            _context.Clients.Add(clint);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var clint = _context.Clients.Find(id);
            if (clint != null)
            {
                _context.Clients.Remove(clint);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        public Client GetById(int id)
        {
           return _context.Clients.Find(id);
           
        }

        public void Update(Client clint)
        {
            _context.Entry(clint).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}