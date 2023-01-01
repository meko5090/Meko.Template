using FluentValidation;
using Meko.Models.Request;

namespace Meko.Models.Validators;

public class PaginationValidator : AbstractValidator<PaginatedRequest>
{
    public PaginationValidator()
    {
        RuleFor(createListRequest => createListRequest.PageNo)
            .GreaterThan(0)
            .WithMessage("page should be 1 onwards");

        RuleFor(createListRequest => createListRequest.Size)
            .GreaterThanOrEqualTo(0)
            .WithMessage("size should not be negative")
            .LessThanOrEqualTo(100)
            .WithMessage("max size is 100");
    }
}
