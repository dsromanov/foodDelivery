using FluentValidation;
using FluentValidation.Results;

namespace foodDelivery.WebAPI.Models;

public class UpdateTypesRequest
{
    #region Model
    public string TypeOfFacility { get; set; }
    public string TypeOfFood { get; set; }

    #endregion

    #region Validator
    public class Validator : AbstractValidator<UpdateTypesRequest>
    {
        public Validator()
        {
            RuleFor(x => x.TypeOfFacility)
            .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.TypeOfFood)
            .MaximumLength(255).WithMessage("Length must be less than 256");
        }

    }
    #endregion
}
public static class UpdateTypesRequestExtension
{
    public static ValidationResult Validate(this UpdateTypesRequest model)
    {
        return new UpdateTypesRequest.Validator().Validate(model);
    }
}