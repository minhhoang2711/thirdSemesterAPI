using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thirdSemesterAPI.CustomModels;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Models.CustomerModel
{
    public class CustomerModel
    {
        private ProjectAptechIIIEntities2 data = new ProjectAptechIIIEntities2();

        // Xuất ra tất cả sản phẩm
        public List<CustomerEntity> GetAllCustomer()
        {
            try
            {
                return data.Customers.Select(p => new CustomerEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Address = p.Address,
                    Email = p.Email,
                    CategoryCustomerId = p.CategoryCustomerId.Value,
                    Password = p.Password
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Xuất ra khách hàng bằng id
        public CustomerEntity GetCustomerById(int id)
        {
            try
            {
                return data.Customers.Select(p => new CustomerEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Address = p.Address,
                    Email = p.Email,
                    CategoryCustomerId = p.CategoryCustomerId.Value,
                    Password = p.Password
                }).FirstOrDefault(p => p.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public CustomerClientEntity GetCustomerClientById(int id)
        {
            try
            {
                return data.Customers.Select(p => new CustomerClientEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Address = p.Address,
                    Email = p.Email,
                    CategoryCustomerId = p.CategoryCustomerId.Value,
                }).FirstOrDefault(p => p.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Xuất ra sản phẩm theo tên

        public List<CustomerEntity> GetCustomerByName(string name)
        {
            try
            {
                return data.Customers.Select(p => new CustomerEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Address = p.Address,
                    Email = p.Email,
                    CategoryCustomerId = p.CategoryCustomerId.Value, 
                    Password = p.Password
                }).Where(p => p.Name.Contains(name)).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<CustomerClientEntity> GetCustomerClientByName(string name)
        {
            try
            {
                return data.Customers.Select(p => new CustomerClientEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Address = p.Address,
                    Email = p.Email,
                    CategoryCustomerId = p.CategoryCustomerId.Value,
                }).Where(p => p.Name.Contains(name)).ToList();
            }
            catch
            {
                return null;
            }
        }

        // Xuất ra khách hàng theo email password
        public List<CustomerEntity> Authen(string email,string password)
        {
            try
            {
                return data.Customers.Select(p => new CustomerEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Address = p.Address,
                    Email = p.Email,
                    CategoryCustomerId = p.CategoryCustomerId.Value,
                    Password = p.Password
                }).Where(p => p.Name.Contains(email) && p.Password.Contains(password)).ToList();
            }
            catch
            {
                return null;
            }
        }

        public LoginResponse Login(LoginRequest login)
        {
            try
            {
                
                List<CustomerEntity> customers = data.Customers.Select(p => new CustomerEntity()
                {
                    Id = p.Id,
                    Email = p.Email,
                    Password = p.Password,
                    AddressId = p.Addresses.FirstOrDefault().Id,
                }).Where(p => p.Email.Equals(login.Email)).ToList();
                if (customers.Count() == 0) { return null; }
                if (BCrypt.Net.BCrypt.Verify(login.Password, customers[0].Password))
                {
                    return new LoginResponse
                    {
                        UserId = customers[0].Id,
                        AddressId = customers[0].AddressId
                    };
                } else
                {
                    return null;
                }
                    

            }
            catch
            {
                return null;
            }
        }

        //public bool Logout()
        //{
        //    var session = HttpContext.Current.Session;
        //    if (session["email"] != null)
        //    {
        //        session.Remove("email");
        //        return true;
        //    }
        //    return false;
        //}

        public bool AddNewCustomer(CustomerEntity p)
        {
            try
            {
                var encryptPw = BCrypt.Net.BCrypt.HashPassword(p.Password);
                var newCustomer = new Customer()
                {
                    Name = p.Name,
                    Phone = p.Phone,
                    Address = p.Address,
                    Email = p.Email,
                    CategoryCustomerId = p.CategoryCustomerId,
                    Password = encryptPw
                };
                data.Customers.Add(newCustomer);
                data.SaveChanges();
                if (newCustomer.Id != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("EXCEPTION: " + e);
                return false;
            }
        }

        public bool UpdateCustomerById(int id, CustomerEntity Customer)
        {
            try
            {
                var updateCustomer = data.Customers.Find(id);
                updateCustomer.Name = (Customer.Name != null) ? Customer.Name : updateCustomer.Name;
                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomerById(int id)
        {
            try
            {
                var updateCustomer = data.Customers.Find(id);
                data.Customers.Remove(updateCustomer);
                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}