using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thirdSemesterAPI.Models;
using thirdSemesterAPI.Models.Entity;
using thirdSemesterAPI.Security;

namespace thirdSemesterAPI.Models.EmployeeModel
{
    public class EmployeeModel
    {
        private ProjectAptechIIIEntities2 data = new ProjectAptechIIIEntities2();

        // Xuất ra tất cả sản phẩm
        public List<EmployeeEntity> GetAllEmployee()
        {
            try
            {
                return data.Employees.Select(p => new EmployeeEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Email = p.Email,
                    Address = p.Address,
                    Password = p.Password
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Xuất ra sản phẩm theo id sản phẩm 
        public EmployeeEntity GetEmployeeById(int id)
        {
            try
            {
                return data.Employees.Select(p => new EmployeeEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Email = p.Email,
                    Address = p.Address,
                }).FirstOrDefault(p => p.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Xuất ra sản phẩm theo giá sản phẩm
        public List<EmployeeEntity> GetEmployeeByName(string name)
        {
            try
            {
                return data.Employees.Select(p => new EmployeeEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Email = p.Email,
                    Address = p.Address,
                }).Where(p => p.Name.Contains(name)).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool AddNewEmployee(EmployeeEntity p)
        {
            try
            {
                var encryptedPw = BCrypt.Net.BCrypt.HashPassword(p.Password);
                var newEmployee = new Employee()
                {
                    Name = p.Name,
                    EmployDate = DateTime.Now,
                    Phone = p.Phone,
                    Email = p.Email,
                    Address = p.Address,
                    Password = encryptedPw
                };
                data.Employees.Add(newEmployee);
                data.SaveChanges();
                if (newEmployee.Id != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateEmployeeById(int id, EmployeeEntity employee)
        {
            try
            {
                var updateEmployee = data.Employees.Find(id);
                updateEmployee.Name = (employee.Name != null) ? employee.Name : updateEmployee.Name;
                updateEmployee.Phone = (employee.Phone != null) ? employee.Phone : updateEmployee.Phone;
                updateEmployee.Email = (employee.Email != null) ? employee.Email : updateEmployee.Email;
                updateEmployee.Address = (employee.Address != null) ? employee.Address : updateEmployee.Address;
                updateEmployee.Password = (employee.Password != null) ? employee.Password : updateEmployee.Password;
                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteEmployeeById(int id)
        {
            try
            {
                var updateEmployee = data.Employees.Find(id);
                data.Employees.Remove(updateEmployee);
                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public int Login(LoginRequest login)
        {
            try
            {
                var encryptedPw = BCrypt.Net.BCrypt.HashPassword(login.Password);
                List<EmployeeEntity> employees = data.Employees.Select(p => new EmployeeEntity()
                {
                    Id = p.Id,
                    Email = p.Email,
                    Password = p.Password
                    
                }).Where(p => p.Email.Equals(login.Email)).ToList();
                if (BCrypt.Net.BCrypt.Verify(login.Password, employees[0].Password))
                {
                    return employees[0].Id;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR " + e);
                return 0;
            }
        }
    }
}