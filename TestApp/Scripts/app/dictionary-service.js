(function () {
    angular.module("contacts_app").service('dictionaryService', function ($http) {
        this.getItems = function (type) {
            return $http.get('/api/dictionaries/'+type);
        }
    });
}());