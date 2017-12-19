using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Models.NewsModel
{
    public class NewsModel
    {
        private ProjectAptechIIIEntities2 data = new ProjectAptechIIIEntities2();

        // Xuất ra tất cả sản phẩm
        public List<NewsEntity> GetAllNews()
        {
            try
            {
                return data.News.Select(p => new NewsEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ContentNews = p.ContentNews,
                    ImageId = p.ImageId.Value,
                    PostDate = p.PostDate.Value
                }).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //Xuất ra sản phẩm theo id sản phẩm 
        public NewsEntity GetNewsById(int id)
        {
            try
            {
                return data.News.Select(p => new NewsEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ContentNews = p.ContentNews,
                    ImageId = p.ImageId.Value,
                    PostDate = p.PostDate.Value
                }).FirstOrDefault(p => p.Id == id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // Xuất ra sản phẩm theo giá sản phẩm
        public List<NewsEntity> GetNewsByName(string name)
        {
            try
            {
                return data.News.Select(p => new NewsEntity()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ContentNews = p.ContentNews,
                    ImageId = p.ImageId.Value,
                    PostDate = p.PostDate.Value
                }).Where(p => p.Name.Contains(name)).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool AddNewNews(NewsEntity p)
        {
            try
            {
                var newNews = new News()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ContentNews = p.ContentNews,
                    ImageId = p.ImageId,
                    PostDate = p.PostDate
                };
                data.News.Add(newNews);
                data.SaveChanges();
                if (newNews.Id != 0)
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

        public bool UpdateNewsById(int id, NewsEntity News)
        {
            try
            {
                var updateNews = data.News.Find(id);
                updateNews.Name = (News.Name != null) ? News.Name : updateNews.Name;
                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteNewsById(int id)
        {
            try
            {
                var updateNews = data.News.Find(id);
                data.News.Remove(updateNews);
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