using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Office.Models
{
    public class WorkReport
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Project Name")]
        public int ProjectId { get; set; }
        [ValidateNever]
        public Project Project { get; set; }
        
        [Required]
        [DisplayName("Report Desciption")]
        public string ReportDesc { get; set; }

        [Required]
        [DisplayName("Project Name")]
        public int EmpId { get; set; }
        [ValidateNever]
        public Emp Emp { get; set; }

        [Required]
        [Display(Name ="Working Hours")]
        public int WorkingHour{ get; set; }
    }
}