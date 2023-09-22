using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IEmpRepo
    {
        public EmployeeModel AddEmployee(EmployeeModel employeeModel);
        public IEnumerable<EmployeeModel> GetAllEmployee();
        public EmployeeModel GetEmployee(int? EmployeeId);
        public EmployeeModel UpdateEmployee(EmployeeModel employeeModel);
        public string DeleteEmployee(int? employeeId);
        public EmployeeModel LoginEmployee(LoginEmpModel model);
    }
}
