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

        public HttpResponseMessage PostCars(Car car)
        {
            if (ModelState.IsValid) {
                if (car.Id == 0) {
                    _db.Cars.Add(car);
                    _db.SaveChanges();
                }
                else {
                    var original = _db.Cars.Find(car.Id);
                    original.Make = car.Make;
                    original.Model = car.Model;
                    original.Price = car.Price;
                    original.Picture = car.Picture;
                    original.BriefDescription = car.BriefDescription;
                    original.FullDescription = car.FullDescription;
                    _db.SaveChanges();
                }

                return Request.CreateResponse(HttpStatusCode.Created, car);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
        }

        public void Delete(int id)
        {
            var original = _db.Cars.Find(id);
            _db.Cars.Remove(original);
            _db.SaveChanges();

        }
    }
}