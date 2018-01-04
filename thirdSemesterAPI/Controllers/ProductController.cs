using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using thirdSemesterAPI.CustomModels;
using thirdSemesterAPI.Models;
using thirdSemesterAPI.Models.Entity;
using thirdSemesterAPI.Models.ProductModel;

namespace thirdSemesterAPI.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private ProductModel productModel = new ProductModel();

        [HttpGet]
        [Route("findAll")]
        public HttpResponseMessage GetAllProduct()
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(productModel.GetAllProduct()));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("findAllClient")]
        public HttpResponseMessage GetAllProductForClient()
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                List<ProductClientRes> products = productModel.GetAllProductForClient();
                response.Content = new StringContent(JsonConvert.SerializeObject(productModel.GetAllProductForClient()));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [HttpGet]
        [Route("findById/{id}")]
        public HttpResponseMessage GetProductById(int id)
        {
            try
            {
                if (productModel.GetProductById(id) != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(productModel.GetProductById(id)));
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
        [Route("findByName/{name}")]
        public HttpResponseMessage GetProductByName(string name)
        {
            try
            {
                if (productModel.GetProductByName(name) != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(productModel.GetProductByName(name)));
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
        [Route("findByNameClient/{name}")]
        public HttpResponseMessage GetProductByNameForClient(string name)
        {
            try
            {
                if (productModel.GetProductByNameForClient(name) != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(productModel.GetProductByNameForClient(name)));
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
        [Route("findByIdClient/{id}")]
        public HttpResponseMessage GetProductByIdForClient(int id)
        {
            try
            {
                if (productModel.GetProductById(id) != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(productModel.GetProductByIdForClient(id)));
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
        [Route("findByPrice/{min}/{max}")]
        public HttpResponseMessage GetProductByPrice(double min, double max)
        {
            try
            {
                var products = productModel.GetProductByPrice(min, max);
                if (products.Count > 0)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(productModel.GetProductByPrice(min, max)));
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
        [Route("findByPriceClient/{min}/{max}")]
        public HttpResponseMessage GetProductByPriceForClient(double min, double max)
        {
            try
            {
                var products = productModel.GetProductByPriceForClient(min, max);
                if (products.Count > 0)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(productModel.GetProductByPriceForClient(min, max)));
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
        [Route("addProduct")]
        public HttpResponseMessage AddNewProduct(ProductEntity productEntity)
        {
            try
            {
                if (productModel.AddNewProduct(productEntity))
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
        [Route("{id}")]
        public HttpResponseMessage UpdateProductById(int id, ProductEntity productEntity)
        {
            try
            {
                if (productModel.UpdateProductById(id, productEntity))
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
        public HttpResponseMessage DeleteProductById(int id)
        {
            try
            {
                if (productModel.DeleteProductById(id))
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
