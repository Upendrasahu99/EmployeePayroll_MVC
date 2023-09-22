using BusinessLayer.InterFace;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayroll_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmpBusiness empBusiness;

        public EmployeeController(IEmpBusiness empBusiness)
        {
            this.empBusiness = empBusiness;
        }

        // Get All Employee
        public IActionResult EmployeeList()
        {
            List<EmployeeModel> listEmp = new List<EmployeeModel>();
            listEmp = empBusiness.GetAllEmployee().ToList();
            return View(listEmp);
        }

        // Add Employee
        [HttpGet]
        public IActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmp([Bind] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                empBusiness.AddEmployee(employee);
                return RedirectToAction("EmployeeList");
            }
            return View(employee);
        }

        //Get EmployeeDetail
        public IActionResult Details()
        {
            int id = (int)HttpContext.Session.GetInt32("EmpId");
            EmployeeModel employee = empBusiness.GetEmployee(id);
            if (/*id != null && */employee != null)
            {
                return View(employee);
            }
            else
            {
                return NotFound();
            }
        }

        //Update Employee
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            EmployeeModel employee = empBusiness.GetEmployee(id);
            if (id != null && employee != null)
            {
                return View(employee);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                empBusiness.UpdateEmployee(employeeModel);
                return RedirectToAction("EmployeeList");
            }
            if (id != employeeModel.EmployeeId)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        //Delete Employee
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            EmployeeModel employee = empBusiness.GetEmployee(id);
            if (id != null && employee != null)
            {
                return View(employee);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id != null)
            {
                empBusiness.DeleteEmployee(id);
                return RedirectToAction("EmployeeList");
            }
            else
            {
                return NotFound();
            }
        }

        //Login Employee
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginEmpModel model)
        {
            try
            {
               if(ModelState.IsValid)
                {
                    var result = empBusiness.LoginEmployee(model);
                    if (result != null)
                    {
                        HttpContext.Session.SetInt32("EmpId", result.EmployeeId);
                        HttpContext.Session.SetString("EmpName", result.EmployeeName);
                        return RedirectToAction("Details");
                    }
                    return NotFound();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
