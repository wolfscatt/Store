using System.ComponentModel.DataAnnotations;

namespace Entities.Dto;


public record UserDtoForCreation : UserDto
{
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is Required")]
    public String? Password { get; init; }
}