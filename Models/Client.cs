

using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class Client:BaseEntity

    {
        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "ClientNameRequired")]
        [StringLength(150)]
        [Display(Name = "FullName", ResourceType = typeof(Resource.Resource))]

        public string FullName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "ClientAddressRequired")]

        [MaxLength(150)]
        [Display(Name = "Address", ResourceType = typeof(Resource.Resource))]

        public string Address { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "ClientPhoneRequired")]
        [StringLength(11, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "Phonedigit")]
        [RegularExpression("^01[0 - 2, 5]\\d{8}$",ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "Phoneformat")]
        [Display(Name = "PhonrNumber", ResourceType = typeof(Resource.Resource))]

        public string Phone { get; set; }
        
    }
}
