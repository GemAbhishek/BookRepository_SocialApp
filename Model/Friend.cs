using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRepository.Model
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public string Location { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Phone { get; set; }
    }
}
