(function() {

    var app = angular.module("myQuiz",[]);

    app.controller("QuizController", ["$scope", "$http", "$sce", function($scope, $http, $sce) {

        $scope.score = 0;
        $scope.activeQuestion = -1;
        $scope.activeQuestionAnswered = 0;
        $scope.percentage = 0;

        $http.get("http://localhost:3434/JsonData/Quiz.json").then(function (quizData) {
            $scope.myQuestions = quizData.data;
            $scope.totalQuestions = $scope.myQuestions.length;
        });

        $scope.selectAnswer = function(questionIndex, answerIndex) {

            var questionState = $scope.myQuestions[questionIndex].questionState;

            if (questionState != "answered") {
                $scope.myQuestions[questionIndex].selectedAnswer = answerIndex;
                var correctAnswer = $scope.myQuestions[questionIndex].correct;
                $scope.myQuestions[questionIndex].correctAnswer = correctAnswer;

                if (answerIndex === correctAnswer) {
                    $scope.myQuestions[questionIndex].correctness = "correct";
                    $scope.score += 1;
                } else {
                    $scope.myQuestions[questionIndex].correctness = "incorrect";
                }
                $scope.myQuestions[questionIndex].questionState = "answered";
            }
            $scope.percentage = (($scope.score / $scope.totalQuestions) * 100).toFixed(0);
        }

        $scope.isSelected = function (questionIndex, answerIndex) {
            return $scope.myQuestions[questionIndex].selectedAnswer === answerIndex;
        }
        $scope.isCorrect = function (questionIndex, answerIndex) {
            return $scope.myQuestions[questionIndex].correctAnswer === answerIndex;
        }
        $scope.selectContinue = function () {
            if ($scope.activeQuestion === ($scope.totalQuestions - 1)) {
                var choice = confirm("Detta är sista frågan är du säker på att du vill avsluta och se ditt resultat?");
                if (choice === true) {
                    return $scope.activeQuestion += 1;
                } else {
                    return 0;
                }
            }else {
                return $scope.activeQuestion += 1;
            }
        }
        $scope.selectPrevious = function () {
            if ($scope.activeQuestion >= 1) {
            return $scope.activeQuestion -= 1;                
            }
        }

    }]);


})();