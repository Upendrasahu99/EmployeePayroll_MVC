using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string ProfileImg { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
    }
}
