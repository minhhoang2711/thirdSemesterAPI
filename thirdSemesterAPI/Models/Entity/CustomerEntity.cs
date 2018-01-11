using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace thirdSemesterAPI.Models.Entity
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int CategoryCustomerId { get; set; }
        public string Password { get; set; }
        public int AddressId { get; set; }
    }
}