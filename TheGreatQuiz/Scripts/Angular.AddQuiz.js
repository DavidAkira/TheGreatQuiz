﻿var app = angular.module("myModule", []);
app.controller("myController", function ($scope, $rootScope, $window) {
    
    
    // $('#saveQuizBtn, #addQuestionBtn').hide();

    // varje fråga som puchas till denna visas på AddQuiz sidan
    $rootScope.question = [];

    $scope.RightAnswer = 0;


    var quizData = [[]];
    var elQuizTitle = document.getElementById('quizTitle');


    //elQuizTitle.addEventListener('blur', function () {
    //    //fix error controll
    //    quizData[0][0] = elQuizTitle.value;
    //});


    $(function () {
        $(".continueButton").click(function () {
            quizData[0][0] = elQuizTitle.value;
            quizData[0][1] = $("#startDate").val();
            quizData[0][2] = $("#lastDate").val();
            quizData[0][3] = $("#minits").val();
            quizData[0][4] = elCheckBox = document.getElementById("showAnswersCheckbox").checked;

            console.log(quizData);

        });
    });





    $scope.DateAndTime = { firstDate: "", lastDate: "", time: "" }
    $scope.AddQuestion = function () {

        var noEmptyAnswers = false;
        var noEmptyQuestion = false;

        var rightAnswer;
        var answers = ["", "", "", "", ""];

        $(".radio").each(function (i) {
            if (this.checked) {
                rightAnswer = i;
            }
        });

        $(".queAnswer").each(function (i) {
            if (!this.value) {
                noEmptyAnswers = true;
                console.log("fel");
            }
            else {
                answers[i] = this.value
            }

        });
        //alert($scope.DateAndTime.firstDate);
        //alert($scope.DateAndTime.lastDate);
        //alert($scope.DateAndTime.time);

        console.log($(".question").val());

        if ($(".question").val() === "") {
            noEmptyQuestion = true;
        }

        var UpdateInnput = function(){
            $(".queAnswer").val('');
            $(".question").val('');
        }
        if (!noEmptyAnswers && !noEmptyQuestion) {
            quizData.push([$scope.Answers.q, rightAnswer, answers[0], answers[1], answers[2], answers[3], answers[4]]);
            $rootScope.question.push($scope.Answers.q);
            UpdateInnput();
            $('.errorLabel').hide();
        }
        else {
            $('.errorLabel').show();
        }
        
        
        

        console.log(quizData);
    }
    $scope.RemoveQuestion = function (questiion) {
        var questionIndex = $rootScope.question.indexOf(questiion);
        // alert(indexFörFrågan);

        quizData.splice([(questionIndex + 1)], 1);
        $rootScope.question.splice(questionIndex, 1);
        console.log(quizData);
    }



    $scope.SendQuizData = function () {

        console.log(123);
        var jsonData = JSON.stringify({ quizData: quizData });
        console.log(jsonData);

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
                console.log(response.d);
                $window.location.href = "AdminHome";
            }

            function OnErrorCall(response) { console.log(error); }

        });
    }





});