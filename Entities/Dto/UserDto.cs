using System.ComponentModel.DataAnnotations;

namespace Entities.Dto;


public record UserDto
{
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "UserName is Required")]
    public String? UserName { get; init; }

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is Required")]
    public String? Email { get; init; }

    [DataType(DataType.PhoneNumber)]
    public String? PhoneNumber { get; init; }
    public HashSet<String> Roles { get; set; } = new HashSet<String>();
}