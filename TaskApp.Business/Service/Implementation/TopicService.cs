using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskApp.Business.DTOs.Topic;
using TaskApp.Business.Helper.Exception;
using TaskApp.Business.Service.Interface;
using TaskApp.Core.Model;
using TaskApp.DAL.Repo.Interface;

namespace TaskApp.Business.Service.Implementation
{
    public class TopicService : ITopicService
    {
        private readonly IMapper mapper;
        private readonly ITopicRepository repository;

        public TopicService(IMapper mapper, ITopicRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<CreateTopicDto> Create(CreateTopicDto dto)
        {
            if (await repository.IsExist(x => x.Name == dto.Name))
            {
                throw new NotFoundException<Topic>("hal hazirda bele topic var");
            }
            var topic = mapper.Map<Topic>(dto);
            await repository.CreateAsync(topic);
            await repository.SaveChangesAsync();
            return mapper.Map<CreateTopicDto>(topic);
        }

        public async Task Delete(int id)
        {
            if (id <= 0) throw new NegativeIdException();
            var topic = await GetById(id);
            var oldTopic= mapper.Map<Topic>(topic);
            repository.Delete(oldTopic);
            await repository.SaveChangesAsync();
        }

        public IQueryable<GetTopicDto> GetAll()
        {
            var topics = repository.GetAll();
            var topic = topics.Select(t => mapper.Map<GetTopicDto>(t));
            return topic;
        }

        public async Task<GetTopicDto> GetById(int id)
        {
            if (id <= 0) throw new NegativeIdException();
            var topic = await repository.GetById(id);
           var newTopic= mapper.Map<GetTopicDto>(topic);
            return newTopic != null ? newTopic : throw new NotFoundException<Topic>();

        }

        public async Task Update(UpdateTopicDto dto)
        {
           
            var topic = await GetById(dto.Id);
            if(topic.Name==dto.Name || await repository.IsExist(x => x.Name == dto.Name))
            {
                throw new NotFoundException<Topic>("hal hazirda bele topic var");
            }
            var newTopic= mapper.Map<Topic>(dto);
            repository.Update(newTopic);
            await repository.SaveChangesAsync();


        }
    }
}
