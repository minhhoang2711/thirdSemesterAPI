using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace thirdSemesterAPI.Models.Entity
{
    public class ColorEntity
    {
        public int Id { get; set; }
        public string NameByColorName { get; set; }
        public string NameByRGB { get; set; }
        public string NameByHexadecimal { get; set; }
    }
}