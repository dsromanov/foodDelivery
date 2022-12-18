using FluentValidation;
using FluentValidation.Results;

namespace foodDelivery.WebAPI.Models;

public class UpdateUserRequest
{
#region Model
public string Surname {get;set;}

#endregion

#region Validator
public class Validator: AbstractValidator<UpdateUserRequest>
{
public Validator()
{
RuleFor(x=>x.Surname)
.MaximumLength(255).WithMessage("Length must be less than 256");
}

}
#endregion
}
public static class UpdateUserRequestExtension
{
public static ValidationResult Validate(this UpdateUserRequest model)
{
return new UpdateUserRequest.Validator().Validate(model);
}
}