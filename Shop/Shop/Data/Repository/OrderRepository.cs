using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        //переменные ссылающиеся на appDbContent
        //для добавления изменений в таблицы и сохранение их
        private readonly AppDBContent appDBContent;

        //работа с ShopCart
        private readonly ShopCart shopCart;

        //конструктор с установкой значений
        public OrderRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;

            //добавим заказ в таблицу
            appDBContent.Order.Add(order);

            //хранит все товары, который преобретает пользователь
            var items = shopCart.listShopItems;

            //товары необходимо описать как OrderDetail
            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarID = el.car.id,
                    orderID = order.id,
                    price = el.car.price
                };

                //после создания объекта, надо добавить его в БД
                appDBContent.OrderDetail.Add(orderDetail);
            }

            appDBContent.SaveChanges();
        }
    }
}
