using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        [Route("getcategoryproductbyid/{id}")]
        public HttpResponseMessage GetCategoryProductById(int id)
        {
            try
            {
                if (categoryProductModel.GetCategoryProductById(id) != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(categoryProductModel.GetCategoryProductById(id)));
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    return response;
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

        /** Get all product in the categories
         */
        [HttpGet]
        [Route("{id}/products")]
        public HttpResponseMessage GetCategoryProductsById(int id)
        {
            HttpResponseMessage res;
            List<ProductClientEntity> list;
            try
            {
                list = categoryProductModel.GetProductListByCategoryId(id);
                

            } catch (SqlException e)
            {
                res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                res.Content = new StringContent(JsonConvert.SerializeObject(e));
                return res;
            }
            res = new HttpResponseMessage();
            res.Content = new StringContent(JsonConvert.SerializeObject(list));
            return res;
        }

        [HttpGet]
        [Route("getcategoryproductbyname/{name}")]
        public HttpResponseMessage GetCategoryProductByName(string name)
        {
            try
            {
                var categoryProducts = categoryProductModel.GetCategoryProductByName(name);
                if (categoryProducts.Count > 0)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(categoryProductModel.GetCategoryProductByName(name)));
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    return response;
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
        [Route("addcategoryproduct")]
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
        [Route("updatecategoryproduct/{id}")]
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
