﻿$(function () {

    $('.continueButton').on('click', function () {

        if ($('#quizTitle').val().length > 0 & $('#startDate').val().length > 0 & $('#lastDate').val().length > 0 & $('#minits').val() >= 10) {
            $('.färdigaSvar').show();
            $('.testPage').show();
            $('.quizHeader').hide(); 
        }
        else {
        }

    });

    $(".queAnswer").on('keyup', function () {
        Update();
    });
    $(".question").on('keyup', function () {
        Update();
    })
    var Update = function () {
        var ifInputIsInitialized = true;
        $(".queAnswer").each(function () {
            if (this.value == "") {
                ifInputIsInitialized = false;
            }
            else {

            }
        });
        if (ifInputIsInitialized) {
            val = $('.question').val();
            if (val != "") {
                //alert("alla fält ifyllda");

            }
        }
    };

    var UpdateIndex = function () {
        $('.ettSvarsAlternativTill').removeClass('4').addClass('3');
        var radio =  $('.radio:last');
        radio.removeClass('4').addClass('3');
        radio.attr('ng-value', '3');
        var el = $('.remove');
        el.removeClass('4').addClass('3');
        el.attr('id', '3');
    };


    // add elements
    $('#addQuestion').on('click', function () {
        AddButton();
    });
    function AddButton() {
                         
        var antalSvar = $('.radio').length;
        var radio = "<input class=\"radio " + antalSvar + "\" type=\"radio\" name=\"rättSvar\" ng-value=\"" + antalSvar + "\" ng-model=\"RightAnswers\" />";
        var text = "<input class=\"ettSvarsAlternativTill queAnswer " + antalSvar + "\"type=\"text\" placeholder=\"Skriv in ett svar här...\" ng-model=\"Answers.a" + antalSvar + "\" />";
        var button = "<input id=\"" + antalSvar + "\" class=\"" + antalSvar + " remove\" type=\"button\" value=\"x\" />";
        var lastEl = $('#addQuestion');
        lastEl.before("<span>" + text + radio + button + "</span>");
        $(".queAnswer:last").on('keyup', function () {
            Update();
        });
        //remove addbutton
        if ($('.radio').length > 4) {
            $('#addQuestion').hide();
        }
        // attache remove event
        $('.remove:last').on('click', function () {
            var aktivId = $(this).attr('id');
            switch (aktivId) {
                case '3':
                    $('.3').remove();
                    if ($('.radio').length > 3) {
                        UpdateIndex();
                    }
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





