using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class LoginModel
    {
        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "UserName")]
        [Display(Name = "user", ResourceType = typeof(Resource.Resource))]

        public string Username { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "password")]
        [Display(Name = "pass", ResourceType = typeof(Resource.Resource))]

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}