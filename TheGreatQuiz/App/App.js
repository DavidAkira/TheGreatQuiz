var app = angular.module('myApp', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: '/App/Views/StartPage.html',
        controller: 'StartPageController'
    }).
    when('/sendData', {
        templateUrl: '/App/Views/StartPage.html',
        controller: 'sendDataController'
    });
}]);



app.controller('StartPageController', ['$http', '$scope', function ($http, $scope) {
    $http.get('/Home/QuestionsTest').success(function (data) {
        console.log(data);
        $scope.testData = data[0];
    });
}]);


app.controller('sendDataController', ['$http', '$scope', function ($http, $scope) {

}]);


