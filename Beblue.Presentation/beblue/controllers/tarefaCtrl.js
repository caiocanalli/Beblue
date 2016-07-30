(function ()
{
    "use-strict";

    app.controller("tarefaCtrl", ["$scope", "$http", "LoginService", "authData", "$location", function ($scope, $http, loginService, authData, $location)
    {
        var apiTarefas = serviceBase + "api/tarefas";
        var apiCategorias = serviceBase + "api/categorias";
        var apiPrioridades = serviceBase + "api/prioridades";

        $scope.tarefa = {
            idTarefa: 0,
            nome: "",
            descricao: "",
            idCategoria: 0,
            idPrioridade: 0,
            concluida: false,
            idUsuario: 0
        }

        $scope.tarefas = [];
        $scope.categorias = [];
        $scope.prioridades = [];
        $scope.nome = authData.authenticationData.nome;

        $scope.sair = function ()
        {
            loginService.logOut();
            $location.path("/login");
        }

        $scope.salvar = function (tarefa)
        {
            if (tarefa.idTarefa == 0)
            {
                salvarTarefa(angular.copy(tarefa));
            }
            else
            {
                editarTarefa(angular.copy(tarefa));
            }

            novaTarefa();
        }

        $scope.nova = function ()
        {
            novaTarefa();
        }

        $scope.editar = function (tarefa)
        {
            $scope.tarefa = angular.copy(tarefa);
        }

        $scope.excluir = function (tarefa)
        {
            excluirTarefa(tarefa);
        }

        $scope.isTarefaConcluida = function (concluida)
        {
            return concluida ? "Sim" : "Não";
        }

        // Funções

        function novaTarefa()
        {
            $scope.tarefa = {
                idTarefa: 0,
                nome: "",
                descricao: "",
                idCategoria: 0,
                idPrioridade: 0,
                concluida: false,
                idUsuario: 0
            }
        }

        function salvarTarefa(tarefa)
        {
            tarefa.idUsuario = authData.authenticationData.id;

            $http.post(apiTarefas, tarefa)

            .success(function (data, status)
            {
                if (status == 201)
                {
                    tarefa.idTarefa = data.idTarefa;
                    tarefa.dataCadastro = data.dataCadastro;

                    $scope.tarefas.push(tarefa);

                    toastr.success("Parabéns", "Tarefa adicionada com sucesso!");
                }
            })

            .error(function (error, status)
            {
                if (status == 500)
                {
                    toastr.error("Desculpe", "Não foi possível adicionar a tarefa");
                }
            });
        }

        function editarTarefa(tarefa)
        {
            $http.put(apiTarefas + "/" + tarefa.idTarefa, tarefa)

            .success(function (data, status)
            {
                if (status == 200)
                {
                    var i = $scope.tarefas.indexOf($scope.tarefas.filter(function (item)
                    {
                        return item.idTarefa == tarefa.idTarefa
                    })[0]);

                    $scope.tarefas[i] = tarefa;

                    toastr.success("Parabéns", "Tarefa atualizada com sucesso!");
                }
            })

            .error(function (error, status)
            {
                if (status == 400)
                {
                    toastr.error("Desculpe", "Tarefa inválida");
                }
                else if (status == 500)
                {
                    toastr.error("Desculpe", "Não foi possível atualizar a tarefa");
                }
            });
        }

        function excluirTarefa(tarefa)
        {
            $http.delete(apiTarefas + "/" + tarefa.idTarefa)

            .success(function (data, status)
            {
                if (status == 200)
                {
                    var index = $scope.tarefas.indexOf(tarefa);
                    $scope.tarefas.splice(index, 1);

                    toastr.success("Parabéns", "Tarefa excluída com sucesso!");
                }
            })

            .error(function (error, status)
            {
                if (status == 400)
                {
                    toastr.error("Desculpe", "Tarefa inválida");
                }
                else if (status == 500)
                {
                    toastr.error("Desculpe", "Não foi possível excluir a tarefa");
                }
            });
        }

        function carregarTarefa()
        {
            $http.get(apiTarefas + "/" + authData.authenticationData.id)

            .success(function (data)
            {
                $scope.tarefas = data;
            })

            .error(function (error)
            {
                toastr.error("Desculpe", "Não foi possível carregar as tarefas");
            });
        }

        function carregarCategoria()
        {
            $http.get(apiCategorias)

            .success(function (data)
            {
                $scope.categorias = data;
            })

            .error(function (error)
            {
                toastr.error("Desculpe", "Não foi possível carregar as categorias");
            });
        }

        function carregarPrioridade()
        {
            $http.get(apiPrioridades)

            .success(function (data)
            {
                $scope.prioridades = data;
            })

            .error(function (error)
            {
                toastr.error("Desculpe", "Não foi possível carregar as prioridades");
            });
        }

        carregarCategoria();
        carregarPrioridade();
        carregarTarefa();
    }]);
}());