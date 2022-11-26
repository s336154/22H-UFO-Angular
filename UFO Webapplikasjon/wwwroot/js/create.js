$(function () {
    // Gjemmer vekk feilmelding
    $("#feil").hide();
});

function createSighting() {
    // Henter nåværende dato for når lagringsknappen trykkes
    let date = new Date();

    // Formaterer datoen til mm/dd/yyyy (https://stackoverflow.com/questions/11591854/format-date-to-mm-dd-yyyy-in-javascript)
    let formatDate = ((date.getMonth() > 8) ? (date.getMonth() + 1) : ('0' + (date.getMonth() + 1))) + '/' + ((date.getDate() > 9) ? date.getDate() : ('0' + date.getDate())) + '/' + date.getFullYear();

    // Henter og kombinerer Streng og Select-verdi
    let durationNumber = $("#durationNumber").val();
    let durationUnit = $("#durationUnit").val();
    let duration = durationNumber + durationUnit;

    const report = {
        city: $("#city").val(),
        country : $("#country").val(),
        duration : duration,
        dateposted : formatDate,
        datetime : $("#datetime").val(),
        comments : $("#comments").val(),
    }
    const url = "Sighting/create";
    $.post(url, report, function (OK) {
        if (OK) {
            window.location.href = 'article.html';
        }
        else {
            // Viser feilmelding
            $("#feil").show();
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
};