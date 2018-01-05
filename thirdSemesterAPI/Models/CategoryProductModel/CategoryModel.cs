using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thirdSemesterAPI.App_Start;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Models.CategoryModel
{
    public class CategoryModel
    {
        private ProjectAptechIIIEntities2 data = new ProjectAptechIIIEntities2();

        // Xuất ra tất cả sản phẩm
        public List<CategoryProductEntity> GetAllCategoryProduct()
        {
            try
            {
                return data.CategoryProducts.Select(p => new CategoryProductEntity()
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

        public List<ProductClientEntity> GetProductListByCategoryId(int id)
        {
            try
            {
                var res = data.Products.Join(
                    data.Images,
                    product => product.ImageId,
                    image => image.Id,
                    (product, image) => new
                    ProductClientEntity{
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price.Value,
                        ImageUrl = Custom.BASE_IMAGE_PATH + image.Name,
                        CategoryId = product.CategoryId
                    }
                )
                .Where(mergeItem => mergeItem.CategoryId == id).ToList();
                return res;
            } catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("EXCEPTION WHILE GET PRODUCT LIST OF CATEGORY" + id);
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
            
        }

        //Xuất ra sản phẩm theo id sản phẩm 
        public CategoryProductEntity GetCategoryProductById(int id)
        {
            try
            {
                return data.CategoryProducts.Select(p => new CategoryProductEntity()
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
        public List<CategoryProductEntity> GetCategoryProductByName(string name)
        {
            try
            {
                return data.CategoryProducts.Select(p => new CategoryProductEntity()
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

        public bool AddNewCategoryProduct(CategoryProductEntity p)
        {
            try
            {
                var newCategoryProduct = new CategoryProduct()
                {
                    Id = p.Id,
                    Name = p.Name,

                };
                data.CategoryProducts.Add(newCategoryProduct);
                data.SaveChanges();
                if (newCategoryProduct.Id != 0)
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

        public bool UpdateCategoryProductById(int id, CategoryProductEntity CategoryProduct)
        {
            try
            {
                var updateCategoryProduct = data.CategoryProducts.Find(id);
                updateCategoryProduct.Name = (CategoryProduct.Name != null) ? CategoryProduct.Name : updateCategoryProduct.Name;


                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategoryProductById(int id)
        {
            try
            {
                var updateCategoryProduct = data.CategoryProducts.Find(id);
                data.CategoryProducts.Remove(updateCategoryProduct);
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