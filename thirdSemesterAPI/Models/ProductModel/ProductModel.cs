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
                    SupplierId = p.SupplierId,
                    CategoryId = p.CategoryId,
                    ImageId = p.ImageId,
                    ColorId = p.ColorId,
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

                var allRes = data.Products.Join(
                       data.ImageDetails,
                       product => product.Id,
                       detail => detail.ProductId,
                       (product, detail) => new { product, detail }
                )
                .Join(
                    data.Images,
                    combinedEntry => combinedEntry.detail.ImageId,
                    image => image.Id,
                    (combinedEntry, image) => new
                    {
                        Id = combinedEntry.product.Id,
                        Name = combinedEntry.product.Name,
                        Price = combinedEntry.product.Price,
                        ImageUrl = "./Content/Images" + image.Name
                    }
                )
                .GroupBy(fullEntry => fullEntry.Id)
                .Select(fullEntryGroupItem => new
                {

                });
                
                
                //return data.Products.Select(p => new ProductClientEntity()
                //{
                //    Id = p.Id,
                //    Name = p.Name,
                //    Price = p.Price.Value,
                //    CategoryId = p.CategoryId,  
                //    Description = p.Description,
                //    p.ImageDetails.
                //}).ToList();
                return null;
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
                    SupplierId = p.SupplierId,
                    CategoryId = p.CategoryId,
                    ImageId = p.ImageId,
                    ColorId = p.ColorId,
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
                    SupplierId = p.SupplierId,
                    CategoryId = p.CategoryId,
                    ImageId = p.ImageId,
                    ColorId = p.ColorId,
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
                    CategoryId = p.CategoryId,
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
                    CategoryId = p.CategoryId,
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
                    SupplierId = p.SupplierId,
                    CategoryId = p.CategoryId,
                    ImageId = p.ImageId,
                    ColorId = p.ColorId,
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
                    CategoryId = p.CategoryId,
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
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    ImageId = product.ImageId,
                    ColorId = product.ColorId,
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
                updateProduct.SupplierId = (product.SupplierId != 0) ? product.SupplierId : updateProduct.SupplierId;
                updateProduct.CategoryId = (product.CategoryId != 0) ? product.CategoryId : updateProduct.CategoryId;
                updateProduct.ImageId = (product.ImageId != 0) ? product.ImageId : updateProduct.ImageId;
                updateProduct.ColorId = (product.ColorId != 0) ? product.ColorId : updateProduct.ColorId;
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