using System.ComponentModel.DataAnnotations;

namespace Company.Marwan.PL.Dto
{
    public class SignInDto
    {


        [Required(ErrorMessage = "Email IS Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password IS Required")]
        [DataType(DataType.Password)] // ******
        public string Password { get; set; }

        public bool Rememberme { get; set; }

    }
}
