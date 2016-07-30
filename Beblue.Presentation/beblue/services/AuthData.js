"use strict";

app.factory("authData", [function ()
{
    var authDataFactory = {};

    var _authentication = {
        isAuthenticated: false,
        userName: "",
        id: 0,
        nome: ""
    };

    authDataFactory.authenticationData = _authentication;

    return authDataFactory;
}]);