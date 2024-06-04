using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection.Emit;
using Task.Models;
namespace Task
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Product> products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceProduct> InvoiceProducts { get; set; }
        public DbSet<InvoiceTemp> InvoiceTemps { get; set; }
        public DbSet<User> Users { get; set; }

       
    }

  
}