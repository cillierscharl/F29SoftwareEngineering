<<<<<<< HEAD
﻿$(document).ready(function () {
    $('.entityContainer').hover(function () {
        $(this).fadeTo('fast', '0.5');
    }, function () {
        $(this).fadeTo('fast', '1');
    });

    $('.entityContainer').click(function () {
        $('#hdnAuthType').val($(this).attr('data-authProvider'));
        $('#form1').submit();
    });

=======
﻿$(document).ready(function () {
    $('.entityContainer').hover(function () {
        $(this).fadeTo('fast', '0.5');
    }, function () {
        $(this).fadeTo('fast', '1');
    });

    $('.entityContainer').click(function () {
        $('#hdnAuthType').val($(this).attr('data-authProvider'));
        $('#form1').submit();
    });

>>>>>>> origin/master
});