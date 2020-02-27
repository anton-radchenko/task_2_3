using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public enum Gender
    {
        Undefined,
        Male,
        Female,
        Other
    }
    public class User : Role
    {
        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please enter your surname!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Surname must be between 2 and 20 characters")]
        [RegularExpression(@"^[a-zA-ZА-яЁёІіЇїЄє]+$", ErrorMessage = "Invalid name")]
        public string Surname { get; set; }

        [Display(Name = "Birth date")]
        [Required(ErrorMessage = "Please enter your birth date!")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please choose your gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please choose your gender")]
        public string Country { get; set; }

        public List<string> Languages { get; set; }

        
    }


}
