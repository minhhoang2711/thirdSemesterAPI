using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thirdSemesterAPI.Models;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Models.ProductModel
{
    public class ProductModel
    {
        private ProjectAptechIIIEntities2 data = new ProjectAptechIIIEntities2();

        // Xuất ra tất cả sản phẩm
        public List<ProductEntity> GetAllProduct()
        {
            try
            {
                return data.Products.Select(p => new ProductEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.Value,
                    ManufactureDate = p.ManufactureDate.Value,
                    Description = p.Description,
                    Status = p.Status
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ProductClientEntity> GetAllProductForClient()
        {
            try
            {
                return data.Products.Select(p => new ProductClientEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.Value,
                    Description = p.Description,
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Xuất ra sản phẩm theo id sản phẩm 
        public ProductEntity GetProductById(int id)
        {
            try
            {
                return data.Products.Select(p => new ProductEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.Value,
                    ManufactureDate = p.ManufactureDate.Value,
                    Description = p.Description,
                    Status = p.Status
                }).FirstOrDefault(p => p.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ProductEntity> GetProductByName(string name)
        {
            try
            {
                return data.Products.Select(p => new ProductEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.Value,
                    ManufactureDate = p.ManufactureDate.Value,
                    Description = p.Description,
                    Status = p.Status
                }).Where(p => p.Name == name).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ProductClientEntity> GetProductByNameForClient(string name)
        {
            try
            {
                return data.Products.Select(p => new ProductClientEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.Value,
                    Description = p.Description,
                }).Where(p => p.Name == name).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ProductClientEntity GetProductByIdForClient(int id)
        {
            try
            {
                return data.Products.Select(p => new ProductClientEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.Value,
                    Description = p.Description
                }).FirstOrDefault(p => p.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        // Xuất ra sản phẩm theo giá sản phẩm
        public List<ProductEntity> GetProductByPrice(double minPrice, double maxPrice)
        {
            try
            {
                return data.Products.Where(p => (minPrice <= p.Price && p.Price <= maxPrice)).Select(p => new ProductEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.Value,
                    ManufactureDate = p.ManufactureDate.Value,
                    Description = p.Description,
                    Status = p.Status
                }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<ProductClientEntity> GetProductByPriceForClient(double minPrice, double maxPrice)
        {
            try
            {
                return data.Products.Where(p => (minPrice <= p.Price && p.Price <= maxPrice)).Select(p => new ProductClientEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.Value,
                    Description = p.Description
                }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool AddNewProduct(ProductEntity product)
        {
            try
            {
                var newProduct = new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ManufactureDate = product.ManufactureDate,
                    Description = product.Description,
                    Status = product.Status
                };
                data.Products.Add(newProduct);
                data.SaveChanges();
                if (newProduct.Id != 0)
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

        public bool UpdateProductById(int id, ProductEntity product)
        {
            try
            {
                var updateProduct = data.Products.Find(id);
                updateProduct.Name = (product.Name != null) ? product.Name : updateProduct.Name;
                updateProduct.Price = (product.Price != 0) ? product.Price : updateProduct.Price;
                updateProduct.ManufactureDate = (product.ManufactureDate != null) ? product.ManufactureDate : updateProduct.ManufactureDate;
                updateProduct.Description = (product.Description != null) ? product.Description : updateProduct.Description;
                updateProduct.Status = (product.Status != null) ? product.Status : updateProduct.Status;
                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProductById(int id)
        {
            try
            {
                var updateProduct = data.Products.Find(id);
                data.Products.Remove(updateProduct);
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