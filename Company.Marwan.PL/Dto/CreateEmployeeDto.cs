using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Company.Marwan.PL.Views.Dto
{
    public class CreateEmployeeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required !!")]
        public string Name { get; set; }

        [Range(22,60,ErrorMessage ="Age Must be between 22 : 60")]
        public int? Age { get; set; }

        [DataType(DataType.EmailAddress,ErrorMessage ="Email is not valid")]
        public string Email { get; set; }

        
        public string Address { get; set; }
        [Phone]
        public string Phone { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        [DisplayName("Hiring Date")]
        public DateTime HiringDate { get; set; }
        [DisplayName("Date OF Creation")]

        public DateTime CreateAt { get; set; }
    }
}
