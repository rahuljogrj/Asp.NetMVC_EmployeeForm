
var controller; 
var count;

$(document).ready(function () {
    var path = window.location.pathname;

    var segments = path.split('/');

    var controllerName = segments[1]; // Assuming a standard ASP.NET MVC structure

    controller = controllerName;
    count= countRecord();
    $("#CountText").text(`Total ${controllerName} Record`);

})

document.addEventListener("DOMContentLoaded", function (event) {

    const showNavbar = (toggleId, navId, bodyId, headerId) => {
        const toggle = document.getElementById(toggleId),
            nav = document.getElementById(navId),
            bodypd = document.getElementById(bodyId),
            headerpd = document.getElementById(headerId)

        // Validate that all variables exist
        if (toggle && nav && bodypd && headerpd) {
            toggle.addEventListener('click', () => {
                // show navbar
                nav.classList.toggle('show')
                // change icon
                toggle.classList.toggle('bx-x')
                // add padding to body
                bodypd.classList.toggle('body-pd')
                // add padding to header
                headerpd.classList.toggle('body-pd')
            })
        }
    }

    showNavbar('header-toggle', 'nav-bar', 'body-pd', 'header')

    /*===== LINK ACTIVE =====*/

    $('.nav_link').each(function () {
        var linkUrl = $(this).find('a');

        // Check if the current URL matches the link
        if (linkUrl && currentUrl.includes(linkUrl)) {
            $('.nav_link').removeClass('active'); // Ensure no duplicates
            $(this).addClass('active');
        }
    });


 
    // Your code to run since DOM is loaded and ready
});

setTimeout(function () {
    $('.alert').alert('close');
}, 2000);

        // Handle click event for navigation links
$('.nav_link').on('click', function (e) {

    $('.nav_link').removeClass('active');

    $(this).addClass('active');
});

    // Maintain active state on page load based on current URL
    var currentUrl = window.location.pathname;

$('.nav_link').each(function () {
    var linkUrl = $(this).attr('href');

    // Check if the current URL matches the link
    if (linkUrl && currentUrl.includes(linkUrl)) {
        $('.nav_link').removeClass('active'); // Ensure no duplicates
        $(this).addClass('active');
    }
});

function countRecord()
{
    if (controller != "") {

        var url1 = absURL(`/${controller}/GetCountRecord`);
        $.ajax({
            url: url1,
            type: 'POST',
            dataType: "json",

            beforeSend: function () {
                dvajaxloadshow();
            },
            success: function (result) {

                count = result.count;
                if (count == undefined) {
                    count = "--";
                }
                $('#CountRecord strong').text(`${count}`);

                console.log(`Count: ${count}`);

            },
            complete: function () {
                dvajaxloadhide()
            },

        });
    }
    else {
        $('#CountRecord strong').text("--");

    }
}

function absURL(strpath) {
    var baseUrl = "";
    baseUrl = $("#HiddenCurrentUrl").val();
    baseUrl = baseUrl + strpath;
    return baseUrl;
}
 
function elementValid(parentId) {
    let isValid = true;
    var messageList = [];
    var message = "";
    var count = 0;

    // Select the parent container
    const parent = $('#' + parentId);

    const requiredFields = parent.find('input[data-required="true"]');

    requiredFields.each(function () {
        const field = $(this);

        if ($.trim(field.val()) === '') {
            count += 1;
            messageList.push(count + ") " + $(this).data('message'));
            message += count + ") " + $(this).data('message') + "\n";
             isValid = false; 
        }
        if ($(this).is("[data-ele-email='true']")) {
            jVal.email($(this));
        }

    });

    if (isValid == false) {
        showToast(messageList);
        //alert(message);
        return false;
    }

    return isValid;  
}

function isNumeric(event) {
    var charCode = event.which ? event.which : event.keyCode;

    // Allow only numeric characters, backspace (8), delete (46), and enter (13)
    if (charCode == 8 || charCode == 46 || charCode == 13 || (charCode >= 48 && charCode <= 57)) {
        return true;
    } else {
        // Prevent other characters
        event.preventDefault();
        return false;
    }
}


function showToast(messages) {
    // Join all messages into a string with line breaks
    const message = messages.join('<br>');
    $('#validationMessage .toast-body').html(message);  // Display the messages in the toast body
    var toastElement = new bootstrap.Toast(document.getElementById('validationMessage'));
    toastElement.show();
}

function dvajaxloadshow() {

    $("#dvajax").show();
}

function dvajaxloadhide() {

    $("#dvajax").hide();
}
