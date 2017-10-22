jQuery.noConflict();

(function ($) {
    // You pass-in jQuery and then alias it with the $-sign
    // So your internal code doesn't change

    $('.selectpicker').change(function () {
        
        $.ajax({
            type: "GET",
            url: "/Countries/Index",
            data: {
                ContinentFilter: $("#ContinentFilter").val(),
                CommonReligionFilter: $("#CommonReligionFilter").val(),
                JewsAttitudeFilter: $("#JewsAttitudeFilter").val()
            }
        }).success(function (html) {
            $("#filteredCountries").replaceWith(html);
        }).error(function (error) {
            alert("Error");
        });        
    });
})(jQuery);

    
