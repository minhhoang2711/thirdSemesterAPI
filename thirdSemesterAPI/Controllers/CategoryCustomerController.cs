using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using thirdSemesterAPI.Models.CategoryCustomerModel;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Controllers
{
    [RoutePrefix("api/categorycustomer")]
    public class CategoryCustomerController : ApiController
    {

        private CategoryCustomerModel categoryCustomerModel = new CategoryCustomerModel();

        [HttpGet]
        [Route("findall")]
        public HttpResponseMessage GetAllCategoryCustomer()
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(categoryCustomerModel.GetAllCategoryCustomer()));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("getcategorycustomerbyid/{id}")]
        public HttpResponseMessage GetCategoryCustomerById(int id)
        {
            try
            {
                if (categoryCustomerModel.GetCategoryCustomerById(id) != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(categoryCustomerModel.GetCategoryCustomerById(id)));
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

        [HttpGet]
        [Route("getcategorycustomerbyname/{name}")]
        public HttpResponseMessage GetCategoryCustomerByName(string name)
        {
            try
            {
                var CategoryCustomers = categoryCustomerModel.GetCategoryCustomerByName(name);
                if (CategoryCustomers.Count > 0)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(categoryCustomerModel.GetCategoryCustomerByName(name)));
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
        [Route("addcategorycustomer")]
        public HttpResponseMessage AddNewCategoryCustomer(CategoryCustomerEntity categoryCustomerEntity)
        {
            try
            {
                if (categoryCustomerModel.AddNewCategoryCustomer(categoryCustomerEntity))
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
        [Route("updatecategorycustomer/{id}")]
        public HttpResponseMessage UpdateCategoryCustomerById(int id, CategoryCustomerEntity categoryCustomer)
        {
            try
            {
                if (categoryCustomerModel.UpdateCategoryCustomerById(id, categoryCustomer))
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
        public HttpResponseMessage DeleteCategoryCustomerById(int id)
        {
            try
            {
                if (categoryCustomerModel.DeleteCategoryCustomerById(id))
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
