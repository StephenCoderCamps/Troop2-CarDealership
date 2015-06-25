using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Make { get; set; }  // renamed Title  added Model so we can sort on make and model

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string BriefDescription { get; set; }

        public string FullDescription { get; set; }
    }
}