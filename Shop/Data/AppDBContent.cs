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

        //получает и устанавливает товары в магазине
        public DbSet<Car> Car { get; set; }


        //получает категории
        public DbSet<Category> Category { get; set; }
    }
}
