using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using thirdSemesterAPI.Models.CategoryModel;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Controllers
{
    [RoutePrefix("api/CategoryProduct")]
    public class CategoryProductController : ApiController
    {

        private CategoryModel categoryProductModel = new CategoryModel();

        [HttpGet]
        [Route("findall")]
        public HttpResponseMessage GetAllCategoryProduct()
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(categoryProductModel.GetAllCategoryProduct()));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("getCategoryProductbyid/{id}")]
        public HttpResponseMessage GetCategoryProductById(int id)
        {
            try
            {
                if (categoryProductModel.GetCategoryProductById(id) != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, categoryProductModel.GetCategoryProductById(id));
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("getCategoryProductbyname/{name}")]
        public HttpResponseMessage GetCategoryProductByName(string name)
        {
            try
            {
                var categoryProducts = categoryProductModel.GetCategoryProductByName(name);
                if (categoryProducts.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, categoryProductModel.GetCategoryProductByName(name));
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("addCategoryProduct")]
        public HttpResponseMessage AddNewCategoryProduct(CategoryProductEntity categoryProductEntity)
        {
            try
            {
                if (categoryProductModel.AddNewCategoryProduct(categoryProductEntity))
                {
                    var respone = new
                    {
                        createdAt = DateTime.Now
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, respone);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [Route("updateCategoryProduct/{id}")]
        public HttpResponseMessage UpdateCategoryProductById(int id, CategoryProductEntity categoryProduct)
        {
            try
            {
                if (categoryProductModel.UpdateCategoryProductById(id, categoryProduct))
                {
                    var respone = new
                    {
                        updatedAt = DateTime.Now
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, respone);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteCategoryProductById(int id)
        {
            try
            {
                if (categoryProductModel.DeleteCategoryProductById(id))
                {
                    var respone = new
                    {
                        deletedAt = DateTime.Now
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, respone);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
