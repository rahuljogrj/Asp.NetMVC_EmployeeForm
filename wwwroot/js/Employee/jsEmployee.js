
 
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

function Delete() {

    var Id = $('#Id').val();

    var url1 = absURL('/Employee/Delete');
    $.ajax({
        url: url1,
        data: Id,
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
    //return `
    //    <div class="btn-group btn-group-sm">
    //        <a href="/Employee/Create?empid=${row.id}" class="btn btn-primary" style="font-size:12px;">
    //            <i class='bx bxs-comment-edit me-2'></i>Edit
    //        </a>
    //        <a href="/Employee/Delete/${row.id}" class="btn btn-danger" style="font-size:12px;">
    //            <i class='bx bx-message-x me-2'></i>Delete
    //        </a>
    //    </div>`;

    return `
        <div class="btn-group btn-group-sm">
            <a href="/Employee/Create?empid=${row.id}" class="me-2" style="font-size:12px;">
                <i class='bx bxs-comment-edit'></i>Edit 
            </a>
           <a href="/Employee/Delete/${row.id}" style="font-size:12px;">
                <i class='bx bx-message-x'></i> Delete
           </a>

        </div>`;

}

