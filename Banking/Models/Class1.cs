using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banking.Models
{
    public class Class1
    {
        [Key]
        public String UserID { get; set; }
        public string UserName { get; set; }
             public string UserPassword
        {
            get; set;

        }
        public string UserTransactionPassword
        {
            get; set;

        }
    }
    }
