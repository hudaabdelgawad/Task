using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
namespace Task.Models
{

    
    public class Item:BaseEntity
    {
        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "ItemName")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MaxLength")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MinLength")]
        [Display(Name = "item", ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }
        //public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        //public virtual ICollection<InvoiceTemp> InvoiceTemps { get; set; } = new List<InvoiceTemp>();


    }
}
