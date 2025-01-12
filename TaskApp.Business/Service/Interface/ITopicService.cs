using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Business.DTOs.Topic;

namespace TaskApp.Business.Service.Interface
{
    public interface ITopicService
    {
        Task<GetTopicDto> GetById(int id);
        IQueryable<GetTopicDto> GetAll();

        Task<CreateTopicDto> Create(CreateTopicDto dto);

        Task Update(UpdateTopicDto dto);
        Task Delete(int id);
    }
}
