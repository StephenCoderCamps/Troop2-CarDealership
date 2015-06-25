(function () {

    angular.module('CarApp', ['ngResource', 'ngRoute'])
        .constant('CAR_API', '/api/cars/:id')
        .config(function ($routeProvider, $locationProvider) {

            $routeProvider
                .when('/', {
                    controller: 'CarListController',
                    templateUrl: '/Partials/listCars.html',
                    controllerAs: 'main'
                })
                .when('/addCar', {
                    controller: 'CarListController',
                    templateUrl: '/Partials/addCar.html',
                    controllerAs: 'main'
                })
                .when('/deleteCar/:id', {
                    controller: 'CarDeleteController',
                    templateUrl: '/Partials/deleteCar.html',
                    controllerAs: 'main'
                })
                .when('/editCar/:id', {
                    controller: 'CarListController',
                    templateUrl: '/Partials/editCar.html',
                    controllerAs: 'main'
                })
                .otherwise({ redirectTo: '/' });

            $locationProvider.html5Mode(true);

        });




})();