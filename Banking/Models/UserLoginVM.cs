using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Banking.Models
{
    public class UserLoginVM
    {
        [Key]
        [RemoteAttribute("IsUserExist", "Users", ErrorMessage = "User Id Does not exist")]
        [Display(Name = "UserName")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public string UserPassword { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string CPwd { get; set; }
    }
}