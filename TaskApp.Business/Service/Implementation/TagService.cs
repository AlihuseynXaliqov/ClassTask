using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Business.DTOs.Tag;
using TaskApp.Business.Helper.Exception;
using TaskApp.Business.Service.Interface;
using TaskApp.Core.Model;
using TaskApp.DAL.Repo.Interface;

namespace TaskApp.Business.Service.Implementation
{
    public class TagService : ITagService
    {
        ITagRepository tagRepository;
        IMapper mapper;

        public TagService(IMapper mapper, ITagRepository tagRepository)
        {
            this.mapper = mapper;
            this.tagRepository = tagRepository;
        }

        public async Task<CreateTagDto> CreateAsync(CreateTagDto dto)
        {
            if(await tagRepository.IsExist(x=>x.Name == dto.Name))
            {
                throw new NotFoundException<Tag>("Hal hazirda bele tag var");
            }
            var tag = mapper.Map<Tag>(dto);
            var newTag = await tagRepository.CreateAsync(tag);
            await tagRepository.SaveChangesAsync();
            return mapper.Map<CreateTagDto>(newTag);
        }

        public async Task Delete(int Id)
        {
            var oldTag = await GetById(Id);
            var Tag = mapper.Map<Tag>(oldTag);
            tagRepository.Delete(Tag);
            await tagRepository.SaveChangesAsync();
        }

        public IQueryable<GetAllTagDto> GetAll()
        {
            var tagAll = tagRepository.GetAll();
            var tag = tagAll.Select(c => mapper.Map<GetAllTagDto>(c));
            return tag;
        }

        public async Task<GetTagDto> GetById(int Id)
        {
            if (Id <= 0) throw new NegativeIdException();
            var tag = await tagRepository.GetById(Id);
            var newTag = mapper.Map<GetTagDto>(tag);
            return newTag != null ? newTag : throw new NotFoundException<Tag>();
        }

        public async Task Update(UpdateTagDto dto)
        {
            var tag = await GetById(dto.Id);
            if((tag.Name==dto.Name)  || (await tagRepository.IsExist(x=>x.Name==dto.Name)))
            {
                throw new NotFoundException<Tag>("Hal hazirda bele tag var");
            }
            var  oldTag = mapper.Map<Tag>(dto);
            tagRepository.Update(oldTag);
            await tagRepository.SaveChangesAsync();
        }


    }
}
