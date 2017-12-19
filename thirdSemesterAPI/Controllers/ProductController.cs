using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using thirdSemesterAPI.Models;
using thirdSemesterAPI.Models.ProductModel;

namespace thirdSemesterAPI.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private ProductModel productModel = new ProductModel();

        [HttpGet]
        [Route("findall")]
        public HttpResponseMessage GetAllProduct()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, productModel.GetAllProduct());
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [HttpGet]
        [Route("findbyid/{id}")]
        public HttpResponseMessage GetProductById(int id)
        {
            try
            {
                if (productModel.GetProductById(id) != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, productModel.GetProductById(id));
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
        [Route("findbyprice/{price}")]
        public HttpResponseMessage GetProductByPrice(double min, double max)
        {
            try
            {
                var products = productModel.GetProductByPrice(min, max);
                if (products.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, productModel.GetProductByPrice(min, max));
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
        [Route("addproduct")]
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
