$(document).ready(function () {
    $("#propertyMenuItem").click(function () {
        createTable("HeaderedProperty");
        $('#Menu').children().removeClass('active');
        $('#propertyMenuItem').closest("li").addClass('active');
    })
    $("#propertyListMenuItem").click(function () {
        createTable("HeaderedPropertyList");
        $('#Menu').children().removeClass('active');
        $('#propertyListMenuItem').closest("li").addClass('active');
    })
    $("#elementMenuItem").click(function () {
        createTable("HeaderedElement");
        $('#Menu').children().removeClass('active');
        $('#elementMenuItem').closest("li").addClass('active');
    })

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
            encode: true
        });
        event.preventDefault();
        createTable("HeaderedProperty");
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