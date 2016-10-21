$(document).ready(function () {
    createTable();
});

function createTable() {
    $.ajax({
        url: 'http://localhost:59359/api/Property/',
        type: 'GET',
        crossDomain: true,
        dataType: 'json',
        success: function (json) {
            jsonData = json;                       //json.data
            jsonColumns = Object.keys(json[0]);    //json.columns

            columnsDataConfig = [];
            jsonColumns.forEach(function (item) {
                columnsDataConfig.push({ data: item });
            });

            tableHeaders = '';
            $.each(jsonColumns, function (i, val) {
                tableHeaders += "<th>" + val + "</th>";
            });

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