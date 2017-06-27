using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Navicon.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter customer's surname.")]
        [StringLength(100)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter customer's patronymic.")]
        [StringLength(100)]
        public string Patronymic { get; set; }
        [Required(ErrorMessage = "Please enter customer's sex.")]
        [StringLength(10)]
        public string Sex { get; set; }
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please enter customer's date of birth.")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Please enter customer's date of age.")]
        //[RegularExpression(@"")]
        public int Age { get; set; }
        public int Id { get; set; }
        [StringLength(400)]
        public string Description { get; set; }

        
    }
}