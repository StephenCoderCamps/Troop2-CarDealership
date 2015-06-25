(function () {

    angular.module('CarApp').controller('CarListController', function (CAR_API, $resource, $location) {
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
                $location.path('/');
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
    });
    angular.module('CarApp').controller('CarDeleteController', function (CAR_API, $resource, $location, $routeParams) {
        var self = this;
        var Car = $resource(CAR_API);
        self.car = Car.get({id:$routeParams.id});

        self.deleteCar = function () {
            Car.remove({ id: $routeParams.id }, function () {
                $location.path('/');
            });
        }
    });
})();