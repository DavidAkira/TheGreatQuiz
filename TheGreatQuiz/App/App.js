var app = angular.module('myApp', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: '/App/Views/StartPage.html',
        controller: 'StartPageController'
    }).
    when('/sendData', {
        templateUrl: '/App/Views/sendData.html',
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
    console.log(123);

    var arr = ["test1", "test2"];
    var jsonData = JSON.stringify({ arr: arr});

    $scope.sendDataFunc = function () {
        $(function () {
            $.ajax({
                type: "POST",
                url: "/Home/angularTestData",
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                error: OnErrorCall
            });

            function OnSuccess(response) {
                console.log(response.d)
            }

            function OnErrorCall(response) { console.log(error); }

        });
    }

    //$http({
    //    method: 'POST',
    //    url: '/Home/angularTestData',
    //    data: ["test1", "test2"],
    //    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
    //});
}]);


