using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Business.DTOs.Assignment;
using TaskApp.Business.DTOs.Tag;

namespace TaskApp.Business.Service.Interface
{
    public interface IAssignmentService
    {
        public Task<CreateAssignmentDto> CreateAsync(CreateAssignmentDto dto);
        public Task<GetAssignmentDto> GetById(int Id);

        public IQueryable<GetAssignmentDto> GetAll();
        Task Update(UpdateAssignmentDto dto);
        Task Delete(int Id);
    }
}
