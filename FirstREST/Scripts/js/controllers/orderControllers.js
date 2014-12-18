'use strict';

/* Controllers */

var orderController = angular.module('orderController', []);

orderController.controller('OrderMainCtrl', function ($scope, $routeParams) {
    $scope.numDoc = $routeParams.numDoc;
    $scope.error = 0;

});

orderController.controller('OrderInfoCtrl', function ($scope, $http, $location) {

    $http({ url: '/api/docCompra/' + $scope.numDoc, method: 'GET' })
        .success(function (data, status, headers, config) {
            $scope.orderInfo = data;
        }).error(function (data, status, headers, config) {
            console.log(data);
        });


    $scope.submitOrder = function () {
        var tempSubmit = [], tempProduct;
        
        $http.post(
            '/api/docCompra',$scope.orderInfo
        ).
        success(function (data, status, headers, config) {
            console.log(data);
            if (status == "201") {
                $("#SubmitSuccess").modal('show');
            } else {
                $("#SubmitError").modal('show');
            }
        }).
        error(function (data) {
            $("#SubmitError").modal('show');
            console.log(data);
        });

        
    };

    $scope.returnListOrders = function () {
        $location.url("/list_orders");
    };

    

});