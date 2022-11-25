using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="User Role")]
        [Required]
        public string UserRoleType { get; set; }
    }
}
