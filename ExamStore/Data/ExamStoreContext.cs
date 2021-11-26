using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamStore.Models;

namespace ExamStore.Data
{
    public class ExamStoreContext : DbContext
    {
        public ExamStoreContext (DbContextOptions<ExamStoreContext> options)
            : base(options)
        {
        }

        public DbSet<ExamStore.Models.Login> Login { get; set; }

        public DbSet<ExamStore.Models.BookStore> BookStore { get; set; }

        public DbSet<ExamStore.Models.Stock> Stock { get; set; }

        public DbSet<ExamStore.Models.Query> Query { get; set; }

        public DbSet<ExamStore.Models.OrderPlace> OrderPlace { get; set; }
    }
}
