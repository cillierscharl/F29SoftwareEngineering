var SessionData = {
    currentModel: null,
    availableClass:false
}

var RentalObject = {
    RentalId:null,
    StartDate:null,
    EndDate:null,
    StartDestination:null,
    EndDestination:null,
    RentalDate:null,
    RentalAmount:null,
    InsuranceAmount :null,
    ExtrasAmount:null,
    VatAmount:null,
    TotalAmount:null,
    DepositAmount:null,
    DepositStatus:null,
    PaymentStatus: null,

    buildPaymentDetails: function (id, rentalAmount, insuranceAmount, extrasAmount, vatAmount, totalAmount, depositAmount) {
        this.RentalId = id;
        this.StartDate = $('.startDate').val();
        this.EndDate = $('.endDate').val();
        this.StartDestination = $('.startDestination').val();
        this.EndDestination = $('.endDestination').val();
        this.RentalDate = new Date.parse('today').toString('yyyy-MM-dd');
        this.RentalAmount = rentalAmount;
        this.InsuranceAmount = insuranceAmount;
        this.ExtrasAmount = extrasAmount;
        this.VatAmount = vatAmount;
        this.TotalAmount = totalAmount;
        this.DepositAmount = depositAmount;
    },

    processDepositPayment: function () {
        this.DepositStatus = "Paid";
        this.PaymentStatus = "Outstanding";
    },

    processFullPayment: function () {
        this.DepositStatus = "N/A";
        this.PaymentStatus = "Paid";
    },

    paymentCommit: function () {
        showLoader();
        var callbackObject = buildCallback("AddRental", "POST", [JSON.stringify(this)]);
        SendCallback(JSON.stringify(callbackObject));
    }
}

$(document).ready(function () {
    $('.executiveLink').addClass('activeBreadCrumb');
    $('.dateChoiceContainer').show();

    var date = Date.parse('today');
    var endDate = Date.parse('tomorrow');

    $('.startDate').val(date.toString('yyyy-MM-dd'));
    $('.endDate').val(endDate.toString('yyyy-MM-dd'));

    var modelOptionContainer = $('.modelChoiceContainer');
    $.each(carCollectionByClass.carCollection, function (i, carOption) {
        var carOptionElement = $('.modelTemplate').clone().removeClass('modelTemplate');
        carOptionElement.find('.modelLogo').attr('src','/Images/Logo/' + carOption.Make + '_logo.png');
        carOptionElement.find('.modelTitle').html(carOption.Make + ' ' + carOption.Model);
        carOptionElement.attr('data-modelDetail', i);
        carOptionElement.find('.availabilityLogo').attr('src', '/Images/Logo/' + carOption.Available + '.png');
        if (i == 0) {
            carOptionElement.find('.modelTitle').addClass('selectedModel');
            SessionData.currentModel = carOption;
        }
        modelOptionContainer.append(carOptionElement);
        
        if (carOption.Available == "AVAILABLE") {
            SessionData.availableClass = true;
        }

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
        calculateCost();
    });

    $('.modelContainer').click(function () {
        var carDetail = carCollectionByClass.carCollection[$(this).attr('data-modelDetail')];
        if (carDetail.Available == 'UNAVAILABLE') {
            confirmDialog('This model is not available for the period selected.');
            return;
        }
        //
        $('.selectedModel').removeClass('selectedModel');
        $('.modelSelector').animate({
            top: $(this).position().top
        }, 'fast');
        $(this).find('.modelTitle').addClass('selectedModel');
        //
        var carDetail = carCollectionByClass.carCollection[$(this).attr('data-modelDetail')];
        SessionData.currentModel = carDetail;
        calculateCost();
    });

    $('input[type="checkbox"]').change(function () {
        calculateCost();
    });

    $('.acceptButton').click(acceptPayment);

    // Date Checking
    $('.startDate').change(function () {
        var startDateObject = Date.parse($('.startDate').val());
        $('.endDate').val(startDateObject.addDays(1).toString('yyyy-MM-dd'));
        calculateCost();
    });

    $('.endDate').change(function () {
        checkDateValidity();
        calculateCost();
    });
    //

    $('.printButton').click(function () {
        window.print();
    });

    calculateCost();

});


function checkDateValidity() {
    var startDateObject = Date.parse($('.startDate').val());
    var endDateObject = Date.parse($('.endDate').val());

    var difference = new TimeSpan(endDateObject - startDateObject);
    var differenceDays = difference.getDays();

    if (differenceDays < 0) {
        $('.endDate').val(startDateObject.addDays(1).toString('yyyy-MM-dd'));
        var parameters = [];
        parameters.push(invalidDateOptions);

        buildDialog('Invalid end date chosen.', parameters);
    }
}

