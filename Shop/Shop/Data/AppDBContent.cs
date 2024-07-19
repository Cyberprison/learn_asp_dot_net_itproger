using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data
{
    //регистрируем какие таблицы будут в БД
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        //гет сет машины
        public DbSet<Car> Car{ get; set; }

        //гет сет категории
        public DbSet<Category> Category{ get; set; }

        //новая модель(таблица) элемент товара в корзине
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        
        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
