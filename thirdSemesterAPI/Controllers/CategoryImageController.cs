using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using thirdSemesterAPI.Models.CategoryImageModel;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Controllers
{
    [RoutePrefix("api/CategoryImage")]
    public class CategoryImageController : ApiController
    {

        //private CategoryImageModel categoryImageModel = new CategoryImageModel();

        //[HttpGet]
        //[Route("findall")]
        //public HttpResponseMessage GetAllCategoryImage()
        //{
        //    try
        //    {
        //        var response = new HttpResponseMessage(HttpStatusCode.OK);
        //        response.Content = new StringContent(JsonConvert.SerializeObject(categoryImageModel.GetAllCategoryImage()));
        //        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //        return response;
        //    }
        //    catch
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.BadRequest);
        //    }
        //}

        //[HttpGet]
        //[Route("getCategoryImagebyid/{id}")]
        //public HttpResponseMessage GetCategoryImageById(int id)
        //{
        //    try
        //    {
        //        if (categoryImageModel.GetCategoryImageById(id) != null)
        //        {
        //            var response = new HttpResponseMessage(HttpStatusCode.OK);
        //            response.Content = new StringContent(JsonConvert.SerializeObject(categoryImageModel.GetCategoryImageById(id)));
        //            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //            return response;
        //        }
        //        else
        //        {
        //            return new HttpResponseMessage(HttpStatusCode.NotFound);
        //        }
        //    }
        //    catch
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.BadRequest);
        //    }
        //}

        //[HttpGet]
        //[Route("getCategoryImagebyname/{name}")]
        //public HttpResponseMessage GetCategoryImageByName(string name)
        //{
        //    try
        //    {
        //        var categoryImages = categoryImageModel.GetCategoryImageByName(name);
        //        if (categoryImages.Count > 0)
        //        {
        //            var response = new HttpResponseMessage(HttpStatusCode.OK);
        //            response.Content = new StringContent(JsonConvert.SerializeObject(categoryImageModel.GetCategoryImageByName(name)));
        //            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //            return response;
        //        }
        //        else
        //        {
        //            return new HttpResponseMessage(HttpStatusCode.NotFound);
        //        }
        //    }
        //    catch
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.BadRequest);
        //    }
        //}

        //[HttpPost]
        //[Route("addCategoryImage")]
        //public HttpResponseMessage AddNewCategoryImage(CategoryImageEntity CategoryImageEntity)
        //{
        //    try
        //    {
        //        if (categoryImageModel.AddNewCategoryImage(CategoryImageEntity))
        //        {
        //            var respone = new
        //            {
        //                createdAt = DateTime.Now
        //            };
        //            return Request.CreateResponse(HttpStatusCode.OK, respone);
        //        }
        //        else
        //        {
        //            return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
        //        }
        //    }
        //    catch
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.BadRequest);
        //    }
        //}

        //[HttpPut]
        //[Route("updateCategoryImage/{id}")]
        //public HttpResponseMessage UpdateCategoryImageById(int id, CategoryImageEntity CategoryImage)
        //{
        //    try
        //    {
        //        if (categoryImageModel.UpdateCategoryImageById(id, CategoryImage))
        //        {
        //            var respone = new
        //            {
        //                updatedAt = DateTime.Now
        //            };
        //            return Request.CreateResponse(HttpStatusCode.OK, respone);
        //        }
        //        else
        //        {
        //            return new HttpResponseMessage(HttpStatusCode.NotFound);
        //        }
        //    }
        //    catch
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.BadRequest);
        //    }
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //public HttpResponseMessage DeleteCategoryImageById(int id)
        //{
        //    try
        //    {
        //        if (categoryImageModel.DeleteCategoryImageById(id))
        //        {
        //            var respone = new
        //            {
        //                deletedAt = DateTime.Now
        //            };
        //            return Request.CreateResponse(HttpStatusCode.OK, respone);
        //        }
        //        else
        //        {
        //            return new HttpResponseMessage(HttpStatusCode.NotFound);
        //        }
        //    }
        //    catch
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.BadRequest);
        //    }
        //}
    }
}
