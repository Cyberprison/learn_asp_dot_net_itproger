using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            //добавить категории в БД, но только если их там нет
            if (!content.Category.Any())
                {
                    content.Category.AddRange(Categories.Select(c => c.Value));
                }

            //добавим все объекты товаров(машины)
            //вторым способом добавляем
            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        name = "Tesla",
                        shortDesc = "",
                        longDesc = "",
                        img = "",
                        price = 2500000,
                        isFavourite = true,
                        available = true,
                        //categoryID = ,
                        Category = Categories["electro"] //пздц костыль
                    },
                    new Car
                    {
                        name = "Lada",
                        shortDesc = "",
                        longDesc = "",
                        img = "",
                        price = 150000,
                        isFavourite = false,
                        available = true,
                        //categoryID = ,
                        Category = Categories["classic"]
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
                //если пустой
                if(category == null)
                {
                    //то создаем категории, для БД
                    var list = new Category[]
                    {
                        new Category
                        {
                            categoryName = "electro",
                            desc = "modern type car"
                        },
                        new Category
                        {
                            categoryName = "classic",
                            desc = "best type transport"
                        }
                    };

                    //выделяем память
                    category = new Dictionary<string, Category>();

                    //в цикле перебераем и добавляем
                    foreach (Category el in list)
                    {
                        category.Add(el.categoryName, el);
                    }
                }

                return category;
            }
        }
    }
}
