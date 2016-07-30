(function ()
{
    "use-strict";

    app.controller("senhaCtrl", function ($scope, $http)
    {
        var apiUsuarios = serviceBase + "api/usuarios/senha";

        $scope.usuario = {};
        $scope.novaSenha = "";
        $scope.recuperando = false;

        $scope.enviar = function (usuario)
        {
            enviarEmail(usuario);
        }

        function enviarEmail(usuario)
        {
            $scope.recuperando = true;

            $http.post(apiUsuarios, usuario)

            .success(function (data, status)
            {
                if (status == 200)
                {
                    $scope.novaSenha = data;

                    toastr.success("Parabéns", "Senha recuperada com sucesso!");
                }

                $scope.recuperando = false;
            })

            .error(function (error, status)
            {
                if (status == 400)
                {
                    toastr.error("E-mail inválido ou inexistente");
                }
                else if (status == 500)
                {
                    toastr.error("Não foi possível recuperar a senha");
                }

                $scope.recuperando = false;
            });
        }
    });
}());