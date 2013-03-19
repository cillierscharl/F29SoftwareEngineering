<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin.Master" AutoEventWireup="true" CodeBehind="admin_statistics.aspx.cs" Inherits="FirstForRentals.Web.admin_statistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://code.highcharts.com/highcharts.js"></script>
    <script src="/JS/Pages/admin_statistics.js"></script>
    <link href="/CSS/admin_statistics.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentWrapper">
        <div class="optionsWrapper">
            <div class="optionSelector">

            </div>
            <div class="optionContainer" data-content="seasonalVariationContainer">
                <span class="optionHeading selectedOption">SEASONAL VARIATION</span><br />
                <span class="optionDescription">View the seasonal variation data</span>
            </div>
            <div class="optionContainer" data-content="vehiclePopularityContainer">
                <span class="optionHeading">VEHICLE POPULARITY</span><br />
                <span class="optionDescription">View the most popular vehicles</span>
            </div>
            <div class="optionContainer" data-content="incomeTrendContainer">
                <span class="optionHeading">INCOME TRENDS</span><br />
                <span class="optionDescription">View income trends</span>
            </div>
        </div>
        <div class="choiceWrapper">
            <div class="seasonalVariationContainer choiceContainer">
                <div id="seasonalVariationGraphContainer">

                </div>
            </div>
            <div class="vehiclePopularityContainer choiceContainer">
                <div id="vehiclePopularityGraphContainer">

                </div>
            </div>
            <div class="incomeTrendContainer choiceContainer">
                <div id="incomeTrendGraphContainer">

                </div>
            </div>
        </div>

    </div>
</asp:Content>
