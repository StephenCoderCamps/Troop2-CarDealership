﻿using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace CarDealership.API
{
    public class CarsController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public IList<Car> GetCars()
        {
            //// need to logout/login again to load claims
            //var claimsUser = this.User as ClaimsPrincipal;
            //var claims = claimsUser.Claims.ToList();
            return _db.Cars.ToList();         
        }

        //[Authorize(Users='bob')]
        //[Authorize(Roles='bob')]
        // [Authorize]
        public HttpResponseMessage PostCars(Car car)
        {
            // var claimsUser = this.User as ClaimsPrincipal;
            //if (!claimsUser.HasClaim("CanEditCars", "true")) {
            //    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "None Shall Pass");
            //}

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

        public Car GetCar(int id)
        {
            return _db.Cars.Find(id);
        }

        // [Authorize]
        public void Delete(int id)
        {
            var original = _db.Cars.Find(id);
            _db.Cars.Remove(original);
            _db.SaveChanges();

        }
    }
}