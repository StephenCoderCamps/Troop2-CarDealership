namespace CarDealership.Migrations
{
    using CarDealership.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealership.Models.ApplicationDbContext context)
        {

            var cars = new Car[] {
               new Car {Title="Tesla1", Price= 70000, Picture="http://blog.caranddriver.com/wp-content/uploads/2014/10/Screen-Shot-2014-10-10-at-9.16.06-AM-626x334.png", BriefDescription="TDB", FullDescription="TBDFULL"}, 
               new Car {Title="Tesla2", Price= 80000, Picture="http://s3.amazonaws.com/digitaltrends-uploads-prod/2013/08/Tesla-Model-S-burgondy.jpg", BriefDescription="TDB", FullDescription="TBDFULL"},
               new Car {Title="Tesla3", Price= 90000, Picture="http://www.blogcdn.com/www.autoblog.com/media/2012/09/01-2012-tesla-model-s-fd-1347336745.jpg", BriefDescription="TDB", FullDescription="TBDFULL"},
               new Car {Title="BMW1", Price= 50000, Picture="http://blog.caranddriver.com/wp-content/uploads/2014/03/2015-bmw-m4-coupe-photo-559228-s-787x481-626x382.jpg", BriefDescription="TDB", FullDescription="TBDFULL"},
               new Car {Title="BMW2", Price= 70000, Picture="http://www.bmw.com/_common/shared/newvehicles/mseries/m5sedan/2013/showroom/_img/background.jpg", BriefDescription="TDB", FullDescription="TBDFULL"},
               new Car {Title="BMW3", Price= 80000, Picture="http://i.telegraph.co.uk/multimedia/archive/03034/bmw-2-series-cabri_3034866b.jpg", BriefDescription="TDB", FullDescription="TBDFULL"}
            };

            context.Cars.AddOrUpdate(c => c.Title, cars);
        }
    }
}
