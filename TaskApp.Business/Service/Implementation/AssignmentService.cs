using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Business.DTOs.Assignment;
using TaskApp.Business.DTOs.Tag;
using TaskApp.Business.Helper.Exception;
using TaskApp.Business.Service.Interface;
using TaskApp.Core.Model;
using TaskApp.DAL.Repo.Abstraction;
using TaskApp.DAL.Repo.Interface;

namespace TaskApp.Business.Service.Implementation
{
    public class AssignmentService:IAssignmentService
    {
        private readonly IAssignmentRepository repository;
        private readonly IMapper mapper;

        public AssignmentService(IAssignmentRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreateAssignmentDto> CreateAsync(CreateAssignmentDto dto)
        {
           
            var assignment = mapper.Map<Assignment>(dto);
            var newAssigment = await repository.CreateAsync(assignment);
            await repository.SaveChangesAsync();
            return mapper.Map<CreateAssignmentDto>(newAssigment);
        }

        public async Task Delete(int Id)
        {
            var oldAssignment = await GetById(Id);
            var assignment = mapper.Map<Assignment>(oldAssignment);
            repository.Delete(assignment);
            await repository.SaveChangesAsync();
        }

        public IQueryable<GetAssignmentDto> GetAll()
        {
            var tagAll = repository.GetAll();
            var tag = tagAll.Select(c => mapper.Map<GetAssignmentDto>(c));
            return tag;
        }

        public async Task<GetAssignmentDto> GetById(int Id)
        {
            if (Id <= 0) throw new NegativeIdException();
            var assignment = await repository.GetById(Id);
            var newAssignment = mapper.Map<GetAssignmentDto>(assignment);
            return newAssignment != null ? newAssignment : throw new NotFoundException<Tag>();
        }

        public async Task Update(UpdateAssignmentDto dto)
        {
            var assignment = await GetById(dto.Id);

            var oldAssignment = mapper.Map<Assignment>(dto);
            repository.Update(oldAssignment);
            await repository.SaveChangesAsync();
        }



    }
}
