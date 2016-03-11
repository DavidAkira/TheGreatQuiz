var app = angular.module("myModule", []);
app.controller("myController", function ($scope, $rootScope) {
    
    $scope.SendQuizData = function () {
        //hämta ett värde
        var fråga = $scope.Quiz.Answers[0].q;
        alert(fråga);
    };
    var Answers = { q: "", ra: "", a0: "", a1: "", a2: "", a3: "", a4: "" };        
    $scope.Answers = Answers;

    // varje fråga som puchas till denna visas på AddQuiz sidan
    $rootScope.question = [];

    //spara quiz i $scope
    $scope.Quiz = [
        {
            Title: "",
            Answers: []
        }
    ];
    $scope.Quiz.Answers = [];

    // pusha en fråga till quizen
    $scope.AddQuestion = function () {
        var array = { q: "", ra: "", a0: "", a1: "", a2: "", a3: "", a4: "" };
        $rootScope.question.push($scope.Answers.q);
        array.q = $scope.Answers.q;
        // kan bara läsa av från de 3 första radio buttons
        array.ra = $scope.Answers.ra;
        array.a0 = $scope.Answers.a0;
        array.a1 = $scope.Answers.a1;
        array.a2 = $scope.Answers.a2;
        //hämta svar fyra samt fem
        if ($('.radio').length > 4) {
            array.a3 = $('.ettSvarsAlternativTill:first').val();
            array.a4 = $('.ettSvarsAlternativTill:last').val();
        }
        // hämta svar fyra
        else if ($('.radio').length > 3) {
            array.a3 = $('.ettSvarsAlternativTill').val();
        }
        // lägg till arrayen i quizen
        $scope.Quiz.Answers.push(array);
        alert("efter pushat");


        /*
        alert($('input[name=rättSvar]:checked', '#form').val());
        var value = $scope.Answers.ra;
        alert("right answer index = " + value);
        
        var radio = $('input[name=rättSvar]');
        var checkedValue = radio.filter(':checked').val();
        */
    }
});