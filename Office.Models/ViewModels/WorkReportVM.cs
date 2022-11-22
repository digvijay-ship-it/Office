using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Office.Models.ViewModels
{
	public class WorkReportVM
	{
		public WorkReport WR { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> EmpList { get; set; }
	}
}
