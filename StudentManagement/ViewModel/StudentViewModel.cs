using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel
{
    public class StudentViewModel 
    {

        [Required(ErrorMessage = "Please enter your surname")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Minimum of 3 character")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter your othername")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Minimum of 3 character")]
        public string OtherName { get; set; }

        [RegularExpression(@"[0-9]{4}[0-9]{3}[0-9]{4}", ErrorMessage = "Phone number should be in this format XXXX-XXX-XXXX")]
        [Required(ErrorMessage = "Please enter your phone number")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Please enter a valid Email address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Minimum of 5 character")]
        public string HomeAddress { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Minimum of 3 character")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your state")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Minimum of 3 character")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Input a passport")]
        public IFormFile Photo { get; set; }
    }
}
