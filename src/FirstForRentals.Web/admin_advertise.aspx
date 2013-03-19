<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin.Master" AutoEventWireup="true" CodeBehind="admin_advertise.aspx.cs" Inherits="FirstForRentals.Web.admin_advertise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/application.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentWrapper">
        <div class="optionsWrapper">
            <div class="optionSelector">

            </div>
            <div class="optionContainer" data-content="dateChoiceContainer">
                <span class="optionHeading selectedOption">INSURANCE CLAIM</span><br />
                <span class="optionDescription">Record an incident claimed on insurance</span>
            </div>
            <div class="optionContainer" data-content="branchChoiceContainer">
                <span class="optionHeading">FAULT RECORDING</span><br />
                <span class="optionDescription">Record faults listed for vehicle</span>
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
        </div>
    </div>
</asp:Content>
