(function () {

    angular.module('CarApp').controller('CarListController', function (CAR_API, $resource) {
        var self = this;
        var Car = $resource(CAR_API);
        self.cars = Car.query();

        self.addCar = function () {
            var newCar = new Car({
                Make: self.newCar.make,
                Model: self.newCar.model,
                Price: self.newCar.price,
                Picture: self.newCar.picture,
                BriefDescription: self.newCar.briefDescription,
                FullDescription: self.newCar.fullDescription
            });
            newCar.$save(function (result) {
                self.cars.push(result);
            });
        }

        self.editCar = function (origional) {
            origional.make = car.make;
            origional.model = car.model;
            origional.price = car.price;
            origional.picture = car.picture;
            origional.briefDescription = car.briefDescription;
            origional.fullDescription = car.fullDescription;
            origional.$save();
        }

        self.deleteCar = function (origional) {
            origional.$remove({ id: origional.id }, function () {
                self.cars = self.cars.filter(function (item) {
                    return origional.id != item.id;
                });
            })
        }
    });
})();