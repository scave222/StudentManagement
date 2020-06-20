using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StudentManagement.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the StudentManagementUser class
    public class StudentManagementUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")] //database table datatype
        public string Surname { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Othernames { get; set; }
    }
}
