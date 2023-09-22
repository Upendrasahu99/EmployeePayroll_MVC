using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class LoginEmpModel
    {
        [Required(ErrorMessage = "{0} Not be Empty")]
        [Range(1, double.MaxValue, ErrorMessage = "Enter Valid Data")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "{0} Should not be empty")]
        [RegularExpression(@"[A-Z][a-z]{2,}", ErrorMessage = "Enter Valid Name")]
        public string EmployeeName { get; set; }
    }
}
