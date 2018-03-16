using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using thirdSemesterAPI.Models.CustomerModel;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {

        private CustomerModel customerModel = new CustomerModel();

        [HttpGet]
        [Route("findall")]
        public HttpResponseMessage GetAllCustomer()
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(customerModel.GetAllCustomer()));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("getCustomerbyid/{id}")]
        public HttpResponseMessage GetCustomerById(int id)
        {
            try
            {
                if (customerModel.GetCustomerById(id) != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(customerModel.GetCustomerById(id)));
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
        [Route("getCustomerClientByid/{id}")]
        public HttpResponseMessage GetCustomerClientById(int id)
        {
            try
            {
                if (customerModel.GetCustomerById(id) != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(customerModel.GetCustomerClientById(id)));
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
        [Route("getCustomerbyname/{name}")]
        public HttpResponseMessage GetCustomerByName(string name)
        {
            try
            {
                var customers = customerModel.GetCustomerByName(name);
                if (customers.Count > 0)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(customerModel.GetCustomerByName(name)));
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
        [Route("getCustomerClientByName/{name}")]
        public HttpResponseMessage GetCustomerClientByName(string name)
        {
            try
            {
                var customers = customerModel.GetCustomerClientByName(name);
                if (customers.Count > 0)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(customerModel.GetCustomerClientByName(name)));
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
        [Route("addCustomer")]
        public HttpResponseMessage AddNewCustomer(CustomerEntity CustomerEntity)
        {
            try
            {
                if (customerModel.AddNewCustomer(CustomerEntity))
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
        [Route("updateCustomer/{id}")]
        public HttpResponseMessage UpdateCustomerById(int id, CustomerEntity Customer)
        {
            try
            {
                if (customerModel.UpdateCustomerById(id, Customer))
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
        public HttpResponseMessage DeleteCustomerById(int id)
        {
            try
            {
                if (customerModel.DeleteCustomerById(id))
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

        [HttpPost]
        [Route("auth")]
        public HttpResponseMessage Login(LoginRequest login)
        {
            try
            {
                var customer = customerModel.Login(login);
                if (customer != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new {
                        UserId = customer.UserId,
                        AddressId = customer.AddressId,
                    });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, new {
                    ErrMessage = "UNKNOWN ERROR" });
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

        }
    }
}
