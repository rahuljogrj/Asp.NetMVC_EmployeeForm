



function operateFormatterDesig(value, row, index) {
    return [
        '<div class="btn-group btn-group-sm">',
        `<a  href=/Designation/Create?DesignationId=${row.id} class="empedit me-2" style="font-size:12px;">`,
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

window.operateEventsDesig = {

    'click .empdelete': function (e, value, row, index) {
        var DesignationID = row.id;
        if (row.status == "D") {
            alert("Designation already deleted");
            return false;
        }
        Delete(DesignationID);
    },
    'click .empactive': function (e, value, row, index) {
        var DesignationID = row.id;
        if (row.status == "A") {
            alert("Designation already Active");
            return false;
        }
        ActivateEmployee(DesignationID);
    }
}


function Delete(DesignationID) {
    var url = absURL("/Designation/Delete?DesignationId=" + DesignationID);
    $.ajax({
        url: url,
        type: "POST",
        dataType: "json",
        beforeSend: function () {
            dvajaxloadshow();
        },
        success: function (result) {
            alert(result.message);

            var url1 = "/Designation/Create";
            window.location.replace(absURL(url1));

        },
        complete: function () {
            dvajaxloadhide()
        },
    });
}

function ActivateEmployee(DesignationID) {


    var url = absURL("/Designation/ActivateDesignation?DesignationId=" + DesignationID);
    $.ajax({
        url: url,
        type: "POST",
        dataType: "json",
        beforeSend: function () {
            dvajaxloadshow();
        },
        success: function (result) {
            alert(result.message);

            var url1 = "/Designation/Create";
            window.location.replace(absURL(url1));

        },
        complete: function () {
            dvajaxloadhide()
        },
    });
}


function Submit()
{
    if (elementValid('Header')) {
        var desigdata = { "id": "", "code": "", "name": "" }

        desigdata.id = $('#Id').val();
        desigdata.code = $('#Code').val();
        desigdata.name = $('#Name').val();

        var url = absURL("/Designation/SaveData");
        $.ajax({
            url: url,
            data: desigdata,

            type: "POST",
            dataType: "json",
            beforeSend: function () {
                dvajaxloadshow();
            },
            success: function (result) {
                alert(result.message);

                var url1 = "/Designation/Create";
                window.location.replace(absURL(url1));

            },
            complete: function () {
                dvajaxloadhide()
            },
        });
    }
}