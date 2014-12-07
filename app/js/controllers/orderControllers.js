'use strict';

/* Controllers */

var orderController = angular.module('orderController', []);

orderController.controller('OrderMainCtrl', function ($scope, $routeParams) {
    $scope.numDoc = $routeParams.numDoc;
});

orderController.controller('OrderInfoCtrl', function ($scope) {

    var orderProducts = [
        {
            id:12, desc: 'Bateria Original MOTOROLA BR50', qtd: 10, barcode : 123456789, storage: 'Armazem 1'
        },
        {
            id:15, desc: 'Carregador + Cabo Corrente CANON POWERSHOT ACK-DC60 A3000 / A3100', qtd: 3, barcode : 35678910, storage: 'Avenida General Delgado'
        },
        {
            id:17, desc: 'Cabo HDMI ACER 1,3 1,50cm', qtd: 5, barcode : 785422641, storage: 'Rua das Palmeiras'
        },
        {
            id:19, desc: 'BATERIA ORIGINAL C-S2', qtd: 3, barcode : 785422641, storage: 'Rua das Palmeiras'
        },
        {
            id:39, desc: 'Telecomando Original SANYO', qtd: 3, barcode : 5601493040747, storage: 'Avenida General Delgado'
        }
    ];

    $scope.orderInfo = {numDoc: $scope.numDoc, date: '2007-02-04', products: orderProducts, supplier: 'Novo Atalho'};

    $scope.submitOrder = function () {
        var tempSubmit = [], tempProduct;
        $scope.orderInfo.products.forEach(function(p){
            var qtd = $("#qtdFrom" + p.id).val();
            tempProduct = {id: p.id, desc: p.desc, qtdReceived: qtd};
            tempSubmit.push(tempProduct);
        });

        console.log(tempSubmit);
    };

});