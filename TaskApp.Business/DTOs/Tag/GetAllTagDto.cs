using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TaskApp.Business.DTOs.Tag
{
    public class GetAllTagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}