﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Model_Employee.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Login id(Employee id)")]
        [Required(ErrorMessage = "*")]
        public int loginid { get; set; }

        [Display(Name = "password")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}