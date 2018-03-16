using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Models.CategoryCustomerModel
{
    public class CategoryCustomerModel
    {
        private ProjectAptechIIIEntities2 data = new ProjectAptechIIIEntities2();

        // Xuất ra tất cả sản phẩm
        public List<CategoryCustomerEntity> GetAllCategoryCustomer()
        {
            try
            {
                return data.CategoryCustomers.Select(p => new CategoryCustomerEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Xuất ra sản phẩm theo id sản phẩm 
        public CategoryCustomerEntity GetCategoryCustomerById(int id)
        {
            try
            {
                return data.CategoryCustomers.Select(p => new CategoryCustomerEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                }).FirstOrDefault(p => p.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Xuất ra sản phẩm theo giá sản phẩm
        public List<CategoryCustomerEntity> GetCategoryCustomerByName(string name)
        {
            try
            {
                return data.CategoryCustomers.Select(p => new CategoryCustomerEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                }).Where(p => p.Name.Contains(name)).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool AddNewCategoryCustomer(CategoryCustomerEntity p)
        {
            try
            {
                var newCategoryCustomer = new CategoryCustomer()
                {
                    Id = p.Id,
                    Name = p.Name,
                };
                data.CategoryCustomers.Add(newCategoryCustomer);
                data.SaveChanges();
                if (newCategoryCustomer.Id != 0)
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

        public bool UpdateCategoryCustomerById(int id, CategoryCustomerEntity CategoryCustomer)
        {
            try
            {
                var updateCategoryCustomer = data.CategoryCustomers.Find(id);
                updateCategoryCustomer.Name = (CategoryCustomer.Name != null) ? CategoryCustomer.Name : updateCategoryCustomer.Name;
                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategoryCustomerById(int id)
        {
            try
            {
                var updateCategoryCustomer = data.CategoryCustomers.Find(id);
                data.CategoryCustomers.Remove(updateCategoryCustomer);
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