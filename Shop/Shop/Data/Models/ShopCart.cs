using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;

        //подключение к БД
        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        //айди корзины
        public string ShopCartId { get; set; }

        //элементы корзины
        public List<ShopCartItem> listShopItems { get; set; }

        //функции, статик методы, чтобы их можно было вызывать из др классов
        //передаем сервисы тк с ними будем работать
        public static ShopCart GetCart(IServiceProvider services)
        {
            //когда пользователь выбирает товар, надо проверить, есть ли товары в корзине
            //если есть, то добавляем
            //если не добавлял, то создаем новую корзину(сессию)

            //создали какую-то новую сессию
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //получаем таблицы
            var context = services.GetService<AppDBContent>();

            //помешаем айди нашей корзины
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context)
            {
                ShopCartId = shopCartId
            };
        }

        //добавляем товары в корзину
        public void AddToCart(Car car)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                car = car,
                price = car.price
            });

            appDBContent.SaveChanges();
        }

        //отобразить товары в корзине
        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
