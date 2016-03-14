var app = angular.module("myModule", []);
app.controller("myController", function ($scope, $rootScope) {
    
    //$scope.SendQuizData = function () {
    //    alert("anropats");
    //};
    //var Answers = [{ q: "", a0: "", a1: "", a2: "", a3: "", a4: "", ra: "" }];        
    //$scope.Answers = Answers;
    //var Quiz = [
    //    {
    //        Title: "",
    //        Answers: []
    //    }
    //];
    //$scope.Quiz = Quiz;
    //$scope.RightAnswer = { value: 0 };
    //$scope.AddQuestion = function () {
    //    var value = $scope.RightAnswer.value;
    //    alert("right answer index = "+ value);
    //    var q = $scope.Answers.q
    //    alert("question= " + q);
    //    var a0 = $scope.Answers.a0
    //    alert("answer 1= " + a0);
    //    var a1 = $scope.Answers.a1
    //    alert("answer 2= " + a1);
    //    var a2 = $scope.Answers.a2
    //    alert("answer 3= " + a2);
    //    if($scope.Answers.a3)
    //    {
    //        alert($scope.Answers.a3);
    //    }
    //    else {
    //        alert("not declared");
    //    }
    //    if ($scope.Answers.a4) {
    //        alert($scope.Answers.a3);
    //    }
    //    else {
    //        alert("not declared");
    //    }
    //   // $scope.answers.q.push($scope.Answers.q);
    //    // $scope.Quiz.Answers.push(el);
    //}

    var quizData = [];

    var elQuizTitle = document.getElementById('quizTitle');

    elQuizTitle.addEventListener('blur', function () {
        if (quizData[0] === undefined) {
            quizData.push([elQuizTitle.value]);
        }
        else {
            quizData[0][0] = elQuizTitle.value;
        }
   
    });

    $scope.AddQuestion = function () {

        var rightAnswer;
        var answers = ["", "", "", "", ""];
        
        $(".radio").each(function (i) {
            if (this.checked) {
                rightAnswer = i;
            }
        });

        //console.log(rightAnswer);

        $(".queAnswer").each(function (i) {
            if (!this.value) {
                //Print error
        }
            else {
                answers[i] = this.value;
        }
        });

        quizData.push([$scope.Answers.q, rightAnswer, answers[0], answers[1], answers[2], answers[3],  answers[4]]);


        console.log(quizData);

    }




















});