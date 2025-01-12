using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TaskApp.Business.DTOs.Tag;

namespace TaskApp.Business.DTOs.Topic
{
    public class UpdateTopicDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateTopicvalidator : AbstractValidator<UpdateTopicDto>
    {
        public UpdateTopicvalidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Namei duzgun yaz")
                .NotNull().WithMessage("Namei duzgun yaz")
                .MinimumLength(3).WithMessage("Namein uzunlugu en az 3 ola biler");
        }
    }
}

