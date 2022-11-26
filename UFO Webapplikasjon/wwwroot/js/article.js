$(function () {
    // Gjemmer bort feilmelding
    $("#feil").hide();

    readAllSightings();
});

function readAllSightings() {
    $.get("sighting/readAll", function (reports) {
        formaterSightings(reports);
    });
    // Gjemmer bort knappen og viser funksjonen som reverserer rekkefølgen
    $("#idAsc").hide();
    $("#idDesc").show();
}

// Akkurat lik readAllSightings men med litt andre justeringer
function sortByIdDesc() {
    $.get("sighting/readIdDesc", function (reports) {
        formaterSightings(reports);
    });
    $("#idAsc").show();
    $("#idDesc").hide();
}
function sortByCountryASC() {
    $.get("sighting/readCountryAsc", function (reports) {
        formaterSightings(reports);
    });
    $("#countryAsc").hide();
    $("#countryDesc").show();
}
function sortByCountryDESC() {
    $.get("sighting/readCountryDesc", function (reports) {
        formaterSightings(reports);
    });
    $("#countryAsc").show();
    $("#countryDesc").hide();
}
function sortByCityASC() {
    $.get("sighting/readCityAsc", function (reports) {
        formaterSightings(reports);
    });
    $("#cityAsc").hide();
    $("#cityDesc").show();
}
function sortByCityDESC() {
    $.get("sighting/readCityDesc", function (reports) {
        formaterSightings(reports);
    });
    $("#cityAsc").show();
    $("#cityDesc").hide();
}

function formaterSightings(reports) {
    let ut = "<div class='container'>";

    for (let report of reports) {
        ut += "<div class='row observation'>" +
            "<div class='col-3 dateF visible'>" +
            "<div>Published Date: " + report.dateposted + "</div>" +
            "<div>Date/Time: " + report.datetime + "</div>" +
            "<div>Duration: " + report.duration + "</div>" +
            "</div>" +


            "<div class='col-3 dateF notVisible'>" +
            "<div class='row'>" +
            "<div class='col-7 dategroup'>" +
            "<div>Published Date: " + report.dateposted + "</div>" +
            "<div>Date/Time: " + report.datetime + "</div>" +
            "<div>Duration: " + report.duration + "</div>" +
            "</div><div class='col-5 btngroup'>" +
            "<a class='btnCrud' id='update1' href='update.html?id=" + report.id + "'>Update</a>" +
            "<div></div>" +
            "<button class='btnCrud' onclick='deleteSighting(" + report.id + ")'>Delete</button>" +
            "</div></div></div>" +

            "<div class='col-9 commentF'><div class='row'>" +
            "<div class='col-7 titleP'><h3>" +
                "<span class='fl'> " + report.city + "</span >, <span class='fl'>" + report.country + "</span>" +
            "</h3></div>" +
            "<div class='col-5 visible'><div class='row'>" +
            "<a class='col-5 btnCrud' id='update1' href='update.html?id=" + report.id + "'>Update</a>" +
            "<div class='col-1'></div>" +
            "<button class='col-5 btnCrud' onclick='deleteSighting(" + report.id + ")'>Delete</button>" +
            "</div></div></div>" +
                "<div class='textF'><b>The observation:</b><br />" + report.comments + "</div>" +
            "</div></div>";
    }
    ut += "</div>";
    $("#reports").html(ut);
}


function deleteSighting(id) {
    const url = "Sighting/delete?id="+id;
    $.get(url, function (OK) {
        if (OK) {
            window.location.href = 'article.html';
        }
        else {
            // Viser feilmelding
            $("#feil").show();
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}