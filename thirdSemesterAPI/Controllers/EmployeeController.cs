using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using thirdSemesterAPI.Models.EmployeeModel;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {

        private EmployeeModel employeeModel = new EmployeeModel();

        [HttpGet]
        [Route("findall")]
        public HttpResponseMessage GetAllEmployee()
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(employeeModel.GetAllEmployee()));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("getemployeebyid/{id}")]
        public HttpResponseMessage GetEmployeeById(int id)
        {
            try
            {
                if (employeeModel.GetEmployeeById(id) != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, employeeModel.GetEmployeeById(id));
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
        [Route("getemployeebyname/{name}")]
        public HttpResponseMessage GetEmployeeByName(string name)
        {
            try
            {
                var employees = employeeModel.GetEmployeeByName(name);
                if (employees.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, employeeModel.GetEmployeeByName(name));
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
        [Route("addemployee")]
        public HttpResponseMessage AddNewEmployee(EmployeeEntity employeeEntity)
        {
            try
            {
                if (employeeModel.AddNewEmployee(employeeEntity))
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
        [Route("updateemployee/{id}")]
        public HttpResponseMessage UpdateEmployeeById(int id, EmployeeEntity employee)
        {
            try
            {
                if (employeeModel.UpdateEmployeeById(id, employee))
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
        public HttpResponseMessage DeleteEmployeeById(int id)
        {
            try
            {
                if (employeeModel.DeleteEmployeeById(id))
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
