using System.ComponentModel.DataAnnotations;

namespace Company.Marwan.PL.Dto
{
    public class ResetPasswordDto
    {


        [Required(ErrorMessage = "Password IS Required")]
        [DataType(DataType.Password)] // ******
        public string NewPassword{ get; set; }

        [Required(ErrorMessage = "confirmPassword IS Required")]
        [DataType(DataType.Password)] // ******
        [Compare(nameof(NewPassword), ErrorMessage = "confirm Passwrd does not match password")]
        public string confirmPassword { get; set; }



    }
}
