$(document).ready(function () {
    createTable("element");

    $("#saveButton").on("click", function (e) {
        e.preventDefault();
        addRecord();
    });


    $('form').submit(function (event) {
        // get the form data
        // there are many ways to get this data using jQuery (you can use the class or id also)
        var formData = {
            'name': $('input[name=name]').val(),
            'description': $('input[name=description]').val(),
            'datatype': $('input[name=datatype]').val()
        };
        // process the form
        $.ajax({
            type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
            url: 'http://localhost:59359/api/property/', // the url where we want to POST
            data: formData, // our data object
            dataType: 'json', // what type of data do we expect back from the server
            encode: true
        })
            // using the done promise callback
            .done(function (data) {
                // log data to the console so we can see
                console.log(data);
                // here we will handle errors and validation messages
            });
        // stop the form from submitting the normal way and refreshing the page
        event.preventDefault();
    });
});


function createTable(tableName) {
    $.ajax({
        url: 'http://localhost:59359/api/Headered' + tableName +'/',
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
            $("#tableDiv").append('<table id="displayTable" class="display" width= "100%"><thead><tr>' + tableHeaders + '</tr></thead></table>');

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
    if (request.responseJSON != null) {
        msg += "Message" + request.responseJSON.Message + "\n";
    }
    alert(msg);
}