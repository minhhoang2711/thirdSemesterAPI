using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Models.CategoryImageModel
{
    public class CategoryImageModel
    {
        private ProjectAptechIIIEntities2 data = new ProjectAptechIIIEntities2();

        //// Xuất ra tất cả sản phẩm
        //public List<CategoryImageEntity> GetAllCategoryImage()
        //{
        //    try
        //    {
        //        return data.CategoryImages.Select(p => new CategoryImageEntity()
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
                   
        //        }).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        ////Xuất ra sản phẩm theo id sản phẩm 
        //public CategoryImageEntity GetCategoryImageById(int id)
        //{
        //    try
        //    {
        //        return data.CategoryImages.Select(p => new CategoryImageEntity()
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
                    
        //        }).FirstOrDefault(p => p.Id == id);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //// Xuất ra sản phẩm theo giá sản phẩm
        //public List<CategoryImageEntity> GetCategoryImageByName(string name)
        //{
        //    try
        //    {
        //        return data.CategoryImages.Select(p => new CategoryImageEntity()
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
                    
        //        }).Where(p => p.Name.Contains(name)).ToList();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public bool AddNewCategoryImage(CategoryImageEntity p)
        //{
        //    try
        //    {
        //        var newCategoryImage = new CategoryImage()
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
                    
        //        };
        //        data.CategoryImages.Add(newCategoryImage);
        //        data.SaveChanges();
        //        if (newCategoryImage.Id != 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool UpdateCategoryImageById(int id, CategoryImageEntity CategoryImage)
        //{
        //    try
        //    {
        //        var updateCategoryImage = data.CategoryImages.Find(id);
        //        updateCategoryImage.Name = (CategoryImage.Name != null) ? CategoryImage.Name : updateCategoryImage.Name;
                

        //        data.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool DeleteCategoryImageById(int id)
        //{
        //    try
        //    {
        //        var updateCategoryImage = data.CategoryImages.Find(id);
        //        data.CategoryImages.Remove(updateCategoryImage);
        //        data.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}
    }
}