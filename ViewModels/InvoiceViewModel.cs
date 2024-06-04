using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.ViewModels
{
    public class InvoiceViewModel
    {
        public Invoice NewBuyInovice { get; set; } = new Invoice();
        public IEnumerable<Client> Clientlist {get;set; }
        public IEnumerable<Item> Itemlist {get;set; }
      

    }
}