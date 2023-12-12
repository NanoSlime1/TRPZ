using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public int Count { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
    }
}