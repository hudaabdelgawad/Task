using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class InvoiceProduct : BaseEntity
    {
        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "QuantityRequired")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "QuantityRange")]
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int ProductId { get; set; }
      //  public int InvoiceId { get; set; }
     
        public Product Product { get; set; }
      
        public Invoice Invoice { get; set; }

    }
}
