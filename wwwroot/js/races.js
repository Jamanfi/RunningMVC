$(document).ready(function () {

    var newCompetitor = {
        runnerId: 0,
        finishTime: ""
    };

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
            newCompetitor.finishTime = value;
            console.log(`NEW COMPETITOR FINISH TIME:${formatTimeFromSeconds(value)}`);
        }
    });

    function formatTimeFromSeconds(value) {
        var hours = Math.floor(value / 3600);
        value = value - hours * 3600;
        var minutes = Math.floor(value / 60);
        

        var seconds = value - minutes * 60;

        if (hours < 10) {hours = `0${hours}`;}
        if (minutes < 10) {minutes = `0${minutes}`;}
        if (seconds < 10) {seconds = `0${seconds}`;}

        return `${hours}:${minutes}:${seconds}`;
    }


    $("#btnNewComp").click(function () {
        $("#newComp").show();
        const url = `http://${window.location.host}/runners/get`;
        var dropdown = $("#selectRunner");
        $.getJSON(url,
            function (data) {
                let option;
                for (let i = 0; i < data.length; i++) {
                    option = document.createElement('option');
                    option.text = data[i].forename + " " + data[i].surname;
                    option.value = data[i].id;
                    dropdown.append(option);
                }
            });


    });
});
