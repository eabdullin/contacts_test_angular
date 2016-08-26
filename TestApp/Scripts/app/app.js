(function () {
    'use strict';

    var contactsApp = angular.module('contacts_app', [
        // Angular modules 
        'ngRoute',
        'ngMaterial'
        // Custom modules 

        // 3rd Party Modules
        
    ]);

    contactsApp.config(["$routeProvider","$locationProvider",function ($routeProvider, $locationProvider) {


        $routeProvider
            .when('/', {
                templateUrl: '/AngularViews/contacts.html'
            }).otherwise({
                redirectTo: '/'
            });

        $locationProvider
            .html5Mode({
                enabled: true,
                requireBase: false
            });
    }]);
})();