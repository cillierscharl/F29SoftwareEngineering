<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin.Master" AutoEventWireup="True" CodeBehind="admin_customer.aspx.cs" Inherits="FirstForRentals.Web.admin_customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/JS/Pages/admin_customer.js"></script>
    <link href="/CSS/admin_customer.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentWrapper">
        <div class="optionsWrapper">
            <div class="optionSelector">

            </div>
            <div class="optionContainer" data-content="customerSearchOption">
                <span class="optionHeading selectedOption">CUSTOMERS</span><br />
                <span class="optionDescription">View all customers in the database</span>
            </div>
            <div class="optionContainer" data-content="paymentsSearchOption">
                <span class="optionHeading selectedOption">PAYMENTS</span><br />
                <span class="optionDescription">View all payments</span>
            </div>
            <div class="optionContainer" data-content="rentalsSearchOption">
                <span class="optionHeading selectedOption">RENTALS</span><br />
                <span class="optionDescription">View all rentals</span>
            </div>
        </div>
        <div class="choiceWrapper">
            <div runat="server" id="customerSearchOption" class="customerSearchOption choiceContainer">

            </div>
        </div>
        <div class="choiceWrapper">
            <div runat="server" id="paymentSearchOption" class="paymentsSearchOption choiceContainer">

            </div>
        </div>
        <div class="choiceWrapper">
            <div runat="server" id="rentalSearchOption" class="rentalsSearchOption choiceContainer">

            </div>
        </div>

    </div>
</asp:Content>
