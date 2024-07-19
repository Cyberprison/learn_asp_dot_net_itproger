namespace Shop.Data.Models
{
    //описание каждого товара, который преобретается
    public class OrderDetail
    {
        public int id { get; set; }

        public int orderID{ get; set; }

        public int CarID { get; set; }

        public uint price { get; set; }

        //связывают с объектом товара(Car) и заказа(Order) для БД
        public virtual Car car { get; set; }

        public virtual Order order{ get; set; }
        
    }
}