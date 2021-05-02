﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.RazorPages.Models
{
    public class SignIn
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password {get; set; }
        [Required]
        [Display(Name = "Remeber Me")]
        public Boolean RememberMe { get; set; }

    }
}
