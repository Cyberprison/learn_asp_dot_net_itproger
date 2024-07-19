using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    //товар внутри корзины
    public class ShopCartItem
    {
        //айди
        public int id { get; set; }

        //модель машины
        public Car car { get; set; }

        //цена
        //было int
        public uint price { get; set; }

        //айди товара внутри корзины
        public string ShopCartId { get; set; }

    }
}
