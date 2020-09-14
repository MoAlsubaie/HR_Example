using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HR_Example.Models
{
    public class Emp
    {
        [Required(ErrorMessage = "You can't leave the Field Empty")]
        [Display(Name = "Employee Name")]
        public string Employee_Name { get; set; }
        [Required(ErrorMessage = "You can't leave the Field Empty")]
        [Display(Name = "Employee Salary")]
        public double Employee_salary { get; set; }
        [Required(ErrorMessage = "You can't leave the Field Empty")]
        [Display(Name = "Employee Department")]
        public int Dept_ID { get; set; }
        [Required(ErrorMessage = "You can't leave the Field Empty")]
        [Display(Name = "Employee Nationalty")]
        public int Country_ID { get; set; }

    }
}