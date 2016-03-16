var app = angular.module('ResultApp', []);

app.controller('ResultPageController', ['$scope', '$http', function ($scope, $http) {

    $http.get("/Home/ResultPageQuizData").success(function (data) {
        $scope.quizData = data;

    });


    $(function () {
        var elQuizSelector = document.getElementById('selectQuiz');

        $('#selectQuiz').change(function () {
            var optionValue = elQuizSelector.options[elQuizSelector.selectedIndex].value;

            var arr = [optionValue]

            var jsonData = JSON.stringify({ arr: arr });

            $.ajax({
                type: "POST",
                url: "/Home/ResultPageOtherData",
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(data){
                    OnSuccess(data);
                },
                error: OnErrorCall
            });


            function OnErrorCall(response) { console.log(error); }


        });

    });


    function OnSuccess(data) {
        console.log(data);
        $scope.test1 = 123;
    }





}]);