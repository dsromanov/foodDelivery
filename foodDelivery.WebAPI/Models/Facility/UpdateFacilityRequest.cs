using FluentValidation;
using FluentValidation.Results;

namespace foodDelivery.WebAPI.Models;

public class UpdateFacilityRequest
{
    #region Model
    public string Name { get; set; }
    public string Rating { get; set; }

    #endregion

    #region Validator
    public class Validator : AbstractValidator<UpdateFacilityRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Name)
            .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.Rating)
            .MaximumLength(255).WithMessage("Length must be less than 256");
        }

    }
    #endregion
}
public static class UpdateFacilityRequestExtension
{
    public static ValidationResult Validate(this UpdateFacilityRequest model)
    {
        return new UpdateFacilityRequest.Validator().Validate(model);
    }
}