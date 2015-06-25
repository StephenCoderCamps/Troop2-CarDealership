using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string BriefDescription { get; set; }

        public string FullDescription { get; set; }
    }
}