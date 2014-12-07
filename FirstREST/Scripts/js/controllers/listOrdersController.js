'use strict';

/* Controllers */

var listOrdersController = angular.module('listOrdersController', []);

listOrdersController.controller('ListOrdersCtrl', function ($scope, $http) {

    $scope.orders = [];
    $scope.dateASC = false;
    
    $http({url: '/api/docCompra', method: 'GET'})
        .success(function (data, status, headers, config) {
            $scope.orders = data;
        }).error(function (data, status, headers, config) {
            console.log(data);
        });


    $scope.dateOrder = function(){
        $scope.dateASC = !$scope.dateASC;
    }

});

