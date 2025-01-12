using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Model.Base;

namespace TaskApp.DAL.Repo.Interface
{
    public interface IRepository<TEntity> where TEntity : BaseEntity,new ()
    {
        DbSet<TEntity> Table { get; }
        Task<TEntity> CreateAsync(TEntity entity);

        Task<int> SaveChangesAsync();

        Task<TEntity> GetById(int id);
        IQueryable<TEntity> GetAll();

        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
