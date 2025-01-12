using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Business.DTOs.Tag;

namespace TaskApp.Business.Service.Interface
{
    public interface ITagService
    {
        public Task<CreateTagDto> CreateAsync(CreateTagDto dto);
        public Task<GetTagDto> GetById(int Id);

        public IQueryable<GetTagDto> GetAll();
        Task Update(UpdateTagDto dto);
        Task Delete(int Id);
    }
}
