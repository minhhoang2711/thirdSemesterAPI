using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                    CategoryCustomerId = p.CategoryCustomerId.Value
                }).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //Xuất ra sản phẩm theo id sản phẩm 
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
                    CategoryCustomerId = p.CategoryCustomerId.Value
                }).FirstOrDefault(p => p.Id == id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // Xuất ra sản phẩm theo giá sản phẩm
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
                    CategoryCustomerId = p.CategoryCustomerId.Value
                }).Where(p => p.Name.Contains(name)).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool AddNewCustomer(CustomerEntity p)
        {
            try
            {
                var newCustomer = new Customer()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Address = p.Address,
                    Email = p.Email,
                    CategoryCustomerId = p.CategoryCustomerId
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
            catch
            {
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