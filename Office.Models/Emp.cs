using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Office.Models
{
    public class Emp
    {
        public int Id { get; set; }

        [ValidateNever]
        public string ImgUrl { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [Display(Name= "DepartmentRole")]
        public int DepartmentRoleId { get; set; }
        [ValidateNever]
        public DepartmentRole DepartmentRole { get; set; }

        [Required]
        [Display(Name = "User Role")]
        public int UserRoleId{ get; set; }
        [ValidateNever]
        public UserRole UserRole { get; set; }

        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string state { get; set; }

        [Required]
        public long MobileNum { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}
