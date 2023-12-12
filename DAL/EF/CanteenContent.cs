using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class CanteenContent : DbContext
    {
        public System.Data.Entity.DbSet<Ingredient> Ingridients { get; set; }
        public System.Data.Entity.DbSet<Dish> Dishes { get; set; }
        public System.Data.Entity.DbSet<Menu> Menus { get; set; }

        public CanteenContent(DbContextOptions options) : base(options)
        {
            
        }
    }
}