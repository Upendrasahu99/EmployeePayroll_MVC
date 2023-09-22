using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "{0} Should not be empty")]
        [RegularExpression(@"[A-Z][a-z]{2,}", ErrorMessage = "Enter Valid Name")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Choose one")]
        public string ProfileImg { get; set; }
        [Required(ErrorMessage = "Choose one")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "{0} Should not be empty")]
        [RegularExpression(@"[A-Z][a-z]{2}", ErrorMessage =  "Enter valid {0}")]
        public string Department { get; set; }
        [Required(ErrorMessage = "{0} Should not be empty")]
        [RegularExpression(@"[0-9]+.[0-9]{2}", ErrorMessage = "Enter valid data")]
        public decimal Salary { get; set; }
        [Required(ErrorMessage = "{0} Should not be empty")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "{0} Should not be empty")]
        public string Notes { get; set; }
    }
}
