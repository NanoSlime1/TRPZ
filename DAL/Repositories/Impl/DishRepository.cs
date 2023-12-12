using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl
{
    public class DishRepository : BaseRepository<Dish>, IDishRepository
    {
        internal DishRepository(CanteenContent context) : base (context)
        {
            
        }
    }
}