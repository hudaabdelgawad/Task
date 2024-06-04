using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Invoice:BaseEntity
    {
        [Display(Name = "ClientName", ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "selectclient")]

        public int ClientId { get; set; }
        public Client Client { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "OrderDateRequired")]
       
        public DateTime InvoiceDate { get; set; }
        [Display(Name = "total", ResourceType = typeof(Resource.Resource))]

        public decimal TotalAmount { get; set; }
        [Display(Name = "Dscount", ResourceType = typeof(Resource.Resource))]

        public decimal TotalDiscount { get; set; }
        [Display(Name = "NetAmount", ResourceType = typeof(Resource.Resource))]

        public decimal NetAmount { get; set; }
         //public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
         public List<InvoiceProduct> InvoiceProductList { get; set; } = new List<InvoiceProduct>();
    }
    
}
