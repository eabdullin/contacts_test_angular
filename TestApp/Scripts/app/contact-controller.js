(function () {
    'use strict';

    angular
        .module('contacts_app')
        .controller('contactController', controller);

    controller.$inject = ['$location', '$scope', '$http', '$routeParams', 'contactService', '$timeout', '$mdDialog'];

    function controller($location, $scope, $http, $routeParams, contactService, $timeout,$mdDialog) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'contactController';
        $scope.currentPage = 0;
        $scope.countPerPage = 10;
        $scope.totalCount = 0;
        $scope.contacts = [];
        $scope.filter = {};
        $scope.currentContactIndex = null;
        $scope.clearFilter = function() {
            $scope.filter = {};
            $scope.updateData(true);
        }
        $scope.nextPage = function() {
            $scope.currentPage += 1;
            $scope.updateData(false);
        };
        $scope.prevPage = function () {
            $scope.currentPage -= 1;
            $scope.updateData(false);
        };
        $scope.showDeleteConfirm = function (ev, id, index) {
            // Appending dialog to document.body to cover sidenav in docs app
            var confirm = $mdDialog.confirm()
                  .title('Would you like to delete this contact?')
                  .textContent('All of information about this contact will be deleted permanently.')
                  .targetEvent(ev)
                  .ok('YES')
                  .cancel('NO');

            $mdDialog.show(confirm).then(function () {
                contactService.removeContact(id).success(function () {
                    $scope.contacts.splice(index, 1);
                });
            });
        };
        //Update search
        $scope.showSingleContact = function (ev, id, index) {
            $scope.currentContactIndex = index;
            $mdDialog.show({
                controller: "singleContactController",
                locals: {
                     contactId: id
                },
                templateUrl: '/AngularViews/dialogs/single-contact.html',
                parent: angular.element(document.body),
                targetEvent: ev,
                clickOutsideToClose: true,
                fullscreen: $scope.customFullscreen // Only for -xs, -sm breakpoints.,

            })
            .then(function (contact) {
                $scope.contacts[$scope.currentContactIndex] = contact;
            });
        };
        $scope.updateData = function (newSearch) {
            if (newSearch) {
                $scope.currentPage = 0;
                $scope.countPerPage = 10;
                $scope.totalCount = 0;
                $scope.contacts = [];
            }
            $timeout(function () {
                contactService.getContacts($scope.currentPage, $scope.countPerPage, $scope.filter).success(function (data) {
                    $scope.totalCount = data.totalCount;
                    $scope.contacts = data.items;
                    $scope.isListEmpty = $scope.contacts.length === 0;
                });
            });

        };

        $scope.newSearch = function () {
            $scope.updateData(true);
        }

        $scope.updateData(true);
    }
})();
