using CleanArchitecture.API.Enumerations;
using CleanArchitecture.API.Resources;
using CleanArchitecture.Business.DTOs;
using FluentValidation;
using System.Net;

namespace CleanArchitecture.API.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidator()
        {
            Include(new AddEmployeeValidator());
            RuleFor(e => e.Id)
                .GreaterThan(0)
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage(Messages.InvalidId);
        }
    }
    public class AddEmployeeValidator : AbstractValidator<AddEmployeeDTO>
    {
        public AddEmployeeValidator()
        {
            RuleFor(e => e.Age)
                .InclusiveBetween(14, 67)
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage(Messages.InvalidAge);

            RuleFor(e => e.Gender)
                .IsEnumName(typeof(GenderEnum), false)
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage(Messages.InvalidGender);
        }
    }
}
