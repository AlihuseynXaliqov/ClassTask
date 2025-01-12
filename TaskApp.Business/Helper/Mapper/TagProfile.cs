using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Business.DTOs.Tag;
using TaskApp.Core.Model;

namespace TaskApp.Business.Helper.Mapper
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<CreateTagDto, Tag>().ReverseMap();

            CreateMap<UpdateTagDto, GetTagDto>().ReverseMap();
            CreateMap<GetTagDto, Tag>().ReverseMap();
        }

    }
}
