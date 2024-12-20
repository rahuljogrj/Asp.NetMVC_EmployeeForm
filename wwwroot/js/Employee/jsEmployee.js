
 
function Submit() {

    if (elementValid('Header')) {

        var employeedata = {
            "id": "", "firstName": "", "lastName": "", "dateOfBirth": "", "email": "", "salary": ""
        }

        employeedata.id = $('#Id').val();
        employeedata.firstName = $('#FirstName').val();
        employeedata.lastName = $('#LastName').val();
        employeedata.dateOfBirth = $('#DateOfBirth').val();
        employeedata.email = $('#Email').val();
        employeedata.salary = $('#Salary').val();


        var url1 = absURL('/Employee/SaveData');
        $.ajax({
            url: url1,
            data: employeedata,

            type: "POST",
            dataType: "json",
            beforeSend: function () {
                dvajaxloadshow();
            },
            success: function (result) {
                alert(result.message);

                var url1 = "/Employee/Create";
                window.location.replace(absURL(url1));

            },
            complete: function () {
                dvajaxloadhide()
            },
        });
    }
}

function Delete(empid) {

    var url1 = absURL(`/Employee/Delete?empid=${empid}`);
    $.ajax({
        url: url1,
        type: 'GET',
        dataType: "json",

        beforeSend: function () {
            dvajaxloadshow();
        },
        success: function (result) {
            alert(result.message);

            var url1 = "/Employee/Create";
            window.location.replace(absURL(url1));
        },
        complete: function () {
            dvajaxloadhide()
        },

    });

};


function ActivateEmployee(empid) {

    var url1 = absURL(`/Employee/ActivateEmp?empid=${empid}`);
    $.ajax({
        url: url1,
        type: 'POST',
        dataType: "json",

        beforeSend: function () {
            dvajaxloadshow();
        },
        success: function (result) {
            alert(result.message);

            var url1 = "/Employee/Create";
            window.location.replace(absURL(url1));
        },
        complete: function () {
            dvajaxloadhide()
        },

    });

};





function operateFormatter(value, row, index) {
    return [
        '<div class="btn-group btn-group-sm">',
            `<a  href=/Employee/Create?empid=${row.id} class="empedit me-2" style="font-size:12px;">`,
                '<i class="bx bxs-comment-edit""></i>Edit',
            '</a>',
            '<a  href="javascript:void(0)" class="empdelete me-2" style="font-size:12px;">',
                '<i class="bx bx-message-x"></i> Delete',
            '</a>',
            '<a  href="javascript:void(0)" class="empactive me-2" style="font-size:12px;">',
                '<i class="bx bxs-comment-edit"></i> Active',
            '</a>',
        '</div>'
 
    ].join('')
}

window.operateEvents = {
 
    'click .empdelete': function (e, value, row, index) {
        var empid = row.id;
        if (row.statusID == "D") {
            alert("Employee already deleted");
            return false;
        }
        Delete(empid);
    },
    'click .empactive': function (e, value, row, index) {
        var empid = row.id;
        if (row.statusID == "A") {
            alert("Employee already Active");
            return false;
        }
        ActivateEmployee(empid);
    }
}



function edit(empid){


    var url1 = absURL(`/Employee/Ceate?empid=${empid}`);
    $.ajax({
        url: url1,
        type: 'GET',
        beforeSend: function () {
            dvajaxloadshow();
        },
        success: function (result) {
            alert(result.message);

             window.location.replace(absURL(url1));

        },
        complete: function () {
            dvajaxloadhide()
        },

    });

}



//function operateFormatter(value, row, index) {

//    return `
//        <div class="btn-group btn-group-sm">
//            <a href="/Employee/Create?empid=${row.id}" class="me-2" style="font-size:12px;">
//                <i class='bx bxs-comment-edit'></i>Edit 
//            </a>
//           <a href="/Employee/Delete/${row.id}" class="me-2" style="font-size:12px;">
//                <i class='bx bx-message-x'></i> Delete
//           </a>
//           <a href="/Employee/ActivateEmp/${row.id}" class="me-2" style="font-size:12px;">
//                <i class='bx bxs-comment-edit'></i> Active
//           </a>
//        </div>`;

//}




