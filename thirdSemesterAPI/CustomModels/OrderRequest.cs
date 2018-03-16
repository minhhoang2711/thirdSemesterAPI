using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace thirdSemesterAPI.CustomModels
{
    public class OrderRequest
    {
        public int? CustomerID { get; set; }
        public List<OrderItem> OrderDetails {get;set;}
        public CustomerAddress Address { get; set; }
        public int AddressID { get; set; }
        public decimal Total { get; set; }
    }
    
    public class OrderItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public decimal ProductTotal { get; set; }
    }
    
    public class CustomerAddress
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
    }

    
}