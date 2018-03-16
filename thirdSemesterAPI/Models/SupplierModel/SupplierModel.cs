using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Models.SupplierModel
{
    public class SupplierModel
    { 
        private ProjectAptechIIIEntities2 data = new ProjectAptechIIIEntities2();

        // Xuất ra tất cả sản phẩm
        public List<SupplierEntity> GetAllSupplier()
        {
            try
            {
                return data.Suppliers.Select(p => new SupplierEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Address = p.Address,
                    Website = p.Website
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Xuất ra sản phẩm theo id sản phẩm 
        public SupplierEntity GetSupplierById(int id)
        {
            try
            {
                return data.Suppliers.Select(p => new SupplierEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Address = p.Address,
                    Website = p.Website
                }).FirstOrDefault(p => p.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Xuất ra sản phẩm theo giá sản phẩm
        public List<SupplierEntity> GetSupplierByName(string name)
        {
            try
            {
                return data.Suppliers.Select(p => new SupplierEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Address = p.Address,
                    Website = p.Website
                }).Where(p => p.Name.Contains(name)).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool AddNewSupplier(SupplierEntity p)
        {
            try
            {
                var newSupplier = new Supplier()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Phone = p.Phone,
                    Address = p.Address,
                    Website = p.Website
                };
                data.Suppliers.Add(newSupplier);
                data.SaveChanges();
                if (newSupplier.Id != 0)
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

        public bool UpdateSupplierById(int id, SupplierEntity Supplier)
        {
            try
            {
                var updateSupplier = data.Suppliers.Find(id);
                updateSupplier.Name = (Supplier.Name != null) ? Supplier.Name : updateSupplier.Name;
                updateSupplier.Phone = (Supplier.Phone != null) ? Supplier.Phone : updateSupplier.Phone;
                updateSupplier.Address = (Supplier.Address != null) ? Supplier.Address : updateSupplier.Address;
                updateSupplier.Website = (Supplier.Website != null) ? Supplier.Website : updateSupplier.Website;

                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSupplierById(int id)
        {
            try
            {
                var updateSupplier = data.Suppliers.Find(id);
                data.Suppliers.Remove(updateSupplier);
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