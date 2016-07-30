(function ()
{
    "use strict";

    app.service("LoginService", ["$http", "$q", "AuthenticationService", "authData",

    function ($http, $q, authenticationService, authData)
    {
        var userInfo;
        var loginServiceURL = serviceBase + "token";
        var deviceInfo = [];
        var deferred;

        this.login = function (userName, password)
        {
            deferred = $q.defer();

            var data = "grant_type=password&username=" + userName + "&password=" + password;

            $http.post(loginServiceURL, data, {
                headers:
                   { "Content-Type": "application/x-www-form-urlencoded" }
            }).success(function (response)
            {
                var o = response;
                userInfo = {
                    accessToken: response.access_token,
                    userName: response.userName,
                    id: response.id,
                    nome: response.nome
                };

                authenticationService.setTokenInfo(userInfo);
                authData.authenticationData.isAuthenticated = true;
                authData.authenticationData.userName = response.userName;
                authData.authenticationData.id = response.id;
                authData.authenticationData.nome = response.nome;
                deferred.resolve(null);

                toastr.success("Sucesso");
            })
            .error(function (err, status)
            {
                authData.authenticationData.isAuthenticated = false;
                authData.authenticationData.userName = "";
                authData.authenticationData.id = 0;
                authData.authenticationData.nome = "";
                deferred.resolve(err);

                toastr.error("E-mail ou senha inválidos");
            });

            return deferred.promise;
        }

        this.logOut = function ()
        {
            authenticationService.removeToken();
            authData.authenticationData.isAuthenticated = false;
            authData.authenticationData.userName = "";
            authData.authenticationData.id = 0;
            authData.authenticationData.nome = "";
        }
    }
    ]);
})();