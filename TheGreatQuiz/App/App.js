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


    var arr = [
        [
            "QuizName"
        ],

        [
        "Fråga 1, Hur gör djur?",
        1,
        "Fråga 1. Svar 1",
        "Fråga 1. Svar 2",
        "Fråga 1. Svar 3",
        "Fråga 1. Svar 4",
        ""
        ],

        [
           "Fråga 2, Hej på dig",
           1,
           "Fråga 2. Svar 1",
           "Fråga 2. Svar 2",
           "Fråga 2. Svar 3",
           "Fråga 2. Svar 4",
           "Fråga 2. Svar 5"
        ],

        [
           "Fråga 3, Det här är fråga 3",
           2,
           "Fråga 3. Svar 1",  
           "Fråga 3. Svar 2",  
           "Fråga 3. Svar 3",  
           "Fråga 3. Svar 4",  
           "Fråga 3. Svar 5"
        ]

    ];




    //var arr = 
    //    {
    //        name: "QuizNamn",
    //        title: "Fråga 1, Hur gör djur?",
    //        correctAnswer: 1,
    //        answers1: "Fråga 1. Svar 1",
    //        answers2: "Fråga 1. Svar 2",
    //        answers3: "Fråga 1. Svar 3",
    //        answers4: "Fråga 1. Svar 4",
    //        answers5: ""
    //    }
    

    var jsonData = JSON.stringify({ arr: arr });

    console.log(jsonData);

    $scope.sendDataFunc = function () {
        console.log(123);
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


