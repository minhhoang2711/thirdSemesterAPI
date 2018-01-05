using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace thirdSemesterAPI.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime IssueDate { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public class Detail
        {
            public int ProductID { get; set; }
            public string Product { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
        public IEnumerable<Detail> Details { get; set; }
    }
}