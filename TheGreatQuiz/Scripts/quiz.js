﻿(function() {

    var app = angular.module("myQuiz",[]);

    app.controller("QuizController", ["$scope", "$http", function($scope, $http) {

        var quizTimer = 0;

        //$scope.showAnswers = false;
        $scope.score = 0;
        $scope.activeQuestion = -1;
        $scope.activeQuestionAnswered = 0;
        $scope.percentage = 0;

        $http.get("/Home/QuestionsTest").success(function (quizData) {
            $scope.myQuestions = quizData;
            $scope.totalQuestions = quizData.length;
        });

        $http.get("/Home/LoadQuizData").success(function (data) {
            
            $scope.quizTitle = data.Name;             
            quizTimer = data.QuizTimer;
            $scope.showAnswers = data.ShowAnswers;
            console.log(data);
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
        $scope.showOrNot = function() {
            if (showAnswers === true) {
                
            }
        }

        var blockUserFromQuiz = function () {
            $http.get("/Home/quizEnded").success(function (data) {
                console.log(data);
            });
        }
        var UpdateUserScore = function () {
            var arr = []
            arr[0] = $scope.score;
            arr[1] = $scope.totalQuestions;

            var jsonData = JSON.stringify({ arr: arr });

            $.ajax({
                type: "POST",
                url: "/Home/QuizEndUpdateScore",
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                },
                error: OnErrorCall
            });

            //function OnSuccess(response) {
            //    console.log(response);
            //}

            function OnErrorCall(response) { console.log(error); }
        }

        $('#endQuizBtn').click(function () {
            blockUserFromQuiz();
            UpdateUserScore();
        });

        $("#start-btn").click(function () {
            console.log("kom en bit");
            startTimer(quizTimer, 0, function () {
                blockUserFromQuiz();
                stopTimer();
                alert("Testet är slut");
            });
        });




    }]);


})();