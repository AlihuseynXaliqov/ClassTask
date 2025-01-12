using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TaskApp.Business.DTOs.Tag;

namespace TaskApp.Business.DTOs.Topic
{
    public class GetTopicDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
