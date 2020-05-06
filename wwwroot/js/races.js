$(document).ready(function () {

    $("#btnNewComp").click(function () {
        $("#newComp").show();
        const url = `http://${window.location.host}/runners/get`;
        console.log(url);
        var dropdown = $("#selectRunner");
        console.log("THE DROPDOWN");
        console.log(dropdown);
        console.log("SENDING REQUEST");

        $.getJSON(url,
            function (data) {
                console.log("REQUEST SUCCESSFUL");
                console.log(data);
                let option;
                for (let i = 0; i < data.length; i++) {
                    option = document.createElement('option');
                    option.text = data[i].forename + " " + data[i].surname;
                    option.value = data[i].id;
                    dropdown.append(option);
                    console.log(`DROPDOWN OPTION ADDED: ${data[i].forename} ${data[i].surname}`);
                }
            });


    });
});
