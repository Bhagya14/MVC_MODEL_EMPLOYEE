using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MVC_Model_Employee.Models
{
    public class EmployeeProjectionModel
    {
        [Display(Name = "Employee id")]
        public int employeeid { get; set; }
        [Display(Name = "Employee name")]
        public string employeename { get; set; }
        [Display(Name = "employee gender")]
        public string employeegender { get; set; }
        [Display(Name = "employee image")]
        public string employeeimageaddress { get; set; }


    }
}