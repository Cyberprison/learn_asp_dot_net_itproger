using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        //подключение к созданию заказа
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        //конструктор с установкой значений
        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        //функция возвращает представление и действие
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            //товары из корзины в список
            shopCart.listShopItems = shopCart.getShopItems();

            if(shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Zero products select");
            }

            if(ModelState.IsValid == true)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Coplete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Thx for order";
            return View();
        }
    }
}
