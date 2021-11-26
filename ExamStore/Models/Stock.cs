using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamStore.Models
{
    public class Stock
    {
        public int id { get; set; }

        [Display(Name = "Book Title")]
        public string bookName { get; set; }


        [Display(Name = "Qty")]
        public int Qty{ get; set; }

    }
}
