'use strict';

/* Controllers */

var orderController = angular.module('orderController', []);

orderController.controller('OrderMainCtrl', function ($scope, $routeParams) {
    $scope.numDoc = $routeParams.numDoc;
});

orderController.controller('OrderInfoCtrl', function ($scope, $http) {

    $http({ url: '/api/docCompra/' + $scope.numDoc, method: 'GET' })
        .success(function (data, status, headers, config) {
            $scope.orderInfo = data;
        }).error(function (data, status, headers, config) {
            console.log(data);
        });


    $scope.submitOrder = function () {
        var tempSubmit = [], tempProduct;
        $scope.orderInfo.LinhasDoc.forEach(function (p) {
            var qtd = $("#qtdFrom" + p.id).val();
            if (qtd != 0) {
                tempProduct = { id: p.id, desc: p.desc, qtdReceived: qtd };
                tempSubmit.push(tempProduct);
            }
            
        });

        console.log(tempSubmit);
    };

});