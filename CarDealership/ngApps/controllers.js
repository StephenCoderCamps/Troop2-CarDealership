(function () {

    angular.module('CarApp').controller('CarListController', function (CAR_API, $resource) {
        var self = this;


        var Car = $resource(CAR_API);

        self.cars = Car.query();

        

    });
})();