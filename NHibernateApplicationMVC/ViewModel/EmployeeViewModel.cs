using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NHibernateApplicationMVC.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Display(Name = "Employee Address")]
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }

        [Display(Name = "Employee Mobile No")]
        [Required(ErrorMessage = "Please Enter MobileNo")]
        public string MobileNo { get; set; }

        [Display(Name = "Employee Birth Date")]
        [Required(ErrorMessage = "Please Enter Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Employee Blood Group")]
        [Required(ErrorMessage = "Please Enter Blood Group")]
        public string BloodGroup { get; set; }

        [Display(Name = "Employee Emergeny Contact No")]
        [Required(ErrorMessage = "Please Enter Contact No")]
        public string EmergencyNo { get; set; }
    }
}