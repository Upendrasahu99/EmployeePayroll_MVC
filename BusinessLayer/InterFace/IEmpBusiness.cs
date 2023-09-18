using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.InterFace
{
    public interface IEmpBusiness
    {
        public EmployeeModel AddEmployee(EmployeeModel employeeModel);
        public IEnumerable<EmployeeModel> GetAllEmployee();
        public EmployeeModel GetEmployee(int? EmployeeId);
        public EmployeeModel UpdateEmployee(EmployeeModel employeeModel);
        public string DeleteEmployee(int? employeeId);
    }
}
