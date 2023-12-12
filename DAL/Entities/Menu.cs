using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }
        public int DishCount { get; set; }
        public String Name { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
    }
}