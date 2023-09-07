﻿using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Repositories;
using RealEstate.Core.Services;
using RealEstate.Core.UnitOfWork;
using System.Linq.Expressions;

namespace NLayer.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IGenericRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}