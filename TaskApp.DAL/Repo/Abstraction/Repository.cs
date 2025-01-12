using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Model.Base;
using TaskApp.DAL.Context;
using TaskApp.DAL.Repo.Interface;

namespace TaskApp.DAL.Repo.Abstraction
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Table.Where(x => !x.IsDeleted);
        }
        public async Task<TEntity> GetById(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

       public void Update(TEntity entity)
        {
            Table.Update(entity);

        }

       
        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            Table.Update(entity);
        }

        


    }
}
