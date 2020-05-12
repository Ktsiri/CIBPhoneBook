using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CIBPhonebook.Domain.DomainObjects.Base;
using CIBPhonebook.Domain.EF.DomainContexts;
using CIBPhonebook.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CIBPhonebook.Domain.EF.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : DomainObject
    {
        private readonly DomainContext Context;
        public Repository(DomainContext context)
        {
            this.Context = context;
        }

        public async Task<TEntity> GetById(int id) => await Context.Set<TEntity>().FindAsync(id);

        public Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
            => Context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public async Task Add(TEntity entity)
        {
            // await Context.AddAsync(entity);
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public Task Update(TEntity entity)
        {
            // In case AsNoTracking is used
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public Task Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => Context.Set<TEntity>().CountAsync();

        public Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate)
            => Context.Set<TEntity>().CountAsync(predicate);
    }
}
