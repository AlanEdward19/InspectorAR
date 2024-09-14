using FluentValidation;

namespace InspectorAR.Product.UpdateProduct;

/// <summary>
/// Validator for the UpdateProductCommand.
/// </summary>
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    /// <summary>
    /// Validations for the UpdateProductCommand.
    /// </summary>
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't be empty.")
            .When(x => x.Name != null);
    }
}