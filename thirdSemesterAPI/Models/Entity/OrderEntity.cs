using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace thirdSemesterAPI.Models.Entity
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime IssueDate { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
    }
}