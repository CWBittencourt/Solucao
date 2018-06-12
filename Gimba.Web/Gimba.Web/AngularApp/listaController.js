(function (app) {
    var listaController = function ($scope, $http, clienteApiUrl) {
        $http.get("/api/clientedto").then(function (data) {
            $scope.clientes = data;
        });

        $scope.deleta = function (id) {
            $http.delete(clienteApiUrl + id).then(function () {
                $http.get(clienteApiUrl).then(function (data) {
                    $scope.clientes = data;
                });
            })

        };
    };


    app.controller("listaController", listaController)

}(angular.module("clientedto")));

