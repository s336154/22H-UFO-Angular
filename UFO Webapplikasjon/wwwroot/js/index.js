$(function(){
    totalSightings();
    readLatestReport();
});

function totalSightings() {
    $.get("sighting/readAll", function (reports) {
        // Henter all data og sender til telleren
        countTotal(reports)
    });
}

// Henter siste data
function readLatestReport() {
    $.get("sighting/readLatest", function (reports) {
        formaterSightings(reports);
    });
}
function formaterSightings(reports) {
    let ut = "<div class='container'>";

        ut += "<div class='row'>" +
            "<div class='col-3 dateF visible'>" +
            "<div>Published Date: " + reports.dateposted + "</div>" +
            "<div>Date/Time: " + reports.datetime + "</div>" +
            "<div>Duration: " + reports.duration + "</div>" +
            "</div>" +


            "<div class='col-3 dateF notVisible'>" +
            "<div class='row'>" +
            "<div class='col-7 dategroup'>" +
            "<div>Published Date: " + reports.dateposted + "</div>" +
            "<div>Date/Time: " + reports.datetime + "</div>" +
            "<div>Duration: " + reports.duration + "</div>" +
            "</div><div class='col-5 btngroup'>" +
            "<a class='btnCrud' id='update1' href='update.html?id=" + reports.id + "'>Update</a>" +
            "<div></div>" +
            "<button class='btnCrud' onclick='deleteSighting(" + reports.id + ")'>Delete</button>" +
            "</div></div></div>" +

            "<div class='col-9 commentF'><div class='row'>" +
            "<div class='col-7 titleP'><h3>" +
            "<span class='fl'> " + reports.city + "</span >, <span class='fl'>" + reports.country + "</span>" +
            "</h3></div>" +
            "<div class='col-5 visible'><div class='row'>" +
            "<a class='col-5 btnCrud' id='update1' href='update.html?id=" + reports.id + "'>Update</a>" +
            "<div class='col-1'></div>" +
            "<button class='col-5 btnCrud' onclick='deleteSighting(" + reports.id + ")'>Delete</button>" +
            "</div></div></div>" +
            "<div class='textF'><b>The observation:</b><br />" + reports.comments + "</div>" +
            "</div></div>";
    ut += "</div>";
    $("#latestReport").html(ut);
}

function countTotal(reports) {
    // Tellervariabel
    let count = 0;

    // Looper gjennom alle kolonnene i tabellen
    for (let report of reports) {
        count++;
    }

    // Summen printes ut
    let ut = count;
    $("#count").html(ut);
    $("#count2").html(ut);
}

function deleteSighting(id) {
    const url = "Sighting/delete?id="+id;
    $.get(url, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}