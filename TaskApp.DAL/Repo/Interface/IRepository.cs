using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Model.Base;

namespace TaskApp.DAL.Repo.Interface
{
    public interface IRepository<TEntity> where TEntity : BaseEntity,new ()
    {
        DbSet<TEntity> Table { get; }
        Task<TEntity> CreateAsync(TEntity entity);


        Task<TEntity> GetById(int id);
        IQueryable<TEntity> GetAll(params string[] includes);

        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<int> SaveChangesAsync();
        public Task<bool> IsExist(Expression<Func<TEntity, bool>> expression);
    }
}
