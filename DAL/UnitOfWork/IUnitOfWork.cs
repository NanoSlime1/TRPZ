using System;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDishRepository DishRepository { get; }
        IIngredientRepository IngredientRepository { get; }
        IMenuRepository MenuRepository { get; }
        void Save();
    }
}