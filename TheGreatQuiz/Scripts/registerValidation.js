﻿
var elCompletRegBtn = document.getElementById('completRegistration');

var elEmail = document.getElementById('registerEmail');
var elPsw = document.getElementById('registerPassword');
var elSecondPsw = document.getElementById('registerSecondPassword');

function registerValidation(email, firstPassword, secondPassword) {
    var validEmail, validPassword;


    validEmail = EmailValidation(email, 'emailErrorDisplay');

    validPassword = PasswordValidation(firstPassword, secondPassword);

    // Do something if everything is valid.
    if (validEmail && validPassword) {       
        return true;
    }
    else {
        return false;
    }
}

elCompletRegBtn.addEventListener('click', function () {
    registerValidation(elEmail.value, elPsw.value, elSecondPsw.value);
}, false);




function EmailValidation(email, errorTextId) {
    var re = /^(([^<>()[\]\\.,;:\s@']+(\.[^<>()[\]\\.,;:\s@']+)*)|('.+'))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var validEmail = re.test(email);

    ErrorTextDisplay(errorTextId, validEmail ? 'clear' : 'Invalid email');
    return validEmail;
}



function PasswordValidation(firstPassword, secondPassword) {

    var regex = /^[a-z0-9]+$/i;
    var searchedValue = firstPassword.search(regex);

    if (searchedValue <= -1) {
        ErrorTextDisplay('passwordErrorDisplay', 'Invalid Password');
        return false;
    } else if (firstPassword === secondPassword) {
        ErrorTextDisplay('passwordErrorDisplay', 'clear');
        return true;
    } else {
        ErrorTextDisplay('passwordErrorDisplay', 'Passwords does not match');
        return false;
    }

}



function ErrorTextDisplay(id, text) {
    $(function () {
        if (text === 'clear') {
            $('#' + id).slideUp(500);
        } else {
            $('#' + id).text(text).slideDown(650);
        }
    });
}

$('.errorText').hide();