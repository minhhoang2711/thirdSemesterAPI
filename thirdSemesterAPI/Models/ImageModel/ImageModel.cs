using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Models.ImageModel
{
    public class ImageModel
    {
        private ProjectAptechIIIEntities2 data = new ProjectAptechIIIEntities2();

        // Xuất ra tất cả sản phẩm
        public List<ImageEntity> GetAllImage()
        {
            try
            {
                return data.Images.Select(p => new ImageEntity()
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
        public ImageEntity GetImageById(int id)
        {
            try
            {
                return data.Images.Select(p => new ImageEntity()
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
        public List<ImageEntity> GetImageByName(string name)
        {
            try
            {
                return data.Images.Select(p => new ImageEntity()
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

        public int AddNewImage(ImageEntity p)
        {
            try
            {
                var newImage = new Image()
                {
                    Id = p.Id,
                    Name = p.Name,
                };
                data.Images.Add(newImage);
                data.SaveChanges();
                if (newImage.Id != 0)
                {
                    return newImage.Id;
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
        }

        public bool UpdateImageById(int id, ImageEntity Image)
        {
            try
            {
                var updateImage = data.Images.Find(id);
                updateImage.Name = (Image.Name != null) ? Image.Name : updateImage.Name;
                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteImageById(int id)
        {
            try
            {
                var updateImage = data.Images.Find(id);
                data.Images.Remove(updateImage);
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