using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                //тк пока нет БД
                //то просто заполняем модели

                return new List<Category>
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
            }
        }
    }
}
