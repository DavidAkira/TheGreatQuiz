$(function () {

    $('.quizButton').on('click', function () {
        // validate
        if (true) {
            var quizTitle = $('.tittel').val();
            alert(quizTitle);

            var question = $('.question').val();
            alert(question);

            $('.svarsAlternativ').each(function (index) {
                var answer = $(this).val();
                alert("Answer" + index + "= " + answer);
            })
            var answer1 = $(':text.0').val();
            alert(answer1);
        }
    });



    // add elements
    $('#addQuestion').on('click', function () {
        AddButton();
    });
    function AddButton() {

        var antalSvar = $('.radio').length;
        var radio = "<input class=\"radio " + antalSvar + "\" type=\"radio\" name=\"rättSvar\" value=\"" + antalSvar + "\" />";
        var text = "<input class=\"ettSvarsAlternativTill " + antalSvar + "\"type=\"text\" placeholder=\"Skriv in ett svar här...\" ng-model=\"Answers.a"+ antalSvar+ "\" />";
        var button = "<input id=\"" + antalSvar + "\" class=\"" + antalSvar + " remove\" type=\"button\" value=\"x\" />";
        var lastEl = $('#addQuestion');
        lastEl.before("<span>" + text + radio + button + "</span>");

        //remove addbutton
        if ($('.radio').length > 4) {
            // $('#addQuestion').remove();
            $('#addQuestion').hide();
        }
        // attache remove event
        $('.remove:last').on('click', function () {
            var aktivId = $(this).attr('id');
            switch (aktivId) {
                case '0':
                    $('.0').remove();
                    break;
                case '1':
                    $('.1').remove();
                    break;
                case '2':
                    $('.2').remove();
                    break;
                case '3':
                    $('.3').remove();
                    break;
                case '4':
                    $('.4').remove();
                    break;
                default:
                    break;
            };
            if ($('.radio').length == 4) {
                $('#addQuestion').show();
            }
        });
    }
});
/*
function RemoveElementsEvent() {
    var aktivId = $(this).attr('id');
    switch (aktivId) {
        case '0':
            $('.0').remove();
            break;
        case '1':
            $('.1').remove();
            break;
        case '2':
            $('.2').remove();
            break;
        case '3':
            $('.3').remove();
            break;
        case '4':
            $('.4').remove();
            break;
        default:
            break;
    }
    if ($('.radio').length == 4) {
        AddButtonEvent();
        
        var lastEl = $('.remove');
        var newEl="<input id=\"addQuestion\" type=\"button\" value=\"+\" />"; 
        lastEl.after(newEl);
    }
};
}
});/*

function AddElementsEvent() {
var antalSvar = $('.radio').length;
var radio = "<input class=\"radio " + antalSvar + "\" type=\"radio\" name=\"rättSvar\" value=\"" + antalSvar + "\" />";
var text = "<input class=\"ettSvarsAlternativTill " + antalSvar + "\"type=\"text\" placeholder=\"Skriv in ett svar här...\" />";
var button = "<input id=\"" + antalSvar + "\" class=\"" + antalSvar + " remove\" type=\"button\" value=\"x\" />";
var lastEl = $('#addQuestion');
lastEl.before("<span>" + radio + text + button + "</span>");

if ($('.radio').length > 4) {
$('#addQuestion').remove();
}
$('.remove:last').on('click', function () {
RemoveElementEvent();
});
};
function AddButtonEvent() {
var lastEl = $('.remove');
var newEl = "<input id=\"addQuestion\" type=\"button\" value=\"+\" />";
lastEl.after(newEl);
$('#addQuestion').on('click', function () {
AddElementsEvent();
});
};*/

//remove element  
/*
function RemoveElementEvent(id) {
    alert(id);
    switch (id) {
        case '0':
            $('.0').remove();
            break;
        case '1':
            $('.1').remove();
            break;
        case '2':
            $('.2').remove();
            break;
        case '3':
            $('.3').remove();
            break;
        case '4':
            $('.4').remove();
            break;
        default:
            break;
    }
};*/





