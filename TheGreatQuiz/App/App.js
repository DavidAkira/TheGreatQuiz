var app = angular.module('myApp', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: '/App/Views/StartPage.html',
        controller: 'StartPageController'
    });
}]);



app.controller('StartPageController', ['$http', '$scope', function ($http, $scope) {
    $http.get('GetPeople').success(function (data) {
        console.log(data);
    });
}]);



