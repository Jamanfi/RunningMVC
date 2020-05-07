$(document).ready(function () {
    var seconds = 0;
    $('.duration-picker').durationPicker({
        showSeconds: true,
        showDays: false,

        // callback function that triggers every time duration is changed 
        //   value - duration in seconds
        //   isInitializing - bool value
        onChanged: function (value, isInitializing) {
            // isInitializing will be `true` when the plugin is initialized for the
            // first time or when it's re-initialized by calling `setValue` method
            console.log(value, isInitializing);
            seconds = value;
        }
    });

    $("#selectRunner").change(function () {

    });

    $("#btnSubmit").click(function() {
        var selectBox = $("#selectRunner")[0];
        var runnerId = selectBox.options[selectBox.selectedIndex].value;
        const url = `http://${window.location.host}/api/races?raceId=${raceId}&runnerId=${runnerId}&seconds=${seconds}`;
        console.log("SENDING POST REQUEST");
        $.post(url,
            function (result) {
                console.log("RESPONSE RECEIVED");
                console.log(result);
            });

    });


    $("#btnNewComp").click(function () {
        $("#newComp").show();
        const url = `http://${window.location.host}/api/runners`;
        var dropdown = $("#selectRunner");
        $.getJSON(url,
            function (data) {
                let option;
                for (let i = 0; i < data.length; i++) {
                    option = document.createElement('option');
                    option.text = data[i].forename + " " + data[i].surname;
                    option.value = data[i].runnerId;
                    dropdown.append(option);
                }
            });


    });
});
