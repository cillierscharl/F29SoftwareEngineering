<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="FirstForRentals.Web.Application" %>
<asp:Content ID="cntHead" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/application.css" rel="stylesheet" />
    <script type="text/javascript" src="JS/Pages/application.js"></script>
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
            <div class="optionContainer" data-content="modelChoiceContainer">
                <span class="optionHeading">MODEL</span><br />
                <span class="optionDescription">Select your car model</span>
            </div>
            <div class="optionContainer" data-content="extrasContainer">
                <span class="optionHeading">OPTIONS</span><br />
                <span class="optionDescription">Select your optional extras</span>
            </div>
            <div class="optionCostContainer">
                <span class="optionCostHeading">CURRENT QUOTE >></span>
                <span class="optionCost">R0,00</span>
            </div>
            <a class="button submitButton" href="#">accept</a>
        </div>
        <div class="choiceWrapper">
            <div class="dateChoiceContainer choiceContainer">
                <span class="textBoxTitle">START DATE</span><br />
                <input class="textbox" type="text" /><br /><br />
                <span class="textBoxTitle">END DATE</span><br />
                <input class="textbox" type="text" /><br /><br />
            </div>
            <div class="branchChoiceContainer choiceContainer">
                <span class="textBoxTitle">COLLECTION BRANCH</span><br />
                <select class="dropdown">
                    <option>Johannesburg</option>
                    <option>Cape Town</option>
                    <option>Durban</option>
                    <option>Port Elizabeth</option>
                    <option>Potchefstroom</option>
                </select><br /><br />
                <span class="textBoxTitle">DROP OFF BRANCH</span><br />
                <select class="dropdown">
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
                <div class="modelContainer">
                    <img class="modelLogo" src="./Images/Logo/audi_logo.png" alt="" />
                    <span class="modelTitle selectedModel">TT RS</span>
                    <img class="availabilityLogo" src="./Images/Logo/available.png" alt="" />
                </div>
                <div class="modelContainer">
                    <img class="modelLogo" src="./Images/Logo/vw_logo.png" alt="" />
                    <span class="modelTitle">Golf 6 .:R</span>
                    <img class="availabilityLogo" src="./Images/Logo/unavailable.png" alt="" />
                </div>
                <div class="modelContainer">
                    <img class="modelLogo" src="./Images/Logo/vw_logo.png" alt="" />
                    <span class="modelTitle">Golf 6 GTI</span>
                    <img class="availabilityLogo" src="./Images/Logo/available.png" alt="" />
                </div>
                <div class="modelContainer">
                    <img class="modelLogo" src="./Images/Logo/porsche_logo.png" alt="" />
                    <span class="modelTitle">Cayenne Turbo</span>
                    <img class="availabilityLogo" src="./Images/Logo/unavailable.png" alt="" />
                </div>
                <div class="modelContainer">
                    <img class="modelLogo" src="./Images/Logo/audi_logo.png" alt="" />
                    <span class="modelTitle">.:RS4</span>
                    <img class="availabilityLogo" src="./Images/Logo/unavailable.png" alt="" />
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
        </div>
    </div>
</asp:Content>
=======
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="FirstForRentals.Web.Application" %>
<asp:Content ID="cntHead" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/application.css" rel="stylesheet" />
    <script type="text/javascript" src="JS/Pages/application.js"></script>
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
            <div class="optionContainer" data-content="modelChoiceContainer">
                <span class="optionHeading">MODEL</span><br />
                <span class="optionDescription">Select your car model</span>
            </div>
            <div class="optionContainer" data-content="extrasContainer">
                <span class="optionHeading">OPTIONS</span><br />
                <span class="optionDescription">Select your optional extras</span>
            </div>
            <div class="optionCostContainer">
                <span class="optionCostHeading">CURRENT QUOTE >></span>
                <span class="optionCost">R0,00</span>
            </div>
            <a class="button submitButton" href="#">accept</a>
        </div>
        <div class="choiceWrapper">
            <div class="dateChoiceContainer choiceContainer">
                <span class="textBoxTitle">START DATE</span><br />
                <input class="textbox" type="text" /><br /><br />
                <span class="textBoxTitle">END DATE</span><br />
                <input class="textbox" type="text" /><br /><br />
            </div>
            <div class="branchChoiceContainer choiceContainer">
                <span class="textBoxTitle">COLLECTION BRANCH</span><br />
                <select class="dropdown">
                    <option>Johannesburg</option>
                    <option>Cape Town</option>
                    <option>Durban</option>
                    <option>Port Elizabeth</option>
                    <option>Potchefstroom</option>
                </select><br /><br />
                <span class="textBoxTitle">DROP OFF BRANCH</span><br />
                <select class="dropdown">
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
                <div class="modelContainer">
                    <img class="modelLogo" src="./Images/Logo/audi_logo.png" alt="" />
                    <span class="modelTitle selectedModel">TT RS</span>
                    <img class="availabilityLogo" src="./Images/Logo/available.png" alt="" />
                </div>
                <div class="modelContainer">
                    <img class="modelLogo" src="./Images/Logo/vw_logo.png" alt="" />
                    <span class="modelTitle">Golf 6 .:R</span>
                    <img class="availabilityLogo" src="./Images/Logo/unavailable.png" alt="" />
                </div>
                <div class="modelContainer">
                    <img class="modelLogo" src="./Images/Logo/vw_logo.png" alt="" />
                    <span class="modelTitle">Golf 6 GTI</span>
                    <img class="availabilityLogo" src="./Images/Logo/available.png" alt="" />
                </div>
                <div class="modelContainer">
                    <img class="modelLogo" src="./Images/Logo/porsche_logo.png" alt="" />
                    <span class="modelTitle">Cayenne Turbo</span>
                    <img class="availabilityLogo" src="./Images/Logo/unavailable.png" alt="" />
                </div>
                <div class="modelContainer">
                    <img class="modelLogo" src="./Images/Logo/audi_logo.png" alt="" />
                    <span class="modelTitle">.:RS4</span>
                    <img class="availabilityLogo" src="./Images/Logo/unavailable.png" alt="" />
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
        </div>
    </div>
</asp:Content>
>>>>>>> origin/master
