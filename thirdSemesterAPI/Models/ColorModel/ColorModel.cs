using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Models.ColorModel
{
    public class ColorModel
    {
        private ProjectAptechIIIEntities2 data = new ProjectAptechIIIEntities2();

        // Xuất ra tất cả sản phẩm
        public List<ColorEntity> GetAllColor()
        {
            try
            {
                return data.Colors.Select(p => new ColorEntity()
                {
                    Id = p.Id,
                    NameByColorName = p.NameByColorName,
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Xuất ra sản phẩm theo id sản phẩm 
        public ColorEntity GetColorById(int id)
        {
            try
            {
                return data.Colors.Select(p => new ColorEntity()
                {
                    Id = p.Id,
                    NameByColorName = p.NameByColorName,                   
                }).FirstOrDefault(p => p.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Xuất ra sản phẩm theo giá sản phẩm
        public List<ColorEntity> GetColorByName(string name)
        {
            try
            {
                return data.Colors.Select(p => new ColorEntity()
                {
                    Id = p.Id,
                    NameByColorName = p.NameByColorName,
                }).Where(p => p.NameByColorName.Contains(name)).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool AddNewColor(ColorEntity p)
        {
            try
            {
                var newColor = new Color()
                {
                    Id = p.Id,
                    NameByColorName = p.NameByColorName,
                };
                data.Colors.Add(newColor);
                data.SaveChanges();
                if (newColor.Id != 0)
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

        public bool UpdateColorById(int id, ColorEntity Color)
        {
            try
            {
                var updateColor = data.Colors.Find(id);
                updateColor.NameByColorName = (Color.NameByColorName != null) ? Color.NameByColorName : updateColor.NameByColorName;
                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteColorById(int id)
        {
            try
            {
                var updateColor = data.Colors.Find(id);
                data.Colors.Remove(updateColor);
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