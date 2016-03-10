var app = angular.module("myModule", []);
app.controller("myController", function ($scope, $rootScope) {
    var answers = [
        { id: 0, text: "god" },
        { id: 1, text: "morgon" },
        { id: 2, text: "på" },
        { id: 3, text: "dig" }
    ];
    $scope.Question = "";
    $rootScope.answers = answers;
    $scope.AddQuestion = function () {
        var antalElement = $scope.answers.length;      
        var el = { id: antalElement, text: $scope.Question }
        $rootScope.answers.push(el);
    }
});