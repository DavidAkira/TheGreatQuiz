
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


        var arr = [email, firstPassword];

        var jsonData = JSON.stringify({ arr: arr });

            $(function () {
                $.ajax({
                    type: "POST",
                    url: "/Home/RegisterUser",
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    error: OnErrorCall
                });

                function OnSuccess(response) {
                    console.log(response.d)
                }

                function OnErrorCall(response) { console.log(error); }
            });
            return true;
    }

    return false;

}
$(".completRegistrationButton").on("click", function (event) {
    event.preventDefault();
    if (registerValidation(elEmail.value, elPsw.value, elSecondPsw.value)) {
        document.location.href = "Index";
    }
});

//elCompletRegBtn.addEventListener("submit", function (event) {
//    $(".completRegistrationButton").submit(false);
//    registerValidation(elEmail.value, elPsw.value, elSecondPsw.value);
//    document.location.href = "Index";
//}, false);




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