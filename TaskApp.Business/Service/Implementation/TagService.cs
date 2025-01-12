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

        public IQueryable<GetTagDto> GetAll()
        {
            var tagAll = tagRepository.GetAll();
            var tag = tagAll.Select(c => mapper.Map<GetTagDto>(c));
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
/*            var oldTag = await GetById(dto.Id);*/
          var  oldTag = mapper.Map<GetTagDto>(dto);
            tagRepository.Update(mapper.Map<Tag>(oldTag));
            await tagRepository.SaveChangesAsync();
        }


    }
}
