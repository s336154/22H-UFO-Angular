$(function () {
    readAllSightings();
});

function readAllSightings() {
    $.get("sighting/readAll", function (reports) {
        formaterSightings(reports);
    });
}

function formaterSightings(reports) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>City</th><th>Country</th><th>Duration</th><th>Date Posted</th><th>Date/Time</th><th>Comments</th>" +
        "<th></th><th></th>" +
        "</tr>";
    for (let report of reports) {
        ut += "<tr>" +
            "<td>" + report.city + "</td>" +
            "<td>" + report.country + "</td>" +
            "<td>" + report.duration + "</td>" +
            "<td>" + report.dateposted + "</td>" +
            "<td>" + report.datetime + "</td>" +
            "<td>" + report.comments + "</td>" +
            "<td> <a class='btn btn-primary' href='update.html?id=" + report.id + "'>Update</a></td>" +
            "<td> <button class='btn btn-danger' onclick='deleteSighting(" + report.id + ")'>Delete</button></td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#reports").html(ut);
}

function deleteSighting(id) {
    const url = "Sighting/Delete?id=" + id;
    $.get(url, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}