using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages
{
        public class Context : DbContext
        {
            //public Context(DbContextOptions options) : base(options) { }
            public DbSet<PamModel> PamModels { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite(@"Data Source=database.db");
    }
}
