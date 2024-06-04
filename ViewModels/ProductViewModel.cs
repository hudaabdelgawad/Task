using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.ViewModels
{
    public class ProductViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "ProductName")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MaxLength")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MinLength")]
        [Display(Name = "ProductNam", ResourceType = typeof(Resource.Resource))]

        public string Name { get; set; }

        [Display(Name = "ProductPrice", ResourceType = typeof(Resource.Resource))]

        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "PriceRequired")]
        [Range(0.01, double.MaxValue, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "PriceRange")]
        public decimal Price { get; set; }
       // public string ProductImage { get; set; }

       
        [Display(Name = "item", ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "ItemName")]

        public int ItemId { get; set; }
       // public Item Item { get; set; }
        public IEnumerable<Item> items { get; set; }
    }
}