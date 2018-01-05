using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using thirdSemesterAPI.DTO;
using thirdSemesterAPI.Models;

namespace thirdSemesterAPI.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderDTOController : ApiController
    {
        private ProjectAptechIIIEntities2 db = new ProjectAptechIIIEntities2();

        [HttpGet]
        [Route("getorders")]
        public IEnumerable<Order> GetOrders()
        {
            return db.Orders.Where(o => o.Customer.Name == User.Identity.Name);
        }

        [HttpGet]
        [Route("getorderbyid/{id}")]
        public OrderDTO GetOrder(int id)
        {
            Order order = db.Orders.Include("OrderDetail.Product")
                .First(o => o.Id == id && o.Customer.Name == User.Identity.Name);
            if (order == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new OrderDTO()
            {
                Details = from d in order.OrderDetails
                          select new OrderDTO.Detail()
                          {
                              ProductID = d.Product.Id,
                              Product = d.Product.Name,
                              Price = d.Product.Price.Value,
                              Quantity = d.Quantity.Value
                          }
            };
        }
        [HttpPost]
        [Route("postOrder")]
        public HttpResponseMessage PostOrder(OrderDTO dto)
        {
            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                    Id = dto.Id,
                    EmployeeId = dto.EmployeeId,
                    CustomerId = dto.CustomerId,
                    IssueDate = dto.IssueDate,
                    Status = dto.Status,
                    Total = dto.Total,
                    OrderDetails = (from item in dto.Details
                                    select new OrderDetail()
                                    { ProductId = item.ProductID, Quantity = item.Quantity }).ToList()
                };

                db.Orders.Add(order);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, order);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = order.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
