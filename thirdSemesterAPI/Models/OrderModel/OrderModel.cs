using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using thirdSemesterAPI.CustomModels;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Models.OrderModel
{
    public class OrderModel
    {
        private ProjectAptechIIIEntities2 data = new ProjectAptechIIIEntities2();

        // Xuất ra tất cả sản phẩm
        public List<OrderEntity> GetAllOrder()
        {
            try
            {
                return data.Orders.Select(p => new OrderEntity()
                {
                    Id = p.Id,
                    CustomerId = p.CustomerId,
                    EmployeeId = p.EmployeeId,
                    IssueDate = p.IssueDate.Value,
                    Status = p.Status,
                    Total = p.Total.Value
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public OrderEntity GetOrderById(int id)
        {
            try
            {
                return data.Orders.Select(p => new OrderEntity()
                {
                    Id = p.Id,
                    CustomerId = p.CustomerId,
                    EmployeeId = p.EmployeeId,
                    IssueDate = p.IssueDate.Value,
                    Status = p.Status,
                    Total = p.Total.Value
                }).FirstOrDefault(p => p.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool AddNewOrder(OrderEntity p)
        {
            try
            {
                var newOrder = new Order()
                {
                    Id = p.Id,
                    CustomerId = p.CustomerId,
                    EmployeeId = p.EmployeeId,
                    IssueDate = p.IssueDate,
                    Status = p.Status,
                    Total = p.Total
                };
                data.Orders.Add(newOrder);
                data.SaveChanges();
                if (newOrder.Id != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public int SubmitOrder(OrderRequest orderRequest)
        {
            Order newOrder = new Order();
            List<OrderDetail> newOrderItems = new List<OrderDetail>();
            Address newAddress;
                try
                {
                // if not has customer Id ==> anonymous customer
                    newOrder.IssueDate = DateTime.Now;
                    newOrder.Status = "NEW";
                    newOrder.Total = orderRequest.Total;
                    newOrder.EmployeeId = 5;
                    if (orderRequest.CustomerID == null || orderRequest.CustomerID ==0)
                    {
                        newOrder.CustomerId = 36; // default of anonymous
                        newAddress = new Address
                        {
                            City = orderRequest.Address.City,
                            Country = orderRequest.Address.Country,
                            Phone = orderRequest.Address.Phone,
                            Address1 = orderRequest.Address.Address,
                        };
                        newOrder.Addresses = new List<Address> { newAddress };
                    }
                    else
                    {
                        newOrder.CustomerId = orderRequest.CustomerID.Value;
                        newOrder.AddressID = newOrder.AddressID;
                    }

                    newOrderItems = orderRequest.OrderDetails.Select(item => new OrderDetail
                    {
                        OrderId = newOrder.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.Price,
                        Total = item.ProductTotal,
                    }).ToList();
                    newOrder.OrderDetails = newOrderItems;
                    data.Orders.Add(newOrder);
                    data.SaveChanges();
                    return newOrder.Id;

            }
            catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("ERROR WHILE SUBMIT ORDER " + e);
                    return 0;
                }
            }

    }
}
