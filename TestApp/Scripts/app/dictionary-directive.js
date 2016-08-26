(function () {
    'use strict';

    angular
        .module('contacts_app')
        .directive('dictionaryField', directive);

    directive.$inject = ['$window','dictionaryService'];

    function directive($window, dictionaryService) {
        function link(scope, element, attrs) {
            scope.allItems = [];
            dictionaryService.getItems(scope.dicType)
                .success(function(data) {
                    scope.allItems = data;
                });
        }
        return {
            link: link,
            templateUrl: "/AngularViews/directives/dictionary-field.html",
            restrict: 'E',
            scope: {
                field: "=?",
                dicType: "=?",
                fieldLabel: "=?",
                onChanged: "=?",
                required: "=?"
            }
        }


    }

})();