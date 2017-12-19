using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace thirdSemesterAPI.Models.Entity
{
    public class NewsEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentNews { get; set; }
        public int ImageId { get; set; }
        public DateTime PostDate { get; set; }
    }
}