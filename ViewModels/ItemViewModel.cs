using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Task.Models;

namespace Task.ViewModels
{
    public class ItemViewModel
    { 
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "ItemName")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MaxLength")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MinLength")]
        [Display(Name = "item", ResourceType = typeof(Resource.Resource))]

        public string Name { get; set; }
       
    }
}