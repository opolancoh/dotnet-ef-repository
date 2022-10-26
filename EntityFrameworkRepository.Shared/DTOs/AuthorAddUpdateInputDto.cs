using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EntityFrameworkRepository.Shared.DTOs;

public class AuthorAddUpdateInputDto : IValidatableObject
{
    [Required] public string Name { get; set; }

    [Required] public string Email { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!Regex.IsMatch(Name, "^[a-zA-Z ']*$"))
        {
            yield return new ValidationResult(
                $"The {nameof(Name)} field is invalid.", new[] {nameof(Name)});
        }

        if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            yield return new ValidationResult(
                $"The {nameof(Email)} field is invalid.", new[] {nameof(Email)});
        }
    }
}