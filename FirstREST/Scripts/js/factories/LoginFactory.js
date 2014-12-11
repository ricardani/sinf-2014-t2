var login = angular.module('LoginFactory', []);


login.factory('LoginFactory', function ($q, http) {
    return function (emailAddress, password, rememberMe) {

        var deferredObject = $q.defer();
        deferredObject.resolve({ success: true });//Mudar isto

        /*$http.post(
            '/Account/Login', {
                Email: emailAddress,
                Password: password,
                RememberMe: rememberMe
            }
        ).
        success(function (data) {
            if (data == "True") {
                deferredObject.resolve({ success: true });
            } else {
                deferredObject.resolve({ success: false });
            }
        }).
        error(function () {
            deferredObject.resolve({ success: false });
        });*/

        return deferredObject.promise;
    }
});
