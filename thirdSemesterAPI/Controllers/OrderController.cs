using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using thirdSemesterAPI.CustomModels;
using thirdSemesterAPI.Models.Entity;
using thirdSemesterAPI.Models.OrderModel;

namespace thirdSemesterAPI.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private OrderModel orderModel = new OrderModel();

        [HttpGet]
        [Route("findall")]
        public HttpResponseMessage GetAllOrder()
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject((orderModel.GetAllOrder())));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("getOrderById/{id}")]
        public HttpResponseMessage GetOrderById(int id)
        {
            try
            {
                if (orderModel.GetOrderById(id) != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(orderModel.GetOrderById(id)));
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
        [Route("addOrder")]
        public HttpResponseMessage AddNewOrder(OrderEntity orderEntity)
        {
            try
            {
                if (orderModel.AddNewOrder(orderEntity))
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
        [HttpPost]
        [Route("new")]
        public HttpResponseMessage SubmitOrder(OrderRequest order)
        {
            try
            {
                int orderId = orderModel.SubmitOrder(order);
                if (orderId == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "ERROR WHILE SUBMIT");
                }
                var responseObj = new
                {
                    OrderId= orderId,
                };
                return Request.CreateResponse(HttpStatusCode.OK, responseObj);
            } catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "ERROR WHILE SUBMIT");
            }
        }
    }
}
