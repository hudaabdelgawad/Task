using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Product:BaseEntity
    {
        [Display(Name = "ProductNam", ResourceType = typeof(Resource.Resource))]

        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "ProductName")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MaxLength")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MinLength")]
        public string Name { get; set; }

        [Display(Name = "ProductPrice", ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessageResourceType =typeof (Resource.Resource), ErrorMessageResourceName = "PriceRequired")]
        [Range(0.01, double.MaxValue, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "PriceRange")]
        public decimal Price { get; set; }
      //  public string ProductImage { get; set; }

        [Display(Name = "item", ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "ItemName")]

        public int ItemId { get; set; }
        public Item Item { get; set; }










        // public string? Image { get; set; }


    }
}
