using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRepository.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Book Name is required.")]
        [Display(Name = "Book Name")]
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Phone { get; set; }
    }
}
