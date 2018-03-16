﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace thirdSemesterAPI.Models.Entity
{
    public class ProductClientEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }

    public class ProductClientEntityV2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Colors { get; set; }
        public List<string> ImageUrl { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}