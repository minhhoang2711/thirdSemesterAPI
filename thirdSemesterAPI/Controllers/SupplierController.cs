using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using thirdSemesterAPI.Models.Entity;
using thirdSemesterAPI.Models.SupplierModel;

namespace thirdSemesterAPI.Controllers
{
    [RoutePrefix("api/supplier")]
    public class SupplierController : ApiController
    {

        private SupplierModel supplierModel = new SupplierModel();

        [HttpGet]
        [Route("findall")]
        public HttpResponseMessage GetAllSupplier()
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(supplierModel.GetAllSupplier()));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("getsupplierbyid/{id}")]
        public HttpResponseMessage GetSupplierById(int id)
        {
            try
            {
                if (supplierModel.GetSupplierById(id) != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, supplierModel.GetSupplierById(id));
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
        [Route("getsupplierbyname/{name}")]
        public HttpResponseMessage GetSupplierByName(string name)
        {
            try
            {
                var suppliers = supplierModel.GetSupplierByName(name);
                if (suppliers.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, supplierModel.GetSupplierByName(name));
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
        [Route("addsupplier")]
        public HttpResponseMessage AddNewsupplier(SupplierEntity supplierEntity)
        {
            try
            {
                if (supplierModel.AddNewSupplier(supplierEntity))
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
        [Route("updatesupplier/{id}")]
        public HttpResponseMessage UpdateSupplierById(int id, SupplierEntity supplier)
        {
            try
            {
                if (supplierModel.UpdateSupplierById(id, supplier))
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
        public HttpResponseMessage DeletesupplierById(int id)
        {
            try
            {
                if (supplierModel.DeleteSupplierById(id))
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
