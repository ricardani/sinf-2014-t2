'use strict';

/* Controllers */

var listOrdersController = angular.module('listOrdersController', []);

listOrdersController.controller('ListOrdersCtrl', function ($scope) {

    $scope.orders = [];
    $scope.dateASC = false;

    var tempOrder, tempProducts;

    tempProducts = [
        {
            id:12, desc: 'PC', qtd: 10, barcode : 123456789
        },
        {
            id:15, desc: 'Ratos', qtd: 3, barcode : 35678910
        },
        {
            id:17, desc: 'Teclado', qtd: 5, barcode : 785422641
        },
        {
            id:19, desc: 'Mouse Pad', qtd: 3, barcode : 785422641
        },
        {
            id:19, desc: 'Caderno A5', qtd: 3, barcode : 5601493040747
        }
    ];

    tempOrder = {id: 1, date: '2007-02-04', products: tempProducts, supplier: 'Novo Atalho'};
    $scope.orders.push(tempOrder);

    tempProducts = [
        {
            id:45, desc: 'Bateria Original MOTOROLA BR50', qtd: 3, barcode : 999111250
        },
        {
            id:46, desc: 'Carregador + Cabo Corrente CANON POWERSHOT ACK-DC60 A3000 / A3100', qtd: 7, barcode : 999112285
        },
        {
            id:47, desc: 'Cabo HDMI ACER 1,3 1,50cm', qtd: 5, barcode : 999109719
        },
        {
            id:49, desc: 'Carregador Original NIKON', qtd: 1, barcode : 999112661
        },
        {
            id:41, desc: 'BATERIA ORIGINAL C-S2', qtd: 12, barcode : 999137064
        },
        {
            id:42, desc: 'Carregador Original ASUS 90W', qtd: 6, barcode : 999112562
        },
        {
            id:43, desc: 'Telecomando Original SANYO', qtd: 9, barcode : 999109282
        }
    ];

    tempOrder = {id: 2, date: '2013-07-15', products: tempProducts, supplier: 'Worten'};
    $scope.orders.push(tempOrder);

    tempProducts = [
        {
            id:95, desc: 'Ovos Classe M', qtd: 3, barcode : 999111250
        },
        {
            id:96, desc: 'Bolachas Arroz Integral com Iogurte', qtd: 7, barcode : 999112285
        },
        {
            id:97, desc: 'Tortitas Milho Chocolate Negro', qtd: 5, barcode : 999109719
        },
        {
            id:99, desc: 'Bombons Praliné com Chocolate de Leite Flower', qtd: 1, barcode : 999112661
        },
        {
            id:91, desc: 'Bombons Frutos do Mar', qtd: 12, barcode : 999137064
        },
        {
            id:92, desc: 'Vinho Tinto Regional Alentejo', qtd: 6, barcode : 999112562
        },
        {
            id:93, desc: 'Vinho Branco Regional Alentejo', qtd: 9, barcode : 999109282
        },
        {
            id:21, desc: 'Panaché Tara Perdida', qtd: 14, barcode : 999109282
        },
        {
            id:22, desc: 'Cerveja com Álcool Lata', qtd: 9, barcode : 999109282
        },
        {
            id:23, desc: 'Cerveja com Álcool La Trape', qtd: 1, barcode : 999109282
        },
        {
            id:24, desc: 'Cerveja com Álcool Super Bock', qtd: 3, barcode : 999109282
        },
        {
            id:25, desc: 'Polvo 3 a 4 Kg Congelado', qtd: 9, barcode : 999109282
        }
    ];

    tempOrder = {id: 3, date: '2014-04-08', products: tempProducts, supplier: 'Continente'};
    $scope.orders.push(tempOrder);


    $scope.dateOrder = function(){
        $scope.dateASC = !$scope.dateASC;
    }

});

