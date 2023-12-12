using System;
using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private CanteenContent db;
        private IngredientRepository _ingredientRepository;
        private DishRepository _dishRepository;
        private MenuRepository _menuRepository;

        public EFUnitOfWork(DbContextOptions options)
        {
            db = new CanteenContent(options);
        }
        public IRepository<Ingredient> Ingridients
        {
            get
            {
                if (_ingredientRepository == null)
                    _ingredientRepository = new IngredientRepository(db);
                return _ingredientRepository;
            }
        }
        public IRepository<Dish> Dishes
        {
            get
            {
                if (_dishRepository == null)
                    _dishRepository = new DishRepository(db);
                return _dishRepository;
            }
        }

        public IRepository<Menu> Menus
        {
            get
            {
                if (_menuRepository == null)
                    _menuRepository = new MenuRepository(db);
                return _menuRepository;
            }
        }

        public IDishRepository DishRepository => _unitOfWorkImplementation1.DishRepository;
        public IIngredientRepository IngredientRepository => _unitOfWorkImplementation1.IngredientRepository;
        public IMenuRepository MenuRepository => _unitOfWorkImplementation1.MenuRepository;

        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        private IUnitOfWork _unitOfWorkImplementation;
        private IUnitOfWork _unitOfWorkImplementation1;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
    }
}