function calculateCost() {
    var carDetail = SessionData.currentModel;
    var depositThreshold = 2;

    var startDateObject = Date.parse($('.startDate').val());
    var endDateObject = Date.parse($('.endDate').val());

    var hireDuration = new TimeSpan(endDateObject - startDateObject);
    var hireDays = hireDuration.getDays() + 1;
    
    var advanceDuration = new TimeSpan(startDateObject - new Date());
    var advanceDays = advanceDuration.getDays();


    
    var rentalCost = parseFloat(parseFloat(hireDays) * parseFloat(carDetail.CostPerDay)).toFixed(2);
    var insuranceCost = parseFloat(parseInt(hireDays) * parseFloat(carDetail.InsurancePerDay)).toFixed(2);
    var extrasCost = parseFloat($('input[type="checkbox"]:checked').length * 200).toFixed(2);
    rentalCost = parseFloat(parseFloat(rentalCost) + parseFloat(extrasCost)).toFixed(2);
    var rentalDeposit;
    if (advanceDays > depositThreshold) {
        rentalDeposit = parseFloat((parseFloat(rentalCost) * 20) / 100).toFixed(2);
    } else {
        rentalDeposit = parseFloat(0.00).toFixed(2);
    }
     
    var rentalVatCost = parseFloat(((parseFloat(rentalCost) + parseFloat(insuranceCost)) * 14) / 100).toFixed(2);
    var rentalQuote = parseFloat(parseFloat(rentalCost) + parseFloat(insuranceCost) + parseFloat(rentalVatCost)).toFixed(2);

    $('.optionCostInsurance').html('R ' + insuranceCost);
    $('.optionCostRental').html('R ' + rentalCost);
    $('.optionCostDeposit').html('R ' + rentalDeposit);
    $('.optionCostQuote').html('R ' + rentalQuote);

    RentalObject.buildPaymentDetails(carDetail.Id,rentalCost, insuranceCost, extrasCost, rentalVatCost, rentalQuote, rentalDeposit);
}

function acceptPayment() {
    var parameters = [];
    if (RentalObject.DepositAmount > 0) {
        parameters.push(paymentDialogDepositOnly);
        parameters.push(paymentDialogFullAmount);
        buildDialog('Process complete payment or deposit only?', parameters);
    } else {
        parameters.push(paymentDialogFullAmount);
        buildDialog('Process complete payment?', parameters);
    }
}

function bindConfirmedDetails() {
    var carDetails = SessionData.currentModel;

    $('.confirmStartDate').val(RentalObject.StartDate);
    $('.confirmEndDate').val(RentalObject.EndDate);
    $('.confirmStartDestination').val(RentalObject.StartDestination);
    $('.confirmEndDestination').val(RentalObject.EndDestination);
    $('.confirmMake').val(carDetails.Make);
    $('.confirmModel').val(carDetails.Model);
    $('.confirmDeposit').val('R ' + RentalObject.DepositAmount);
    $('.confirmDepositStatus').val(RentalObject.DepositStatus);
    $('.confirmRentalCost').val('R ' + RentalObject.RentalAmount);
    $('.confirmInsuranceCost').val('R ' + RentalObject.InsuranceAmount);
    $('.confirmExtrasCost').val('R ' + RentalObject.ExtrasAmount);
    $('.confirmVatCost').val('R ' + RentalObject.VatAmount);
    $('.confirmPaymentStatus').val(RentalObject.PaymentStatus);
    $('.confirmTotal').val('R ' + RentalObject.TotalAmount);
}

// Dialog Options


var paymentDialogDepositOnly = {
    eventText: "Pay Deposit",
    event: function () {
        RentalObject.processDepositPayment();
        RentalObject.paymentCommit();
    }
}

var paymentDialogFullAmount = {
    eventText: "Pay Full Amount",
    event: function () {
        RentalObject.processFullPayment();
        RentalObject.paymentCommit();
    }
}

var invalidDateOptions = {
    eventText: "ok",
    event: function () {

    }
}




// Window Functions (Called from callbacks)

function VehicleRentalAdded() {
    hideLoader();
    $('.choiceContainer').hide();
    $('.optionsWrapper').fadeOut('fast');
    bindConfirmedDetails();
    $('.overviewContainer').fadeIn('fast', function () {
        $('.choiceWrapper').animate({ width: '100%' })
    });
}

function CallCompleted() {
    hideLoader();
}
