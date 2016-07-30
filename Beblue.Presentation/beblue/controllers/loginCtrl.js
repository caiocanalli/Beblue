(function ()
{
    "use strict";

    app.controller("loginCtrl", ["$scope", "LoginService", "$location", function ($scope, loginService, $location)
    {
        $scope.logando = false;

        $scope.usuario = {
            email: "",
            senha: ""
        };

        $scope.autenticar = function (usuario)
        {
            $scope.logando = true;

            loginService.login(usuario.email, usuario.senha).then(function (response)
            {
                $scope.logando = false;

                if (response != null && response.error != undefined)
                {
                    $scope.message = response.error_description;
                }
                else
                {
                    $location.path("/tarefa");
                }
            });
        }
    }]);
})();