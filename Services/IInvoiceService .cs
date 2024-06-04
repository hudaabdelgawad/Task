using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Services
{
    public interface IInvoiceService
    {
        IEnumerable<Invoice> GetAll();
       // Invoice GetById(int id);
        void Create(Invoice invoice);
        //void Update(Invoice invoice);
        //void Delete(int id);
    }
}
