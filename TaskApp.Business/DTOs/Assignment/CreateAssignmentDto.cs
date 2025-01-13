using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Business.DTOs.Tag;

namespace TaskApp.Business.DTOs.Assignment
{
    public record CreateAssignmentDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }
    }
    public class CreateAssignmentValidator : AbstractValidator<CreateAssignmentDto>
    {
        public CreateAssignmentValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title duzgun yaz")
                .NotNull().WithMessage("Title duzgun yaz")
                .MinimumLength(10).WithMessage("Title uzunlugu en az 10 ola biler");
            RuleFor(x => x.Description)
               .NotEmpty().WithMessage("Description duzgun yaz")
               .NotNull().WithMessage("Description duzgun yaz")
               .MinimumLength(10).WithMessage("Description uzunlugu en az 10 ola biler");
        }
    }
}
