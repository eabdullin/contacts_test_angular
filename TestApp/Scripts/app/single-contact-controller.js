(function () {
    'use strict';

    angular
        .module('contacts_app')
        .controller('singleContactController', controller);

    controller.$inject = ['$scope', '$mdDialog', 'contactService', 'contactId'];

    function controller($scope, $mdDialog, contactService, contactId) {
        $scope.contact = {};
        if (contactId) {
            $scope.contactId = contactId;
            contactService.getContact(contactId).success(function (data) {
                $scope.contact = data;
            });
        }
        $scope.submit = function () {
            var def = null;
            if ($scope.contactId) {
                def = contactService.editContact($scope.contactId, $scope.contact);
            } else {
                def = contactService.createContact($scope.contact);
            }
            def.success(function () {
                $mdDialog.hide($scope.contact);
                $scope.contact = {};
            });
        };
        $scope.cancel = function () {
            $mdDialog.cancel();
        };

    }
})();
