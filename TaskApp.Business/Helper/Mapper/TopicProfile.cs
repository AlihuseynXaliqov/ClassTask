using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskApp.Business.DTOs.Topic;
using TaskApp.Core.Model;

namespace TaskApp.Business.Helper.Mapper
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            CreateMap<GetTopicDto, Topic>().ReverseMap();
            CreateMap<UpdateTopicDto, Topic>().ReverseMap();
            CreateMap<CreateTopicDto, Topic>().ReverseMap();
        }
    }
}
