using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Dish
    {
        public int DishId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int CountOfIngridient { get; set; }
        public IEnumerable<Ingredient> Ingridients { get; set; }
    }
}