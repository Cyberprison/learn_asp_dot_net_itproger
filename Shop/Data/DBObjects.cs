using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects
    {
        //все функции статические
        //чтобы из др классов к ним образаться только по имени

        public static void Initial(AppDBContent content)
        {
            //добавим все категории в БД, если их нет там
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        name = "tesla",
                        shortDesc = "",
                        longDesc = "",
                        img = "/img/tesla.jpg",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Электро"]
                    },
                    new Car
                    {
                        name = "lada",
                        shortDesc = "",
                        longDesc = "",
                        img = "/img/lada.jpg",
                        price = 5000,
                        isFavourite = false,
                        available = false,
                        Category = Categories["Бензо"]
                    }
                );
            }

            content.SaveChanges();

        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {   
                //если список пустой, то новый список и помещаем в него все элементы и выбираем те которые соответсвуют категории
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category
                        {
                            categoryName = "Электро",
                            desc = "Будущее"
                        },
                        new Category
                        {
                            categoryName = "Бензо",
                            desc = "Прошлое"
                        }
                    };
                    category = new Dictionary<string, Category>();

                    foreach(Category el in list)
                    {
                        category.Add(el.categoryName, el);
                    }
                }

                return category;
            }
        }
    }
}
