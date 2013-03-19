var SessionData = {
    "currentVehicle": null,
    "currentClass": ".commercialChoiceContainer",
    "currentContainer": ".vehicleIdentificationContainer"
}

$(document).ready(function () {
    $('.vehicleIdentificationContainer').show();
    $('.commercialChoiceContainer').delay(500).fadeIn();
    $('.vehiclesLink').addClass('activeBreadCrumb');

    $.each(carOverview.CarCategoryCollection, function (i, category) {

        var container = $('.' + category.CategoryName + 'ChoiceContainer');
        var ddl = container.find('select');

        $.each(category.categoryCarCollection, function (j, carDetail) {
            if (j == 0) {
                bindVehicleDetails(carDetail, container);
            }
            var option = $('<option/>').html(carDetail.Registration);
            ddl.append(option);
        });
    });

    $('.optionContainer').click(function () {
        var $optionSelected = $(this);

        $('.selectedOption').removeClass('selectedOption');

        $('.optionSelector').animate({
            top: $optionSelected.position().top
        }, 'fast');

        $optionSelected.find('.optionHeading').addClass('selectedOption');

        $('.choiceContainer').hide();

        $('.' + $optionSelected.data('content')).fadeIn('fast');

        SessionData.currentClass = '.' + $optionSelected.data('content');

        SetCurrentVehicleObject(getCurrentVehicleId());

        bindVehicleDetails(SessionData.currentVehicle, $(SessionData.currentClass));

    });

    $('select').change(function () {
        var detail = findVehicleDetail($(this).val(),$(this).parent());
    });

    $('.faultsLink,.faultAddCancel').click(function () {
        loadVehicleFaults();
    });


    $('.faultAddLink').click(function () {

        $(SessionData.currentClass + ' ' + '.faultVehicleDetail').val(SessionData.currentVehicle.Registration);
        $(SessionData.currentContainer).fadeOut(0.1, function () {
            $(SessionData.currentClass + ' ' + '.recordFaultAddContainer').fadeIn('slow');
        });
        SessionData.currentContainer = '.recordFaultAddContainer';
    });

    $('.vehiclesDetailsLink').click(function () {
        //
        var $container = $(this).parent();
        $container.find('.activeSubBreadCrumb').removeClass('activeSubBreadCrumb');
        $(this).addClass('activeSubBreadCrumb');
        $(SessionData.currentContainer).fadeOut(0.1, function () {
            $(SessionData.currentClass + ' ' + '.vehicleIdentificationContainer').fadeIn('slow');
        });
        //
        SessionData.currentContainer = '.vehicleIdentificationContainer';
        //
        showLoader();
        var parameters = [];
        parameters.push(SessionData.currentVehicle.Id);

        var callbackObject = buildCallback('GetVehicleStatus', 'GET', parameters);
        SendCallback(JSON.stringify(callbackObject))
        //
    });

    $('.thresholdsLink').click(function () {

        var $container = $(this).parent();
        $container.find('.activeSubBreadCrumb').removeClass('activeSubBreadCrumb');
        $(this).addClass('activeSubBreadCrumb');
        $(SessionData.currentContainer).fadeOut(0.1, function () {
            $(SessionData.currentClass + ' ' + '.vehicleThresholdContainer').fadeIn('slow');
        });
        //
        SessionData.currentContainer = '.vehicleThresholdContainer';
        //
        showLoader();

        var callbackObject = buildCallback('GetVehicleAlerts', 'GET', {});
        SendCallback(JSON.stringify(callbackObject))
    });
    

    $('.submitFault').click(function () {
        

        var parameters = [];
        parameters.push(SessionData.currentVehicle.Id);
        var faultVehicleDate = $(SessionData.currentClass + ' ' + '.faultVehicleDate').val();
        if (faultVehicleDate.length == 0) {
            confirmDialog('Please enter a fault date.');
            return;
        }
        parameters.push(faultVehicleDate);

        var faultVehicleDescription = $(SessionData.currentClass + ' ' + '.faultVehicleDescription').val();
        if (faultVehicleDescription.length == 0) {
            confirmDialog('Please enter a fault description.');
            return;
        }
        parameters.push(faultVehicleDescription);

        var faultVehicleCost = $(SessionData.currentClass + ' ' + '.faultVehicleCost').val();
        if (faultVehicleCost.length == 0) {
            confirmDialog('Please enter a fault cost.');
            return;
        }
        if (isNaN(faultVehicleCost)) {
            confirmDialog('Please enter a valid fault cost.');
            return;
        }
        parameters.push(faultVehicleCost);

        parameters.push($(SessionData.currentClass + ' ' + '.faultVehicleSuspension').is(':checked'));
        parameters.push($(SessionData.currentClass + ' ' + '.faultVehicleClaim').is(':checked'));

        showLoader();

        var callbackObject = buildCallback('AddFault', 'POST', parameters);
        SendCallback(JSON.stringify(callbackObject));

        // Clean Up
        $(SessionData.currentClass + ' ' + '.faultVehicleDate').val('');
        $(SessionData.currentClass + ' ' + '.faultVehicleDescription').val('');
        $(SessionData.currentClass + ' ' + '.faultVehicleCost').val('');
        $(SessionData.currentClass + ' ' + '.faultVehicleSuspension').attr('checked',false);
        $(SessionData.currentClass + ' ' + '.faultVehicleClaim').attr('checked', false);

    });
});

