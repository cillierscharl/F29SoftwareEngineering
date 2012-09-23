<<<<<<< HEAD
﻿$(document).ready(function () {

    $('.dateChoiceContainer').show();

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

    $('.modelContainer').click(function () {
        $('.selectedModel').removeClass('selectedModel');

        $('.modelSelector').animate({
            top: $(this).position().top
        }, 'fast');

        $(this).find('.modelTitle').addClass('selectedModel');

        $('.optionCost').html('R4900,00');
    });

=======
﻿$(document).ready(function () {

    $('.dateChoiceContainer').show();

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

    $('.modelContainer').click(function () {
        $('.selectedModel').removeClass('selectedModel');

        $('.modelSelector').animate({
            top: $(this).position().top
        }, 'fast');

        $(this).find('.modelTitle').addClass('selectedModel');

        $('.optionCost').html('R4900,00');
    });

>>>>>>> origin/master
});