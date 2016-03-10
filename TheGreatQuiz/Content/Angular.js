var app = angular.module("myModule", []);
app.controller("myController", function ($scope, $rootScope) {
    
    $scope.SendQuizData = function () {
        alert("anropats");
        //var quiz = [
        //{
        //    title: "NaturQuiz",
        //    questions: [
        //        { q: "vilken färg har himlen?", a0: "blå", a1: "vit", a2: "ingen", a3: "", a4: "", ra: 0 },
        //        { q: "vilken färg har gräd?", a0: "blå", a1: "grön", a2: "ingen", a3: brun, a4: "", ra: 2 },
        //        { q: "vilken färg har himlen?", a0: "blå", a1: "vit", a2: "ingen", a3: "roligt", a4: "", ra: 4 },
        //        { q: "hur gammal är solen?", a0: "5", a1: "vet inte", a2: "irrelevant", a3: "grattis", a4: "", ra: 3 },
        //        { q: "Hur hälsar man?", a0: "stick och brinn", a1: "nej tack", a2: "ingen", a3: "hej", a4: "hejsan", ra: 4 },
        //        { q: "vilken färg har himlen?", a0: "blå", a1: "vit", a2: "ingen", a3: "fel", a4: "rätt", ra: 1 }
        //    ]
        //}
        //];
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

    $rootScope.answers = [{ q: "hej" }];


    $scope.AddQuestion = function () {
        var el = [
            { q: $scope.q },
            { a0: $scope.a0 },
            { a1: $scope.a1 },
            { a2: $scope.a2 },
            { a3: "" },
            { a4: "" },
            { ra: 0 }
        ];
        $rootScope.answers.q.push($scope.Answers.q);
        $scope.Quiz.Answers.push(el);
    }
});