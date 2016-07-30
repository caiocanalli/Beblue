app
    .config(function ($routeProvider)
    {
        $routeProvider

        .when("/", {
            templateUrl: "views/tarefa.html",
            controller: "tarefaCtrl",
            requireAuth: true
        })

        .when("/login", {
            templateUrl: "views/login.html",
            controller: "loginCtrl"
        })

        .when("/cadastro", {
            templateUrl: "views/cadastro.html",
            controller: "cadastroCtrl"
        })

        .when("/senha", {
            templateUrl: "views/senha.html",
            controller: "senhaCtrl"
        })

        .otherwise({ redirectTo: "/" });
    })

    .run(function ($rootScope, $location, authData)
    {
        $rootScope.$on("$routeChangeStart", function (event, next, current)
        {
            if (next.requireAuth && !authData.authenticationData.isAuthenticated)
            {
                if (next.templateUrl === "views/login.html")
                {
                } else
                {
                    $location.path("/login");
                }
            }
        });
    });