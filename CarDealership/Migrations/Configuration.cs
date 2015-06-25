namespace CarDealership.Migrations
{
    using CarDealership.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using System.Security.Claims;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealership.Models.ApplicationDbContext context)
        {

            var cars = new Car[] {
             new Car {Make="Tesla", Model="Model X", Price= 70000, Picture="http://blog.caranddriver.com/wp-content/uploads/2014/10/Screen-Shot-2014-10-10-at-9.16.06-AM-626x334.png", BriefDescription="TDB", FullDescription="TBDFULL"}, 
             new Car {Make="Tesla", Model="Roadster", Price= 80000, Picture="http://s3.amazonaws.com/digitaltrends-uploads-prod/2013/08/Tesla-Model-S-burgondy.jpg", BriefDescription="TDB", FullDescription="TBDFULL"},
             new Car {Make="Tesla", Model="Model S", Price= 90000, Picture="http://www.blogcdn.com/www.autoblog.com/media/2012/09/01-2012-tesla-model-s-fd-1347336745.jpg", BriefDescription="TDB", FullDescription="TBDFULL"},
               new Car {Make="BMW", Model="3201", Price= 50000, Picture="http://blog.caranddriver.com/wp-content/uploads/2014/03/2015-bmw-m4-coupe-photo-559228-s-787x481-626x382.jpg", BriefDescription="TDB", FullDescription="TBDFULL"},
               new Car {Make="BMW", Model="740", Price= 70000, Picture="http://www.bmw.com/_common/shared/newvehicles/mseries/m5sedan/2013/showroom/_img/background.jpg", BriefDescription="TDB", FullDescription="TBDFULL"},
               new Car {Make="BMW", Model="Z3", Price= 80000, Picture="http://i.telegraph.co.uk/multimedia/archive/03034/bmw-2-series-cabri_3034866b.jpg", BriefDescription="TDB", FullDescription="TBDFULL"},
             new Car {Make="Tesla", Model="Roadster", Price= 70000, Picture="http://blog.caranddriver.com/wp-content/uploads/2014/10/Screen-Shot-2014-10-10-at-9.16.06-AM-626x334.png", BriefDescription="TDB", FullDescription="TBDFULL"}, 
             new Car {Make="Tesla", Model="Model S", Price= 80000, Picture="http://s3.amazonaws.com/digitaltrends-uploads-prod/2013/08/Tesla-Model-S-burgondy.jpg", BriefDescription="TDB", FullDescription="TBDFULL"},
             new Car {Make="Tesla", Model="Model X", Price= 90000, Picture="http://www.blogcdn.com/www.autoblog.com/media/2012/09/01-2012-tesla-model-s-fd-1347336745.jpg", BriefDescription="TDB", FullDescription="TBDFULL"},
               new Car {Make="BMW", Model="2002", Price= 50000, Picture="http://blog.caranddriver.com/wp-content/uploads/2014/03/2015-bmw-m4-coupe-photo-559228-s-787x481-626x382.jpg", BriefDescription="TDB", FullDescription="TBDFULL"},
               new Car {Make="BMW", Model="Z4", Price= 70000, Picture="http://www.bmw.com/_common/shared/newvehicles/mseries/m5sedan/2013/showroom/_img/background.jpg", BriefDescription="TDB", FullDescription="TBDFULL"},
               new Car {Make="BMW", Model="540i", Price= 80000, Picture="http://i.telegraph.co.uk/multimedia/archive/03034/bmw-2-series-cabri_3034866b.jpg", BriefDescription="TDB", FullDescription="TBDFULL"}
            };

            context.Cars.AddOrUpdate(c => new{c.Make, c.Model, c.Price}, cars);

            var user = new ApplicationUser
            {
                UserName = "StephenW",
                Email = "stephen.walther@codercamps.com"
            };

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            if (userManager.FindByName(user.UserName) == null) {
                userManager.Create(user, "Secret123!");
                userManager.AddClaim(user.Id, new Claim("CanEditCars", "true"));
            }
        }
    }
}
