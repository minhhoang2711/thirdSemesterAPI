﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace thirdSemesterAPI.Models.Entity
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EmployDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}