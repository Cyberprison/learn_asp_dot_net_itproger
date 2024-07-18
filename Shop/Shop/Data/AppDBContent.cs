using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        //гет сет машины
        public DbSet<Car> Car{ get; set; }

        //гет сет категории
        public DbSet<Category> Category{ get; set; }
    }
}
