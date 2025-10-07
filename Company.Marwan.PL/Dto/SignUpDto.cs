using System.ComponentModel.DataAnnotations;

namespace Company.Marwan.PL.Dto
{
    public class SignUpDto
    {
        [Required(ErrorMessage ="UserName IS Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "FristName IS Required")]
        public string FristName { get; set;}

        [Required(ErrorMessage = "LastName IS Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email IS Required")]
        [EmailAddress]
        public string Email { get; set;}

        [Required(ErrorMessage = "Password IS Required")]
        [DataType(DataType.Password)] // ******
        public string Password { get; set;}

        [Required(ErrorMessage = "confirmPassword IS Required")]
        [DataType(DataType.Password)] // ******
        [Compare(nameof(Password),ErrorMessage ="confirm Passwrd does not match password")]
        public string confirmPassword { get; set; }

        public bool ISAgree { get; set; }

    }
}
