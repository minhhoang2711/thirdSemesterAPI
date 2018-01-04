using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace thirdSemesterAPI.CustomModels
{
    public class ProductClientRes
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string ImageUrl { get; set; }
    }
}