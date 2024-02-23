using Domain.Entities;
using FluentValidation;

namespace Appication.Validations;

public class AuthorValidation : AbstractValidator<Author>
{
    public AuthorValidation()
    {
        RuleFor(a => a.Fullname).NotEmpty()
            .NotNull();

        RuleFor(a => a.Birthdate).NotEmpty()
            .NotNull()
            .Must(x => x < DateOnly.FromDateTime(DateTime.Now).AddYears(-5))
			.WithMessage("Author can't be at that age");
	}
}
