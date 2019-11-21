using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Banking.Models
{
    public class tempUser
    {
        [Key]
        public short UserID { get; set; }
        [Display(Name = "LoginId")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public string UserPassword { get; set; }
        [NotMapped]
        [Compare("UserPassword", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string CPwd { get; set; }
        public string UserTransactionPassword { get; set; }
        public Nullable<short> RoleID { get; set; }
        public string UserPictureURL { get; set; }

    }
}