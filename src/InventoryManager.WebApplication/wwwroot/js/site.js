$(document).ready(function () {
    createTable("Property");
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
            $("#tableDiv").append('<table id="displayTable" class="display"><thead><tr>' + tableHeaders + '</tr></thead></table>');

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