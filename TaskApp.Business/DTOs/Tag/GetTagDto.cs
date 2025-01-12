using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TaskApp.Business.DTOs.Tag
{
    public record GetTagDto
    {
        public string Name { get; set; }
    }
    public class GetTagvalidator : AbstractValidator<GetTagDto>
    {
        public GetTagvalidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Namei duzgun yaz")
                .NotNull().WithMessage("Namei duzgun yaz")
                .MinimumLength(3).WithMessage("Namein uzunlugu en az 3 ola biler");
        }
    }
}
