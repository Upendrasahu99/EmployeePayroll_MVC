using BusinessLayer.InterFace;
using CommonLayer.Model;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class EmpBusiness : IEmpBusiness
    {
        private readonly IEmpRepo empRepo;

        public EmpBusiness(IEmpRepo empRepo)
        {
            this.empRepo = empRepo;
        }

        // Add New Employee
        public EmployeeModel AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                return empRepo.AddEmployee(employeeModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get All Employee
        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            try
            {
                return empRepo.GetAllEmployee();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Employee By Id
        public EmployeeModel GetEmployee(int? EmployeeId)
        {
            try
            {
                return empRepo.GetEmployee(EmployeeId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Update Employee
        public EmployeeModel UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                return empRepo.UpdateEmployee(employeeModel);
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Delete Employee
        public string DeleteEmployee(int? employeeId)
        {
            try
            {
                return empRepo.DeleteEmployee(employeeId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
