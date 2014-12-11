'use strict';

/* Controllers */

var loginController = angular.module('loginController', []);

loginController.controller('LoginCtrl', function ($scope, $routeParams, $location) {

    $scope.loginForm = {
        emailAddress: '',
        password: '',
        rememberMe: false,
        returnUrl: $routeParams.returnUrl,
        loginFailure: false
    };

    $scope.login = function () {
        /*var result = LoginFactory($scope.loginForm.emailAddress, $scope.loginForm.password, $scope.loginForm.rememberMe);
        result.then(function (result) {
            if (result.success) {
                if ($scope.loginForm.returnUrl !== undefined) {
                    $location.path('/list_orders');
                } else {
                    $location.path($scope.loginForm.returnUrl);
                }
            } else {
                $scope.loginForm.loginFailure = true;
            }
        });*/
        $location.path('/list_orders');
        
    }

})