(function () {

    angular.module('CarApp').controller('CarListController', function (CAR_API, $resource, $location, $http, CarService) {
        var self = this;

        this.cars = CarService.getCars();
        this.addCar = function () {
            CarService.addCar(self.newCar).then(function () {
                $location.path('/');
            });
        };

        self.filterCars = function (car) {
            if (!self.search) {
                return true;
            };
            return car.model.toLowerCase().startsWith(self.search.toLowerCase()) || car.make.toLowerCase().startsWith(self.search.toLowerCase());
        };
    });

    angular.module('CarApp').controller('CarDeleteController', function (CAR_API, $resource, $location, $routeParams, CarService) {
        var self = this;
        self.car = CarService.getCar($routeParams.id);
        self.deleteCar = function () {
            CarService.deleteCar($routeParams.id).then( function () {
                $location.path('/');
            });
        }
    });
    angular.module('CarApp').controller('CarEditController', function (CAR_API, $resource, $location, $routeParams, CarService) {
        var self = this;
        self.car = CarService.getCar($routeParams.id);

        this.editCar = function () {
            CarService.editCar(self.car).then(function () {
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
            }).success(
                function (result) {
                    sessionStorage.setItem('userToken', result.access_token);
                    $location.path('/');
                });
        }


    });

    angular.module('CarApp').controller('MenuController', function ($location, $http) {
        var self = this;

        self.showLogin = function () {
            return sessionStorage.getItem('userToken');
        };

        self.logout = function () {
            sessionStorage.removeItem('userToken');
            $location.path('/');

        };
    });
})();