$(document).ready(function () {
    createTable();
});

function createTable() {
    $.ajax({
        url: 'http://localhost:59359/api/Property/',
        type: 'GET',
        crossDomain: true,
        dataType: 'json',
        success: function (properties) {
            if ($("table").length == 0) {
                $("body").append("<table></table>");
            }
            $.each(properties, function (index, property) {
                $("table").append(buildRow(property));
            });
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function buildRow(property) {
    var ret =
      "<tr>" +
       "<td>" + property.name + "</td>" +
       "<td>" + property.dataType + "</td>" +
       "<td>" + property.description + "</td>" +
      "</tr>";
    return ret;
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
