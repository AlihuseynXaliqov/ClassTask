using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<TEntity> GetAll(params string[] includes)
        {
            var query = Table.Where(x => !x.IsDeleted);
            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }
        public async Task<TEntity> GetById(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id&&!x.IsDeleted);
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


        public async Task<bool> IsExist(Expression<Func<TEntity, bool>> expression)
        {
            return await Table.AsNoTracking().AnyAsync(expression);
        }

    }
}
