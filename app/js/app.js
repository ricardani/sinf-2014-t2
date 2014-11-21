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
                templateUrl: 'partials/login.html',
                controller: 'LoginCtrl'
            }).
            when('/list_orders', {
                templateUrl: 'partials/list_orders.html',
                controller: 'ListOrdersCtrl'
            }).
            when('/order/:orderID', {
                templateUrl: 'partials/order.html',
                controller: 'OrderCtrl'
            }).
            otherwise({
                redirectTo: '/login'
            });
    }]);
