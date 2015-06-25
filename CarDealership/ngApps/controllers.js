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

        self.editCar = function (original) {
            original.make = car.make;
            original.model = car.model;
            original.price = car.price;
            original.picture = car.picture;
            original.briefDescription = car.briefDescription;
            original.fullDescription = car.fullDescription;
            original.$save();
        }
        self.filterCars = function (car) {
            if (!self.search) {
                return true;
            };
            return car.model.toLowerCase().startsWith(self.search.toLowerCase()) || car.make.toLowerCase().startsWith(self.search.toLowerCase());
        };
    });
    angular.module('CarApp').controller('CarDeleteController', function (CAR_API, $resource, $location, $routeParams) {
        var self = this;
        var Car = $resource(CAR_API);
        self.car = Car.get({ id: $routeParams.id });

        self.deleteCar = function () {
            Car.remove({ id: $routeParams.id }, function () {
                $location.path('/');
            });
        }
    });
    angular.module('CarApp').controller('CarEditController', function (CAR_API, $resource, $location, $routeParams) {
        var self = this;
        var Car = $resource(CAR_API);
        self.car = Car.get({ id: $routeParams.id });

        self.editCar = function () {
            self.car.$save(function () {
                $location.path('/');
            });
        };

    });
    angular.module('CarApp').controller('LoginController', function ($location, $http) {
        var self = this;
        self.login = function () {
            var data = "grant_type=password&username=" + self.loginName + "&password=" + self.loginPassword;

            $http.post('/Token', data,
            {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            },
            function (result) {
                debugger
            });
        }


    });
})();