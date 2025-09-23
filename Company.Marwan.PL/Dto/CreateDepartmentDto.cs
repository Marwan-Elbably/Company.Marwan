using System.ComponentModel.DataAnnotations;

namespace Company.Marwan.PL.Dto
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage ="Code is Required")]
        public string code { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string name { get; set; }

        [Required(ErrorMessage = "CreateAt is Required")]
        public DateTime CreateAt { get; set; }












    }
}
