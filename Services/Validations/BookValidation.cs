using Domain.Entities;
using FluentValidation;

namespace Appication.Validations;

public class BookValidation : AbstractValidator<Book>
{
    public BookValidation()
    {
        RuleFor(book => book.Name)
            .NotEmpty()
            .MaximumLength(100)
            .MinimumLength(2)
            .WithMessage("This field must be filled");

        RuleFor(book => book.PublishDate).NotEmpty()
            .NotNull().Must(x => x < DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("Date can't be published just before");
    }
}
