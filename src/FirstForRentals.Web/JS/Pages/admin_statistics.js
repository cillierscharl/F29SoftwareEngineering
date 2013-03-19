$(document).ready(function () {
    $('.seasonalVariationContainer').delay(500).fadeIn();
    $('.statisticsLink').addClass('activeBreadCrumb');


    $('.optionContainer').click(function () {
        var $optionSelected = $(this);

        $('.selectedOption').removeClass('selectedOption');

        $('.optionSelector').animate({
            top: $optionSelected.position().top
        }, 'fast');

        $optionSelected.find('.optionHeading').addClass('selectedOption');

        $('.choiceContainer').hide();

        $('.' + $optionSelected.data('content')).fadeIn('fast');

    });

    initSeasonalVariationGraph();
    initVehiclePopularityGraph();
    initIncomeTrendGraph();

});


function initSeasonalVariationGraph() {
    var options = {
        chart: {
            renderTo: 'seasonalVariationGraphContainer',
            defaultSeriesType: 'area',
            backgroundColor: 'rgba(255, 255, 255, 0.1)'
        },
        credits:false,
        title: {
            text: 'Seasonal Rental Variation By Class'
        },
        xAxis: {
            categories: []
        },
        yAxis: {
            title: {
                text: 'Rental Count'
            }
        },
        series: []
    };

    $.each(seasonalVariation.Keys, function (i, key) {
        options.xAxis.categories.push(key)
    });

    $.each(seasonalVariation.Values, function (i, values) {

        var series = {
            data: []
        };
        
        $.each(values, function (j, value) {
            if (j == 0) {
                series.name = value;
            } else {
                series.data.push(parseFloat(value));
            }
        });
        options.series.push(series);
    });

    var chart = new Highcharts.Chart(options);
}

function initVehiclePopularityGraph() {
    var options = {
        chart: {
            renderTo: 'vehiclePopularityGraphContainer',
            defaultSeriesType: 'bar',
            backgroundColor: 'rgba(255, 255, 255, 0.1)'
        },
        credits: false,
        title: {
            text: 'Vehicle Popularity'
        },
        xAxis: {
            categories: []
        },
        yAxis: {
            title: {
                text: 'Rental Count'
            }
        },
        series: []
    };

    $.each(popularityGraph.Keys, function (i, key) {
        options.xAxis.categories.push(key)
    });

    $.each(popularityGraph.Values, function (i, values) {

        var series = {
            data: []
        };

        $.each(values, function (j, value) {
            if (j == 0) {
                series.name = value;
            } else {
                series.data.push(parseFloat(value));
            }
        });
        options.series.push(series);
    });

    var chart = new Highcharts.Chart(options);
}

function initIncomeTrendGraph() {
    var options = {
        chart: {
            renderTo: 'incomeTrendGraphContainer',
            defaultSeriesType: 'column',
            backgroundColor: 'rgba(255, 255, 255, 0.1)'
        },
        credits: false,
        title: {
            text: 'Income Trend By Class'
        },
        xAxis: {
            categories: []
        },
        yAxis: {
            title: {
                text: 'Income'
            }
        },
        series: []
    };

    $.each(incomeTrendGraph.Keys, function (i, key) {
        options.xAxis.categories.push(key)
    });

    $.each(incomeTrendGraph.Values, function (i, values) {

        var series = {
            data: []
        };

        $.each(values, function (j, value) {
            if (j == 0) {
                series.name = value;
            } else {
                series.data.push(parseFloat(value));
            }
        });
        options.series.push(series);
    });

    var chart = new Highcharts.Chart(options);
}