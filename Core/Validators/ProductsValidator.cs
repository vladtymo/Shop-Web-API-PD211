using Core.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class ProductValidator : AbstractValidator<CreateProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Price)
                .GreaterThan(0);
            RuleFor(x => x.Discount)
                .InclusiveBetween(0, 100);
            RuleFor(x => x.Quantity)
               .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Description)
                .MaximumLength(5000);
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category is required.");
        }

        public bool ValidateUri(string? uri)
        {
            // just so the validation passes if the uri is not required / nullable
            if (string.IsNullOrEmpty(uri))
            {
                return true;
            }
            return Uri.TryCreate(uri, UriKind.Absolute, out _);
        }
    }
}
