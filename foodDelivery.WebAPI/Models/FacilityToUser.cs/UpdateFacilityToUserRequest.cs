using FluentValidation;
using FluentValidation.Results;

namespace foodDelivery.WebAPI.Models;

public class UpdateFacilityToUserRequest
{
    #region Model
    public string IsFavourite { get; set; }
    public string MarkFromUser { get; set; }
    #endregion

    #region Validator
    public class Validator : AbstractValidator<UpdateFacilityToUserRequest>
    {
        public Validator()
        {
            RuleFor(x => x.IsFavourite)
            .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.MarkFromUser)
            .MaximumLength(255).WithMessage("Length must be less than 256");
        }

    }
    #endregion
}
public static class UpdateFacilityToUserRequestExtension
{
    public static ValidationResult Validate(this UpdateFacilityToUserRequest model)
    {
        return new UpdateFacilityToUserRequest.Validator().Validate(model);
    }
}