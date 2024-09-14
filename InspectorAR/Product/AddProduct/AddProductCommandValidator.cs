using FluentValidation;

namespace InspectorAR.Product.AddProduct;

/// <summary>
/// Validator for AddProductCommand.
/// </summary>
public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    /// <summary>
    /// Validation rules for AddProductCommand.
    /// </summary>
    public AddProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Name is required.");
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't be empty.");
        
        RuleFor(x => x.Information)
            .NotNull()
            .WithMessage("Information is required.");
    }
}