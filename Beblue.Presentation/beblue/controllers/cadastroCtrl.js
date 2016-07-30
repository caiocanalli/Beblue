(function ()
{
    "use-strict";

    app.controller("cadastroCtrl", function ($scope, $http)
    {
        var apiUsuarios = serviceBase + "api/usuarios/cadastrar";

        $scope.cadastrando = false;

        $scope.cadastrar = function (usuario)
        {
            cadastrarUsuario(usuario);
        }

        function cadastrarUsuario(usuario)
        {
            $scope.cadastrando = true;

            $http.post(apiUsuarios, usuario)

            .success(function (data, status)
            {
                if (status == 201)
                {
                    $scope.usuario = {};

                    toastr.success("Parabéns", "Cadastro realizado com sucesso!");
                }

                $scope.cadastrando = false;
            })

            .error(function (error, status)
            {
                if (status == 300)
                {
                    toastr.error("O e-mail já existe na base de dados");
                }
                else if (status == 500)
                {
                    toastr.error("Não foi possível realizar o cadastro");
                }

                $scope.cadastrando = false;
            });
        }
    });
}());