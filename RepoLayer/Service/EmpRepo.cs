using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RepoLayer.Service
{
    public class EmpRepo : IEmpRepo
    {
        //SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayroll;Integrated Security=True;Connect Timeout=180;Encrypt=False;");
        private readonly IConfiguration configuration; // Package 
        private readonly string ConnectionString;
        private readonly SqlConnection connection;
        public EmpRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConnectionString = this.configuration.GetConnectionString("EmployeePayroll_DbConnection");
            connection = new SqlConnection(ConnectionString);
            //connection = new SqlConnection(this.configuration.GetConnectionString("EmployeePayroll_DbConnection"));
        }

        //Add new Employee in Record
        public EmployeeModel AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("InsertEmp", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", employeeModel.EmployeeName);
                cmd.Parameters.AddWithValue("@ProfileImg", employeeModel.ProfileImg);
                cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);
                connection.Open();
                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    return employeeModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        //View All Employee
        public IEnumerable<EmployeeModel> GetAllEmployee() //IEnumerable We can access data one by one
        {

            try
            {
                List<EmployeeModel> listEmp = new List<EmployeeModel>();
                SqlCommand command = new SqlCommand("RetrieveAllEmp", connection);

                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EmployeeModel employeeModel = new EmployeeModel();

                    employeeModel.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    employeeModel.EmployeeName = reader["EmployeeName"].ToString();
                    employeeModel.ProfileImg = reader["ProfileImg"].ToString();
                    employeeModel.Gender = reader["Gender"].ToString();
                    employeeModel.Department = reader["Department"].ToString();
                    employeeModel.Salary = Convert.ToInt32(reader["Salary"]);
                    employeeModel.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    employeeModel.Notes = reader["Notes"].ToString();
                    listEmp.Add(employeeModel);
                }

                if (listEmp != null)
                {
                    return listEmp;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        //view Employee By ID
        public EmployeeModel GetEmployee(int? EmployeeId)
        {
            try
            {
                SqlCommand command = new SqlCommand("RetrieveEmp", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpId", EmployeeId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                EmployeeModel employeeModel = new EmployeeModel();

                while (reader.Read())
                {
                    employeeModel.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    employeeModel.EmployeeName = reader["EmployeeName"].ToString();
                    employeeModel.ProfileImg = reader["ProfileImg"].ToString();
                    employeeModel.Gender = reader["Gender"].ToString();
                    employeeModel.Department = reader["Department"].ToString();
                    employeeModel.Salary = Convert.ToInt32(reader["Salary"]);
                    employeeModel.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    employeeModel.Notes = reader["Notes"].ToString();
                }

                if (employeeModel != null)
                {
                    return employeeModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        // Update Employee Detail
        public EmployeeModel UpdateEmployee(EmployeeModel employeeModel)
        {

            try
            {
                SqlCommand command = new SqlCommand("UpdateEmp", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpId", employeeModel.EmployeeId);
                command.Parameters.AddWithValue("@Name", employeeModel.EmployeeName);
                command.Parameters.AddWithValue("@ProfileImg", employeeModel.ProfileImg);
                command.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                command.Parameters.AddWithValue("@Department", employeeModel.Department);
                command.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                command.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                command.Parameters.AddWithValue("@Notes", employeeModel.Notes);

                connection.Open();
                int rowAffected = command.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    return employeeModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        //Delete Employee Detail
        public string DeleteEmployee(int? employeeId)
        {
            try
            {
                SqlCommand command = new SqlCommand("DeleteEmp", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpId", employeeId);

                connection.Open();
                int rowAffected = command.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    return "Employee detail deleted";
                }
                else
                {
                    return "Employee detail not deleted";
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        //Login Employee
        public EmployeeModel LoginEmployee(LoginEmpModel model)
        {
            try
            {
                SqlCommand command = new SqlCommand("LoginEmp", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpId", model.EmployeeId);
                command.Parameters.AddWithValue("@Name", model.EmployeeName);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                EmployeeModel employee = new EmployeeModel();
                if (reader.Read())
                {
                    employee.EmployeeId = reader["EmployeeId"] == DBNull.Value ? default : reader.GetInt32("EmployeeId"); //It will check tha data from column if value is null it will return the default value.
                    employee.EmployeeName = reader["EmployeeName"] == DBNull.Value ? default : reader.GetString("EmployeeName");
                    employee.ProfileImg = reader["ProfileImg"] == DBNull.Value ? default : reader.GetString("ProfileImg");
                    employee.Gender = reader["Gender"] == DBNull.Value ? default : reader.GetString("Gender");
                    employee.Department = reader["Department"] == DBNull.Value ? default : reader.GetString("Department");
                    employee.Salary = reader["Salary"] == DBNull.Value ? default : reader.GetDecimal("Salary");
                    employee.StartDate = reader["StartDate"] == DBNull.Value ? default : reader.GetDateTime("StartDate");
                    employee.Notes = reader["Notes"] == DBNull.Value ? default : reader.GetString("Notes");                    
                }
                return employee;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
