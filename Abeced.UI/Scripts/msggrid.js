

$(document).ready(function () {

    //"dataSource": {
    //    "transport": {
    //        "prefix": "",
    //        "read": {
    //            "url": ""
    //        }
    //    },
    //    "pageSize": 20,
    //    "page": 1,
    //    "total": 0,
    //    "type": "aspnetmvc-ajax",
    //    "schema": {
    //        "data": "Data",
    //        "total": "Total",
    //        "errors": "Errors",
    //        "model": {
    //            "fields": {
    //                "id": {
    //                    "type": "number"
    //                },
    //                "quantity": {
    //                    "type": "number"
    //                },
    //                "name": {
    //                    "type": "string"
    //                }
    //            }
    //        }
    //    }
    //}

    $("#msggrid").kendoGrid({
        dataSource: {
            type: "json",
            transport: {
                prefix: "Data",
                read: "/Admin/GetMsgOfDayList_Read"
            },
            pageSize: 100,
            //serverPaging   : true,
            //serverFiltering: true,
            //serverSorting  : true,
            schema: {
               "data": "Data",
                model: {
                    id: "Id",
                    fields: {
                        Id: { type: "string" },
                        Message: { type: "string" },
                        Day: { type: "date" },
                    }
                }
            },
        },
        filterable: true,
        sortable: true,
        /*pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },*/
        pageable: {
            refresh: true,
            pageSize: 100,
            pageSizes: [50, 100, 200, 500]
        },
        dataBound: onDataBound,
        //toolbar: ["create"],
        columns: [
        //{ template: "<input type='checkbox' class='checkbox' />" },
        { field: "Id", title: " ", width: 30, hidden: true, filterable: false, sortable: false },
        /*{
            field: "Day",
            title: " Message Day",
            template:'#= kendo.toString(Day, "yyyy-MM-dd") #'

        },*/
        { field: "Day", title: "Day", width: 150 ,type: "date",    format:"{0:dd-MMM-yyyy}" },
        { field: "Message", title: "Message" },
        { command: [{ name: "edit", text: "Edit", click: getMOD }], title: "&nbsp;", width: "10em" },
        { command: [{ name: "delete", text: "Delete", click: deleteMOD }], title: "Delete", width: "50px" }
        ]

    }).data("kendoGrid");

});



function getMOD(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var dd = dataItem.Id;
    $("#windowmsg").append("<div id='getmsgwindow'></div>");

    var wnd2 = $("#getmsgwindow").kendoWindow({
        //actions: ["Close"],
        draggable: true,
        modal: true,
        animation: false,
        resizable: true,
        content: "/Admin/EditMsgOfDay?id=" + dd,
        width: 620,

        title: "Message Details",
        // close: onClose,
        deactivate: function () {
            this.destroy();
        }

    }).data("kendoWindow");
    wnd2.center().open();
}


$("#btnAddMsg").click(function (e) {
    e.preventDefault();

    $("#windowmsg").append("<div id='getmsgwindow'></div>");

    var wnd2 = $("#getmsgwindow").kendoWindow({
        //actions: ["Close"],
        draggable: true,
        modal: true,
        animation: false,
        resizable: true,
        content: "/Admin/AddMsgOfDay",
        width: 620,
        //height: 180,

        title: "Add New Message",
        // close: onClose,
        deactivate: function () {
            this.destroy();
        }

    }).data("kendoWindow");
    wnd2.center().open();
});

function OnSuccessMsg(ajaxContext) {
    $('#targetDivMsg').empty();
    var response = ajaxContext.rtnmsg;
    var smsg = ajaxContext.msg;
    if (response == "success") {
        $('<span class="alert alert-success" style="display: block;font-size: 120%"><b>Success : Message Saved Successfully. </b> </span>').appendTo('.rssedMsg');
        $("#btnSubmitMsg").hide();
        $("#btnAddAnotherCard").show();
        var grid = $("#msggrid").data("kendoGrid");
        grid.dataSource.read();
        grid.refresh();

    }
    else if (response == "fail") {
        $('<span class="alert alert-error" style="display: block;font-size: 120%"><b>Error: Unable to Save. Please try Again</b> </span>').appendTo('.rssedMsg');
    }
    else {
        $('<span class="alert alert-error" style="display: block;font-size: 120%"><b>Unknown Error: Please try Again</b> </span>').appendTo('.rssedMsg');
    }
}
function OnFailureMsg(ajaxContext) {
    $('#targetDivMsg').empty();
    $('#targetDivMsg').empty();
    $('<span class="alert alert-error" style="display: block;font-size: 120%"><b>Error Occurred whiles saving</b> </span>').appendTo('.rssedMsg');
    //$('#targetDivMsg').empty();
}


function onDataBound(e) {
    //remove text from "destroy" button
    //var innerContent = $(".k-grid-Delete").html().replace("Delete", "");
    //$(".k-grid-Delete").html(innerContent);
    $(".k-grid-delete").addClass("abutton delete");
}

//Delete Card
function deleteMOD(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var dd = dataItem.Id;
    var answer = confirm("Are You sure you want to DELETE this Message?");
    if (answer) {
        $.ajax({
            type: "POST",
            data: { id: dd },
            dataType: "json",
            url: '/Admin/DeleteMOD/',
            success: function (data) {

                if (data.delans == true) {
                    var grid = $("#msggrid").data("kendoGrid");
                    grid.dataSource.read();
                    grid.refresh();
                }
                else {
                    alert('Error : ');
                }
            },
            error: function (data) {
                alert('Error : ');
            }

        });
    }
}

function convert(str) {
    var date = new Date(str),
        mnth = ("0" + (date.getMonth() + 1)).slice(-2),
        day = ("0" + date.getDate()).slice(-2);
    return [date.getFullYear(), mnth, day].join("-");
}



