(function () {

    angular.module('CarApp', ['ngResource']).constant('CAR_API', '/api/cars/:id').config(function ($routeProvider) {

    demoApp.config(function ($routeProvider) {
        $routeProvider
        .when('/', {
            controller: 'CarListController',
            templateUrl: 'Home/Index.html'
        })
        .when('/AddCar', {
            controller: 'CarListController',
            templateUrl: 'Partials/addCar.html'
        })
        .otherwise({ redirectTo: '/' });
    });





    });




})();