function showLoader() {
    $('.loading').show();
}

function hideLoader() {
    $('.loading').hide();
}

$(document).ready(function () {

    var userCredentials = JSON.parse($.cookie('FirstForRentalsUserCredentials'));

    $('.userText').html(userCredentials.FirstName + ' ' + userCredentials.LastName.substring(0, 1) + '.');
    $('.userAvatar').attr('src', userCredentials.GravatarUrl);
    if (userCredentials.UserType == '0') {
        $('.adminLink').hide();
    }

    $('.logoutLink').click(function () {
        $.removeCookie('FirstForRentalsUserCredentials');
        window.location = '/authenticate.aspx';
    });

    $(".dateField").datepicker({
        dateFormat: "yy-mm-dd",
        minDate: new Date('today').toString('yyyy-MM-dd')
    });

    $(".dateFieldFull").datepicker({
        dateFormat: "yy-mm-dd"
    });

    $(".dateField,.dateFieldFull").keydown(function () {
        return false;
    });

    $(".noEdit").keydown(function () {
        return false;

    });
});

function buildDialog(dialogText, options) {
    // Initial Clean Up
    var $dialogOptionsContainer = $('.dialogOptionsContainer');
    $dialogOptionsContainer.html('');

    var $dialogContent = $('.dialogText');
    $dialogContent.html(dialogText);
    //

    $.each(options, function (i, option) {
        $option = $('<a/>');
        $option.html(option.eventText);
        $option.addClass('button dialogOption');
        $option.click(function () {
            option.event();
            $('.dialog').fadeOut('fast');
        });
        $dialogOptionsContainer.append($option);
    });

    $('.dialog').fadeIn('fast');

}

function confirmDialog(text) {
    var okOption = {
        eventText: "ok",
        event: function () {

        }
    }
    var parameters = [];
    parameters.push(okOption);

    buildDialog(text, parameters);
}