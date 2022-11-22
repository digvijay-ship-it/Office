using System.ComponentModel.DataAnnotations;

namespace Office.Models
{
    public class DepartmentRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
