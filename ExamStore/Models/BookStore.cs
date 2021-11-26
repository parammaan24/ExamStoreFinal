using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamStore.Models
{
    public class BookStore
    {
        public int id { get; set; }

        [Display(Name = "Book Title")]
        public string bookName { get; set; }


        [Display(Name = "Author Name")]
        public string authorName { get; set; }


        [Display(Name = "Published Year")]
        public string publishedYear { get; set; }


        [Display(Name = "Price")]
        public int Price { get; set; }





    }
}
