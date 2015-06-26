(function () {

    angular.module('CarApp', ['ngResource', 'ngRoute', 'ui.bootstrap'])
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
                    controller: 'CarEditController',
                    templateUrl: '/Partials/editCar.html',
                    controllerAs: 'main'
                })
                .when('/loginPage', {
                    controller: 'LoginController',
                    templateUrl: '/Partials/loginPage.html',
                    controllerAs: 'main'
                })
                .otherwise({ redirectTo: '/' });

            $locationProvider.html5Mode(true);

        });




})();