function loadVehicleFaults() {
    $('.faultTableContainer').html('<span class="breadcrumb">loading....</span>');
    showLoader();
    //
    var $container = $(SessionData.currentClass + ' ' + '.choiceContainerHeading');
    $container.find('.activeSubBreadCrumb').removeClass('activeSubBreadCrumb');
    $container.find('.faultsLink').addClass('activeSubBreadCrumb');
    //
    $(SessionData.currentContainer).fadeOut(0.1, function () {
        $(SessionData.currentClass + ' ' + '.recordFaultContainer').fadeIn('slow');
    });
    SessionData.currentContainer = '.recordFaultContainer';
    //
    var vehicleId = getCurrentVehicleId();
    SetCurrentVehicleObject(vehicleId);

    var parameters = [];
    parameters.push(SessionData.currentVehicle.Id);

    var callbackObject = buildCallback('GetFaults', 'GET', parameters);
    SendCallback(JSON.stringify(callbackObject));
    //
}

function bindVehicleDetails(carDetails, container) {
    container.find('.mileageDetail').val(carDetails.Mileage);
    container.find('.yearDetail').val(carDetails.Year);
    container.find('.startDetail').val(carDetails.Service_Start_Date);
    container.find('.endDetail').val(carDetails.Service_End_Date);
    container.find('.serviceDetail').val(carDetails.Service_Status);
    container.find('.rentalDetail').val(carDetails.Rental_Status);
    container.find('.makeDetail').val(carDetails.Make);
    container.find('.modelDetail').val(carDetails.Model);

    container.find('.rentalDetail').removeClass('redText greenText');
    container.find('.serviceDetail').removeClass('redText greenText');

    if (carDetails.Service_Status == 'inactive') {
        container.find('.serviceDetail').addClass('redText');
    } else {
        container.find('.serviceDetail').addClass('greenText');
    }

    if (carDetails.Rental_Status == 'inactive') {
        container.find('.rentalDetail').addClass('redText');
    } else {
        container.find('.rentalDetail').addClass('greenText');
    }

}

function findVehicleDetail(id,parent) {
    $.each(carOverview.CarCategoryCollection, function (i, category) {
        $.each(category.categoryCarCollection, function (j, carDetail) {
            if (carDetail.Registration == id) {
                bindVehicleDetails(carDetail, parent);
                SessionData.currentVehicle = carDetail;
            }
        });
    });
}

function SetCurrentVehicleObject(id) {
    $.each(carOverview.CarCategoryCollection, function (i, category) {
        $.each(category.categoryCarCollection, function (j, carDetail) {
            if (carDetail.Registration == id) {
                SessionData.currentVehicle = carDetail;
            }
        });
    });
}

function getCurrentVehicleId() {
    return $(SessionData.currentClass + ' ' + '.vehicleIdentificationContainer').find('select').val();
}


// Window Functions (Called from callbacks)

function ReturnVehicleFaults(instructionSet) {
    $(SessionData.currentClass + ' ' + '.faultTableContainer').html(instructionSet.Parameters[0]);
    hideLoader();
}

function ReturnVehicleAlerts(instructionSet) {
    $(SessionData.currentClass + ' ' + '.thresholdTableContainer').html(instructionSet.Parameters[0]);
    hideLoader();
}

function CallCompleted() {
    hideLoader();
}

function VehicleFaultAdded() {
    loadVehicleFaults();
}

function VehicleStatus(instructionSet) {
    hideLoader();
    var carDetail = JSON.parse(instructionSet.Parameters[0]);
    bindVehicleDetails(carDetail, $(SessionData.currentContainer));
}