$(document).ready(function () {
    $(".nav a").on("click", function () {
        $(".nav").find(".active").removeClass("active");
        $(this).parent().addClass("active");
        createTable("Headered" + $(this).attr('id'));
    });


    $('form').submit(function (event) {
        var formData = {
            'name': $('input[name=name]').val(),
            'description': $('input[name=description]').val(),
            'dataType': $('input[name=datatype]').val()
        };
        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            type: 'POST',
            url: 'http://localhost:59359/api/property/',
            data: JSON.stringify(formData),
            dataType: 'json',
            encode: true,
            success: function (json) {
                event.preventDefault();
                createTable("HeaderedProperty");
            },
            error: function (request, message, error) {
                handleException(request, message, error);
            }
        });
    });
});


function createTable(tableName) {
    $.ajax({
        url: 'http://localhost:59359/api/' + tableName + '/',
        type: 'GET',
        crossDomain: true,
        dataType: 'json',
        success: function (json) {
            jsonData = json.data;
            jsonColumns = json.headers;

            columnsDataConfig = [];
            tableHeaders = '';
            for (columnName in jsonColumns) {
                columnsDataConfig.push({ data: columnName });
                tableHeaders += "<th>" + jsonColumns[columnName] + "</th>";
            }

            $("#tableDiv").empty();
            $("#tableDiv").append('<table id="displayTable" class="table table-striped table-bordered" width="100%" cellspacing="0"><thead><tr>' + tableHeaders + '</tr></thead></table>');

            $('#displayTable').DataTable({
                data: jsonData,
                dataSrc: '',
                "columns": columnsDataConfig
            });

        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function handleException(request, message, error) {
    var msg = "";
    msg += "Code: " + request.status + "\n";
    msg += "Text: " + request.statusText + "\n";
    if (request.responseJSON !== null) {
        msg += "Message" + request.responseJSON.Message + "\n";
    }
    alert(msg);
}