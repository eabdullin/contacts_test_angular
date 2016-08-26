(function () {
    angular.module("contacts_app").service('contactService', function ($http) {
        this.getContacts = function(page, countPerPage, filter) {
            filter.page = page;
            filter.countPerPage = countPerPage;
            if (filter.q === '') {
                filter.q = null;
            }
            console.log('contacts filter', filter);
            return $http.get('/api/contacts',
            {
                params: filter
            });
        };

        this.getContact = function(contactId) {
            return $http.get('/api/contacts/'+ contactId);
        };

        this.createContact = function(obj) {
            return $http.post('/api/contacts', obj);
        };
        this.editContact = function (id, obj) {
            return $http.put('/api/contacts/' + id, obj);
        };
        this.removeContact = function (id) {
            return $http.delete('/api/contacts/' + id);
        };
    });
}());