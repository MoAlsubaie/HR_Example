using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HR_Example.Models
{
    public class Dept
    {
        [Required(ErrorMessage = "You can't leave the Field Empty")]
        [Display(Name = "Department Name")]
        public string Dept_Name { get; set; }

    }
}