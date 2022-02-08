using FluentValidation;

namespace Shopping.API.Data.ValueObjects
{
    public class ProductVO
    {
        public long Id { get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
        public bool Removed { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    public class ProductVOValidator : AbstractValidator<ProductVO>
    {
        public ProductVOValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                    .WithMessage($"The {nameof(ProductVO.Name)} field is required.")
                .NotEmpty()
                    .WithMessage($"The {nameof(ProductVO.Name)} field is required.")
                .Length(3, 200)
                    .WithMessage($"The {nameof(ProductVO.Name)} field must contains between 3 and 200 caracters.");

            RuleFor(x => x.Price)
                .NotNull()
                    .WithMessage($"The {nameof(ProductVO.Price)} field is required.")
                .GreaterThan(0)
                    .WithMessage($"The {nameof(ProductVO.Price)} field must greater than 0.00 and less than 1,000,000.00.")
                .ScalePrecision(2, 7)
                    .WithMessage($"The {nameof(ProductVO.Price)} field must greater than 0.00 and less than 1,000,000.00.");
            
            RuleFor(x => x.Description)
                .MaximumLength(1000)
                    .WithMessage($"The {nameof(ProductVO.Description)} field must less than 1000 caracters.");
        }
    }
}
