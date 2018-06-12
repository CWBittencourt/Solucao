(function () {

    var app = angular.module("clientedto", ["ngRoute"]);

    var config = function ($routeProvider) {

        $routeProvider
        .when("/",
               { templateUrl: "/cliente/html/ClienteDTO/Lista.html", controller: "listaController" })
        .when("/criar/",
               { templateUrl: "/cliente/html/ClienteDTO/Criar.html", controller: "ClienteController" })
        .when("/Delete/:id",
               { templateUrl: "/cliente/html/ClienteDTO/Criar.html", controller: "ClienteController" })
        .otherwise(
               { redirecTo: "/" });
    };
    app.config(config);
    app.constant("clienteApiUrl", "/api/ClienteDTO/");
}());