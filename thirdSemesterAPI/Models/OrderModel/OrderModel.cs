using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}