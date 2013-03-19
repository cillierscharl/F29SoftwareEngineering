$(document).ready(function () {
    $('.customerSearchOption').delay(500).fadeIn();
    $('.customersLink').addClass('activeBreadCrumb');

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


});