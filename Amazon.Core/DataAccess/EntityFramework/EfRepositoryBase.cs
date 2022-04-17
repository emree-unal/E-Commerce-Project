﻿using Amazon.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Amazon.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext:DbContext,new()

    {
        public TEntity Add(TEntity entity)
        {
            using (var dbContext = new TContext())
            {
                var addedEntity = dbContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                dbContext.SaveChanges();
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var dbContext = new TContext())
            {
                var deletedEntity = dbContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter=null)
        {
            using (var dbContext = new TContext())
            {

                return dbContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAllEntities(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var dbContext = new TContext())
            {

                return filter == null ? dbContext.Set<TEntity>().ToList()
                                    : dbContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var dbContext = new TContext())
            {
                var updatedEntity = dbContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
    }
}