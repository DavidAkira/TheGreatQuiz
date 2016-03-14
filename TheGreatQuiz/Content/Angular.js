var app = angular.module("myModule", []);
app.controller("myController", function ($scope, $rootScope) {
    

    // varje fråga som puchas till denna visas på AddQuiz sidan
    $rootScope.question = [];

    $scope.RightAnswer = 0;
      
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
        $rootScope.question.push($scope.Answers.q);
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
    $scope.RemoveQuestion = function (questiion) {
        var indexFörFrågan = $rootScope.question.indexOf(questiion);
        // alert(indexFörFrågan);
        quizData.slice(indexFörFrågan, 1);
        $rootScope.question.splice(indexFörFrågan, 1);
        console.log(quizData);
    }
});