using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contacs.Models
{
    
    public class Details
    {
        [BindProperty(SupportsGet = true)]
        [Key]
        public int ID { get; set; }
        [Required]
        [BindProperty(SupportsGet = true)]
        [Display(Name ="First Name")]
        public string FName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [BindProperty(SupportsGet = true)]
        public string LName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        [Display(Name = "Phone Number")]
        public string PNumber { get; set; }

        public bool Status { get; set; }
    }
}
