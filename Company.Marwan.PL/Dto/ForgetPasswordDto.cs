using System.ComponentModel.DataAnnotations;

namespace Company.Marwan.PL.Dto
{
    public class ForgetPasswordDto
    {
        [Required(ErrorMessage = "Email IS Required")]
        [EmailAddress]
        public string Email { get; set; }



    }
}
