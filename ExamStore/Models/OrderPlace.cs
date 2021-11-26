﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamStore.Models
{
    public class OrderPlace
    {

          public int id { get; set; }

        [Display(Name = " Name")]
        public string Name { get; set; }


        [Display(Name = "Book Title")]
        public string bookName { get; set; }


        [Display(Name = "Qty")]
        public int Qty { get; set; }


        [Display(Name = "Price")]
        public int Price { get; set; }



        [Display(Name = "Order Date")]
        public DateTime dTime { get; set; }



    }
}
