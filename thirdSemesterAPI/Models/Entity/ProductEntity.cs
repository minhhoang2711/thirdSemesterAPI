using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace thirdSemesterAPI.Models
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int ImageId { get; set; }
        public int ColorId { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}