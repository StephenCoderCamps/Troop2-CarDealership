using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.API
{
    public class CarsController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public IList<Car> GetCars()
        {
            return _db.Cars.ToList();         
        }

    }
}
