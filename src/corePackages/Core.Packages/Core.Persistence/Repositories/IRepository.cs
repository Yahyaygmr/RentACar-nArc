﻿using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IRepository<TEntity, TEntityId> : IQuery<TEntity> 
        where TEntity : Entity<TEntityId>
    {
        TEntity Get(
           Expression<Func<TEntity, bool>> predicate,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
           bool withDeleted = false,
           bool enableTracking = true,
           CancellationToken cancellationToken = default);

        IPaginate<TEntity> GetList(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);

        IPaginate<TEntity> GetListByDynamic(
            DynamicQuery dynamic,
          Expression<Func<TEntity, bool>>? predicate = null,
          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
          int index = 0,
          int size = 10,
          bool withDeleted = false,
          bool enableTracking = true,
          CancellationToken cancellationToken = default);

        bool Any(
            Expression<Func<TEntity, bool>>? predicate = null,
             bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);
        TEntity Add(TEntity entity);
        ICollection<TEntity> AddRangeAsync(ICollection<TEntity> entity);
        TEntity UpdateAsync(TEntity entity);
        ICollection<TEntity> UpdateRangeAsync(ICollection<TEntity> entity);
        TEntity DeleteAsync(TEntity entity, bool permanent = false);
        ICollection<TEntity> DeleteRangeAsync(ICollection<TEntity> entity, bool permanent = false);
    }
}
