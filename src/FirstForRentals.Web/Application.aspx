<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Home.Master" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="FirstForRentals.Web.Application" %>
<asp:Content ID="cntHead" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/application.css" rel="stylesheet" />
    <script src="/JS/Pages/callbackHandler.js"></script>
    <script type="text/javascript" src="/JS/Pages/application.js"></script>
    <script type="text/javascript" src="/JS/Lib/date.js"></script>
</asp:Content>
<asp:Content ID="cntMain" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentWrapper">
        <div class="optionsWrapper">
            <div class="optionSelector">

            </div>
            <div class="optionContainer" data-content="dateChoiceContainer">
                <span class="optionHeading selectedOption">PERIOD</span><br />
                <span class="optionDescription">Select the period you wish to rent a vehicle</span>
            </div>
            <div class="optionContainer" data-content="branchChoiceContainer">
                <span class="optionHeading">BRANCH</span><br />
                <span class="optionDescription">Select your collection branch</span>
            </div>
            <div class="optionContainer modelOptionContainer" data-content="modelChoiceContainer">
                <span class="optionHeading">MODEL</span><br />
                <span class="optionDescription">Select your car model</span>
            </div>
            <div class="optionContainer" data-content="extrasContainer">
                <span class="optionHeading">OPTIONS</span><br />
                <span class="optionDescription">Select your optional extras</span>
            </div>
            <div class="optionCostContainer">
                <table class="costingTable">
                    <tr class="depositOption">
                        <td>
                            <span class="optionCostHeading">DEPOSIT >></span>
                        </td>
                        <td>
                            <span class="optionCost optionCostDeposit">R0,00</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="optionCostHeading">RENTAL COST >></span>
                        </td>
                        <td>
                            <span class="optionCost optionCostRental">R0,00</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="optionCostHeading">INSURANCE COST >></span>
                        </td>
                        <td>
                            <span class="optionCost optionCostInsurance">R0,00</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="optionCostHeadingTotal">CURRENT QUOTE >></span>
                        </td>
                        <td>
                             <span class="optionCostTotal optionCostQuote">R0,00</span>
                        </td>
                    </tr>
                </table>
            </div>
            <a class="button acceptButton" href="#">accept</a>
        </div>
        <div class="choiceWrapper">
            <div class="dateChoiceContainer choiceContainer">
                <span class="textBoxTitle">START DATE</span><br />
                <input class="textbox dateField startDate" type="text" /><br /><br />
                <span class="textBoxTitle">END DATE</span><br />
                <input class="textbox dateField endDate" type="text" /><br /><br />
            </div>
            <div class="branchChoiceContainer choiceContainer">
                <span class="textBoxTitle">COLLECTION BRANCH</span><br />
                <select class="dropdown startDestination">
                    <option>Johannesburg</option>
                    <option>Cape Town</option>
                    <option>Durban</option>
                    <option>Port Elizabeth</option>
                    <option>Potchefstroom</option>
                </select><br /><br />
                <span class="textBoxTitle">DROP OFF BRANCH</span><br />
                <select class="dropdown endDestination">
                    <option>Johannesburg</option>
                    <option>Cape Town</option>
                    <option>Durban</option>
                    <option>Port Elizabeth</option>
                    <option>Potchefstroom</option>
                </select>
            </div>
            <div class="modelChoiceContainer choiceContainer">
                <div class="modelSelector">

                </div>
            </div>
            <div class="extrasContainer choiceContainer">
                <input id="extraInsurance" class="extraCheckbox" type="checkbox" />
                <label for="extraInsurance" class="extraTitle">Insurance Package</label><br /><br />

                <input id="extraGPS" class="extraCheckbox" type="checkbox" />
                <label for="extraGPS" class="extraTitle">Garmin GPS Package</label><br /><br />

                <input id="extraToll" class="extraCheckbox" type="checkbox" />
                <label for="extraToll" class="extraTitle">Toll Gate Day Pass</label><br /><br />

                <input id="extraPickUp" class="extraCheckbox" type="checkbox" />
                <label for="extraPickUp" class="extraTitle">Chauffeur Pick Up</label><br /><br />

                <input id="extraPetrol" class="extraCheckbox" type="checkbox" />
                <label for="extraPetrol" class="extraTitle">Petrol Voucher</label><br /><br />

                <input id="extraAssistance" class="extraCheckbox" type="checkbox" />
                <label for="extraAssistance" class="extraTitle">Roadside Assistance Package</label><br /><br />

            </div>
            <div class="overviewContainer choiceContainer">
                <span class="breadcrumb activeBreadCrumb">confirmed rental details</span><br /><br />
                <table class="wideTable">
                    <tr>
                        <td>
                            <span class="textBoxTitle">START DATE</span><br />
                            <input class="textbox confirmStartDate" type="text" />
                        </td>
                        <td>
                            <span class="textBoxTitle">END DATE</span><br />
                            <input class="textbox confirmEndDate" type="text" />
                        </td>
                    </tr>
                </table>
                <table class="wideTable">
                    <tr>
                        <td>
                            <span class="textBoxTitle">PICK UP BRANCH</span><br />
                            <input class="textbox confirmStartDestination" type="text" />
                        </td>
                        <td>
                            <span class="textBoxTitle">DROP OFF BRANCH</span><br />
                            <input class="textbox confirmEndDestination" type="text" />
                        </td>
                    </tr>
                </table>
                <table class="wideTable">
                    <tr>
                        <td>
                            <span class="textBoxTitle">MAKE</span><br />
                            <input class="textbox confirmMake" type="text" />
                        </td>
                        <td>
                            <span class="textBoxTitle">MODEL</span><br />
                            <input class="textbox confirmModel" type="text" />
                        </td>
                    </tr>
                </table>
                <table class="wideTable">
                    <tr>
                        <td>
                            <span class="textBoxTitle">DEPOSIT</span><br />
                            <input class="textbox confirmDeposit" type="text" />
                        </td>
                        <td>
                            <span class="textBoxTitle">DEPOSIT STATUS</span><br />
                            <input class="textbox confirmDepositStatus" type="text" />
                        </td>
                    </tr>
                </table>
                <table class="wideTable">
                    <tr>
                        <td>
                            <span class="textBoxTitle">RENTAL COST</span><br />
                            <input class="textbox confirmRentalCost" type="text" />
                        </td>
                        <td>
                            <span class="textBoxTitle">INSURANCE COST</span><br />
                            <input class="textbox confirmInsuranceCost" type="text" />
                        </td>
                    </tr>
                </table>
                <table class="wideTable">
                    <tr>
                        <td>
                            <span class="textBoxTitle">EXTRAS COST</span><br />
                            <input class="textbox confirmExtrasCost" type="text" />
                        </td>
                        <td>
                            <span class="textBoxTitle">VAT</span><br />
                            <input class="textbox confirmVatCost" type="text" />
                        </td>
                    </tr>
                </table>
                <table class="wideTable">
                    <tr>
                        <td>
                            <span class="textBoxTitle">PAYMENT STATUS</span><br />
                            <input class="textbox confirmPaymentStatus" type="text" />
                        </td>
                        <td>
                            <span class="textBoxTitle">TOTAL</span><br />
                            <input class="textbox confirmTotal" type="text" />
                        </td>
                    </tr>
                </table>
                <a class="button printButton">Print</a>
            </div>
        </div>
    </div>

    <%-- Template Section --%>

    <div class="modelTemplate modelContainer">
        <img class="modelLogo" alt="" />
        <span class="modelTitle"></span>
        <img class="availabilityLogo" alt="" />
    </div>

</asp:Content>
