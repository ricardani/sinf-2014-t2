'use strict';

/* App Module */

var ordersApp = angular.module('ordersApp', [
    'ngRoute',

    'listOrdersController',
    'loginController',
    'orderController'
]);

ordersApp.config(['$routeProvider',
    function($routeProvider) {
        $routeProvider.
            when('/login', {
                templateUrl: 'routes/login',
                controller: 'LoginCtrl'
            }).
            when('/list_orders', {
                templateUrl: 'routes/list_orders',
                controller: 'ListOrdersCtrl'
            }).
            when('/order/:numDoc', {
                templateUrl: 'routes/order',
                controller: 'OrderMainCtrl'
            }).
            otherwise({
                redirectTo: '/login'
            });
    }]);
