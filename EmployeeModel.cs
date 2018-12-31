using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Model_Employee.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Employee ID")]
        public int employeeid { get; set; }

        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "*")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Too short name")]
        public string employeename { get; set; }

        [Display(Name = "Employee city")]
        [Required(ErrorMessage = "*")]
        public string employeecity { get; set; }

        [Display(Name = "Employee Email")]
        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage = "Invalid Format")]
        public string employeeemail { get; set; }

        [Display(Name = "Employee password")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Student gender")]
        [Required(ErrorMessage = "*")]
        public string gender { get; set; }
        public string employeeimageaddress { get; set; }
        [Display(Name = "Employee Image")]
        [Required(ErrorMessage = "*")]
        public HttpPostedFileBase employeeimagefile { get; set; }

    }
}