var app = angular.module("myModule", []);
app.controller("myController", function ($scope, $rootScope) {
    
    $scope.SendQuizData = function () {
        alert("anropats");
    };
    var Answers = [{ q: "", a0: "", a1: "", a2: "", a3: "", a4: "", ra: "" }];        
    $scope.Answers = Answers;
    var Quiz = [
        {
            Title: "",
            Answers: []
        }
    ];
    $scope.Quiz = Quiz;
    $scope.RightAnswer = { value: 0 };
    $scope.AddQuestion = function () {
        var value = $scope.RightAnswer.value;
        alert("right answer index = "+ value);
        var q = $scope.Answers.q
        alert("question= " + q);
        var a0 = $scope.Answers.a0
        alert("answer 1= " + a0);
        var a1 = $scope.Answers.a1
        alert("answer 2= " + a1);
        var a2 = $scope.Answers.a2
        alert("answer 3= " + a2);
        if($scope.Answers.a3)
        {
            alert($scope.Answers.a3);
        }
        else {
            alert("not declared");
        }
        if ($scope.Answers.a4) {
            alert($scope.Answers.a3);
        }
        else {
            alert("not declared");
        }
       // $scope.answers.q.push($scope.Answers.q);
        // $scope.Quiz.Answers.push(el);
    }
});