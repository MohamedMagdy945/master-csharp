using System.ComponentModel.DataAnnotations;

namespace ApiSrc.C_Validation
{
    public class UesrDTO
    {
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "name length should be between 3 and 50")]
        public string Name { get; set; }

        [Range(18, 100, ErrorMessage = "age must be between 18 and 100")]
        public int Age { get; set; }

        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
    }

    public class EvenNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is int intValue)
            {
                return intValue % 2 == 0;
            }
            return false;
        }
    }
    public class TestDto
    {
        [EvenNumber(ErrorMessage = "number should be even")]
        public int Number { get; set; }
    }
}
