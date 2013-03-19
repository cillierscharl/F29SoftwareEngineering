<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin.Master" AutoEventWireup="true" CodeBehind="admin_vehicle.aspx.cs" Inherits="FirstForRentals.Web.admin_vehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/JS/Pages/CallbackHandler.js"></script>
    <script src="/JS/Pages/admin_vehicle.js"></script>
    <link href="/CSS/admin_vehicle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentWrapper">
        <div class="optionsWrapper">
            <div class="optionSelector">

            </div>
            <div class="optionContainer" data-content="commercialChoiceContainer">
                <span class="optionHeading selectedOption">COMMERCIAL</span><br />
                <span class="optionDescription">Manage commercial vehicles</span>
            </div>
            <div class="optionContainer" data-content="industrialChoiceContainer">
                <span class="optionHeading">INDUSTRIAL</span><br />
                <span class="optionDescription">Manage industrial vehicles</span>
            </div>
            <div class="optionContainer" data-content="leasureChoiceContainer">
                <span class="optionHeading ">LEASURE</span><br />
                <span class="optionDescription">Manage leasure vehicles</span>
            </div>
            <div class="optionContainer" data-content="executiveChoiceContainer">
                <span class="optionHeading">EXECUTIVE</span><br />
                <span class="optionDescription">Manage executive vehicles</span>
            </div>
        </div>
        <div class="choiceWrapper">
            <div class="commercialChoiceContainer choiceContainer">
                <div class="choiceContainerHeading">
                    <a href="#" class="breadcrumb link activeSubBreadCrumb vehiclesDetailsLink">details.</a><a href="#" class="breadcrumb link faultsLink">faults.</a><a href="#" class="breadcrumb link thresholdsLink">thresholds.</a>
                </div>
                <div class="vehicleIdentificationContainer choiceSubContainer">
                    <span class="textBoxTitle">VEHICLE IDENTIFICATION</span><br />
                    <select class="dropdown">

                    </select><br />
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">MAKE</span><br />
                                <input class="textbox noEdit makeDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">MODEL</span><br />
                                <input class="textbox noEdit modelDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">MILEAGE (KM)</span><br />
                                <input class="textbox noEdit mileageDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">YEAR</span><br />
                                <input class="textbox noEdit yearDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">SERVICE START DATE</span><br />
                                <input class="textbox noEdit startDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">SERVICE END DATE</span><br />
                                <input class="textbox noEdit endDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">SERVICE STATUS</span><br />
                                <input class="textbox noEdit serviceDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">RENTAL STATUS</span><br />
                                <input class="textbox noEdit rentalDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="recordFaultContainer choiceSubContainer">
                    <div class="choiceSubNavigationContainer">
                        <img src="/Images/Resource/add.png" class="choiceSubNavigationCommand faultAddLink" alt="" />
                    </div>
                    <div class="faultTableContainer">
                        
                    </div>
                </div>
                <div class="vehicleThresholdContainer choiceSubContainer">
                    <div class="thresholdTableContainer">
                        
                    </div>
                </div>
                <div class="recordFaultAddContainer choiceSubContainer">     
                    <div class="choiceSubNavigationContainer">
                        <img src="/Images/Resource/back.png" class="choiceSubNavigationCommand faultAddCancel" alt="" />
                    </div>           
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">VEHICLE IDENTIFICATION</span><br />
                                <input class="textbox noEdit faultVehicleDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">FAULT DATE</span><br />
                                <input class="textbox dateFieldFull faultVehicleDate" type="text" />
                            </td>
                        </tr>
                    </table>
                    <span class="textBoxTitle">FAULT DESCRIPTION</span><br />
                    <textarea class="textbox faultVehicleDescription"></textarea>
                
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">FAULT COST</span><br />
                                <input class="textbox faultVehicleCost" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">SERVICE SUSPENSION</span><br />
                                <input class="faultVehicleSuspension" type="checkbox" /><br />
                                <span class="textBoxTitle">INSURANCE CLAIM</span><br />
                                <input class="faultVehicleClaim" type="checkbox" />
                            </td>
                        </tr>
                    </table>
                    <a class="button submitButton submitFault">submit fault</a>
                </div>
            </div>
            <div class="industrialChoiceContainer choiceContainer">
                <div class="choiceContainerHeading">
                    <a href="#" class="breadcrumb link activeSubBreadCrumb vehiclesDetailsLink">details.</a><a href="#" class="breadcrumb link faultsLink">faults.</a><a href="#" class="breadcrumb link thresholdsLink">thresholds.</a>
                </div>
                <div class="vehicleIdentificationContainer choiceSubContainer">
                    <span class="textBoxTitle">VEHICLE IDENTIFICATION</span><br />
                    <select class="dropdown">

                    </select><br />
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">MAKE</span><br />
                                <input class="textbox noEdit makeDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">MODEL</span><br />
                                <input class="textbox noEdit modelDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">MILEAGE (KM)</span><br />
                                <input class="textbox noEdit mileageDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">YEAR</span><br />
                                <input class="textbox noEdit yearDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">SERVICE START DATE</span><br />
                                <input class="textbox noEdit startDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">SERVICE END DATE</span><br />
                                <input class="textbox noEdit endDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">SERVICE STATUS</span><br />
                                <input class="textbox noEdit serviceDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">RENTAL STATUS</span><br />
                                <input class="textbox noEdit rentalDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="recordFaultContainer choiceSubContainer">
                    <div class="choiceSubNavigationContainer">
                        <img src="/Images/Resource/add.png" class="choiceSubNavigationCommand faultAddLink" alt="" />
                    </div>
                    <div class="faultTableContainer">
                        
                    </div>
                </div>
                <div class="vehicleThresholdContainer choiceSubContainer">
                    <div class="thresholdTableContainer">
                        
                    </div>
                </div>
                <div class="recordFaultAddContainer choiceSubContainer">     
                    <div class="choiceSubNavigationContainer">
                        <img src="/Images/Resource/back.png" class="choiceSubNavigationCommand faultAddCancel" alt="" />
                    </div>           
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">VEHICLE IDENTIFICATION</span><br />
                                <input class="textbox noEdit faultVehicleDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">FAULT DATE</span><br />
                                <input class="textbox dateFieldFull faultVehicleDate" type="text" />
                            </td>
                        </tr>
                    </table>
                    <span class="textBoxTitle">FAULT DESCRIPTION</span><br />
                    <textarea class="textbox faultVehicleDescription"></textarea>
                
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">FAULT COST</span><br />
                                <input class="textbox faultVehicleCost" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">SERVICE SUSPENSION</span><br />
                                <input class="faultVehicleSuspension" type="checkbox" /><br />
                                <span class="textBoxTitle">INSURANCE CLAIM</span><br />
                                <input class="faultVehicleClaim" type="checkbox" />
                            </td>
                        </tr>
                    </table>
                    <a class="button submitButton submitFault">submit fault</a>
                </div>
            </div>
            <div class="leasureChoiceContainer choiceContainer">
                <div class="choiceContainerHeading">
                    <a href="#" class="breadcrumb link activeSubBreadCrumb vehiclesDetailsLink">details.</a><a href="#" class="breadcrumb link faultsLink">faults.</a><a href="#" class="breadcrumb link thresholdsLink">thresholds.</a>
                </div>
                <div class="vehicleIdentificationContainer choiceSubContainer">
                    <span class="textBoxTitle">VEHICLE IDENTIFICATION</span><br />
                    <select class="dropdown">

                    </select><br />
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">MAKE</span><br />
                                <input class="textbox noEdit makeDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">MODEL</span><br />
                                <input class="textbox noEdit modelDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">MILEAGE (KM)</span><br />
                                <input class="textbox noEdit mileageDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">YEAR</span><br />
                                <input class="textbox noEdit yearDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">SERVICE START DATE</span><br />
                                <input class="textbox noEdit startDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">SERVICE END DATE</span><br />
                                <input class="textbox noEdit endDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">SERVICE STATUS</span><br />
                                <input class="textbox noEdit serviceDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">RENTAL STATUS</span><br />
                                <input class="textbox noEdit rentalDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="recordFaultContainer choiceSubContainer">
                    <div class="choiceSubNavigationContainer">
                        <img src="/Images/Resource/add.png" class="choiceSubNavigationCommand faultAddLink" alt="" />
                    </div>
                    <div class="faultTableContainer">
                        
                    </div>
                </div>
                <div class="vehicleThresholdContainer choiceSubContainer">
                    <div class="thresholdTableContainer">
                        
                    </div>
                </div>
                <div class="recordFaultAddContainer choiceSubContainer">     
                    <div class="choiceSubNavigationContainer">
                        <img src="/Images/Resource/back.png" class="choiceSubNavigationCommand faultAddCancel" alt="" />
                    </div>           
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">VEHICLE IDENTIFICATION</span><br />
                                <input class="textbox noEdit faultVehicleDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">FAULT DATE</span><br />
                                <input class="textbox dateFieldFull faultVehicleDate" type="text" />
                            </td>
                        </tr>
                    </table>
                    <span class="textBoxTitle">FAULT DESCRIPTION</span><br />
                    <textarea class="textbox faultVehicleDescription"></textarea>
                
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">FAULT COST</span><br />
                                <input class="textbox faultVehicleCost" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">SERVICE SUSPENSION</span><br />
                                <input class="faultVehicleSuspension" type="checkbox" /><br />
                                <span class="textBoxTitle">INSURANCE CLAIM</span><br />
                                <input class="faultVehicleClaim" type="checkbox" />
                            </td>
                        </tr>
                    </table>
                    <a class="button submitButton submitFault">submit fault</a>
                </div>
            </div>
            <div class="executiveChoiceContainer choiceContainer">
                <div class="choiceContainerHeading">
                    <a href="#" class="breadcrumb link activeSubBreadCrumb vehiclesDetailsLink">details.</a><a href="#" class="breadcrumb link faultsLink">faults.</a><a href="#" class="breadcrumb link thresholdsLink">thresholds.</a>
                </div>
                <div class="vehicleIdentificationContainer choiceSubContainer">
                    <span class="textBoxTitle">VEHICLE IDENTIFICATION</span><br />
                    <select class="dropdown">

                    </select><br />
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">MAKE</span><br />
                                <input class="textbox noEdit makeDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">MODEL</span><br />
                                <input class="textbox noEdit modelDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">MILEAGE (KM)</span><br />
                                <input class="textbox noEdit mileageDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">YEAR</span><br />
                                <input class="textbox noEdit yearDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">SERVICE START DATE</span><br />
                                <input class="textbox noEdit startDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">SERVICE END DATE</span><br />
                                <input class="textbox noEdit endDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">SERVICE STATUS</span><br />
                                <input class="textbox noEdit serviceDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">RENTAL STATUS</span><br />
                                <input class="textbox noEdit rentalDetail" type="text" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="recordFaultContainer choiceSubContainer">
                    <div class="choiceSubNavigationContainer">
                        <img src="/Images/Resource/add.png" class="choiceSubNavigationCommand faultAddLink" alt="" />
                    </div>
                    <div class="faultTableContainer">
                        
                    </div>
                </div>
                <div class="vehicleThresholdContainer choiceSubContainer">
                    <div class="thresholdTableContainer">
                        
                    </div>
                </div>
                <div class="recordFaultAddContainer choiceSubContainer">     
                    <div class="choiceSubNavigationContainer">
                        <img src="/Images/Resource/back.png" class="choiceSubNavigationCommand faultAddCancel" alt="" />
                    </div>           
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">VEHICLE IDENTIFICATION</span><br />
                                <input class="textbox noEdit faultVehicleDetail" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">FAULT DATE</span><br />
                                <input class="textbox dateFieldFull faultVehicleDate" type="text" />
                            </td>
                        </tr>
                    </table>
                    <span class="textBoxTitle">FAULT DESCRIPTION</span><br />
                    <textarea class="textbox faultVehicleDescription"></textarea>
                
                    <table class="wideTable">
                        <tr>
                            <td>
                                <span class="textBoxTitle">FAULT COST</span><br />
                                <input class="textbox faultVehicleCost" type="text" />
                            </td>
                            <td>
                                <span class="textBoxTitle">SERVICE SUSPENSION</span><br />
                                <input class="faultVehicleSuspension" type="checkbox" /><br />
                                <span class="textBoxTitle">INSURANCE CLAIM</span><br />
                                <input class="faultVehicleClaim" type="checkbox" />
                            </td>
                        </tr>
                    </table>
                    <a class="button submitButton submitFault">submit fault</a>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
