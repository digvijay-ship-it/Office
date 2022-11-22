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
        [DisplayName("Report Type")]
        public string ReportType { get; set; }
        [Required]
        [DisplayName("Report Desciption")]
        public string ReportDesc { get; set; }
        [Required]
        public int EmpId { get; set; }
        [ValidateNever]
        public Emp Emp { get; set; }
    }
}
