﻿(function() {

    var app = angular.module("myQuiz",[]);

    app.controller("QuizController", ["$scope", "$http", function($scope, $http) {

        $scope.score = 0;
        $scope.activeQuestion = -1;
        $scope.activeQuestionAnswered = 0;
        $scope.percentage = 0;

        $http.get("/Home/QuestionsTest").success(function (quizData) {
            $scope.myQuestions = quizData;
            $scope.totalQuestions = quizData.length;
        });

        $scope.selectAnswer = function(questionIndex, answerIndex) {

            var questionState = $scope.myQuestions[questionIndex].questionState;

            if (questionState != "answered") {
                $scope.myQuestions[questionIndex].selectedAnswer = answerIndex;
                var correctAnswer = $scope.myQuestions[questionIndex].CorrectAnswer;
                $scope.myQuestions[questionIndex].CorrectAnswer = correctAnswer;

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
            return $scope.myQuestions[questionIndex].CorrectAnswer === answerIndex;
        }

        $scope.selectContinue = function () {
          
                return $scope.activeQuestion += 1;
        }
        $scope.selectPrevious = function () {
            if ($scope.activeQuestion >= 1) {
            return $scope.activeQuestion -= 1;                
            }
            return 0;
        }
        $scope.exitQuiz = function() {
            $window.location.path("/Home/Portal.cshtml");
        }


        var blockUserFromQuiz = function () {
            $http.get("/Home/quizEnded").success(function (data) {
                console.log(data);
            });
        }

        $('endQuizBtn').click(function () {
            blockUserFromQuiz();
        });

        $("#start-btn").click(function () {
            console.log("kom en bit");
            startTimer(0, 5, function () {
                blockUserFromQuiz();
                stopTimer();
                alert("Testet är slut");
            });
        });




    }]);


})();