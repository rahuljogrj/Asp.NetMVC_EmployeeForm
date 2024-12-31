



function signup() {


    if (elementValid('SignUpMainDiv')) {
        var registerLinks = {
            "FirstName": "", "LastName": "", "Emaill": "", "PhoneNumber": "", "Username": "", "Password": "","ConfirmPassword":""
        }

        registerLinks.FirstName = $('#RFirstName').val();
        registerLinks.LastName = $('#RLastName').val();
        registerLinks.Emaill = $('#REmail').val();
        registerLinks.PhoneNumber = $('#RPhoneNumber').val();
        registerLinks.Username = $('#RUsername').val();
        registerLinks.Password = $('#RPassword').val();
        registerLinks.ConfirmPassword = $('#RConfirmPassword').val();


        if (registerLinks.Password != registerLinks.ConfirmPassword) {
            alert("Password not match...");
            return false;
        }

        url1 = absURL("/LogIn/Register");
        $.ajax({
            url: url1,
            data: registerLinks,
            type: "POST",
            async: true,
            dataType: "json",
            beforeSend: function () {
                dvajaxloadshow();
            },
            success: function (result) {
                alert(result.message);

                if (result.isSuccess) {
                    var url1 = "/LogIn/LogIn";
                    window.location.replace(absURL(url1));
                }

            },
            complete: function () {
                dvajaxloadhide()
            },
        });

    }

}


function login() {

    if (elementValid('loginMainDiv')) {
        var registerLinks = {
           "Username": "", "Password": ""
        }

        registerLinks.Username = $('#Username').val();
        registerLinks.Password = $('#Password').val();

        url1 = absURL("/LogIn/LoginCheck");
        $.ajax({
            url: url1,
            data: registerLinks,
            type: "POST",
            async: true,
            dataType: "json",
            beforeSend: function () {
                dvajaxloadshow();
            },
            success: function (result) {
                if (!result.isSuccess) {
                    alert(result.message);
                }
                if (result.isSuccess) {
                    var url1 = "/Home/Index";
                    window.location.replace(absURL(url1));
                }

            },
            complete: function () {
                dvajaxloadhide()
            },
        });

    }
}
