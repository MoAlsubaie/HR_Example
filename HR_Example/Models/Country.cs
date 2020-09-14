using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HR_Example.Models
{
    public class Country
    {
        [Required(ErrorMessage = "You can't leave the Field Empty")]
        [Display(Name = "Country Name")]
        public string Country_name { get; set; }
    }
}