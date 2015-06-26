(function () {
    angular.module('CarApp').factory('CarService', function (CAR_API, $http, $resource) {
        // load the cars here
        var self = this;
        $http.defaults.headers.common['Authorization'] = 'bearer ' + sessionStorage.getItem('userToken');
        var Car = $resource(CAR_API);
        // Get Cars
        var _getCars = function () {
            return Car.query();
        };

        var _getCar = function (id) {
            return Car.get({ id: id });
        };

        var _addCar = function (car) {
            var newCar = new Car(car);
            return newCar.$save();
        };

        var _editCar = function (car) {
            return car.$save();
        };

        var _deleteCar = function (id) {
            return Car.remove({ id: id }).$promise;
            };

        return {
            getCars: _getCars,
            getCar: _getCar,
            addCar: _addCar,
            editCar: _editCar,
            deleteCar: _deleteCar

        };

    });
})();