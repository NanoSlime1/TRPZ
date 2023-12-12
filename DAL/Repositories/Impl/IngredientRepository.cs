using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        internal IngredientRepository(CanteenContent context) : base (context)
        {
            
        }
    }
}