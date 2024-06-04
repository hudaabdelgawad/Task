using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class InvoiceTemp
    {
        [Key]
        public int InvoiceId { get; set; }
      
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public  Item Item { get; set; }
        public decimal Quentit { get; set; }

        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public decimal? Total { get; set; }

        
      

       

       

    }
}