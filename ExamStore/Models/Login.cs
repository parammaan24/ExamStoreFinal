using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamStore.Models
{
    public class Login
    {
        public int id { get; set; }

        [Display(Name = "Name")]
        public string Email { get; set; }


        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
