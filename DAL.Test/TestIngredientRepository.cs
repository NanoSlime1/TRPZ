using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace DAL.Test
{
    public class TestIngredientRepository : BaseRepository<Ingredient>
    {
        public TestIngredientRepository(DbContext context) : base(context)
        {
        }
    }
}