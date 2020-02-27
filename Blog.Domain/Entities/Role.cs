using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blog.Domain.Entities
{
    public abstract class Role
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter your name!")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 20 characters")]
        [RegularExpression(@"^[a-zA-ZА-яЁёІіЇїЄє]+$", ErrorMessage = "Invalid name")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

    }
}
