<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Home.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FirstForRentals.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/JS/Pages/home.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tileContainer">

        <div class="tile tileBoxStandard tilePurple">
            <a href="/application/executive"><img class="executiveImage" src="./Images/Resource/audi.jpg" alt="" /></a>
            <div class="lamborghiniLogoWrapper">
                <span class="tileTextWrapper">EXECUTIVE</span>
            </div>
        </div>
        <div class="tile tileBoxWide tileGrey">
            <img class="lamborghini" src="./Images/Resource/Lamborghini.jpg" alt="" />
            <div class="lamborghiniLogoWrapper">
                <img class="lamborghiniLogo" src="./Images/Resource/lamborghini-logo.jpg" alt="" />
            </div>
        </div>
        <div class="tile tileBoxStandard tileGrey">
            <img alt="" src="./Images/Logo/twitter_tile.png" class="tileLogo" />
            <div class="tileTitleWrapper">
                <span>twitter</span>
            </div>
        </div>
        <div class="tile tileBoxWide tileGrey">
            <img src="Images/Resource/tilebackground.png" class="tileFeatureBackgroundImage" alt="" />
            <span class="tileFeature feature1">GARMIN GPS</span><br />
            <span class="tileFeature feature2">ROADSIDE ASSISTANCE</span><br />
            <span class="tileFeature feature3">EXCLUSIVE MODELS</span><br />
            <span class="tileFeature feature4">LONG TERM PLANS</span>
        </div>
        <div class="tile tileBoxStandard tilePurple">
            <a href="/application/industrial"><img class="truckImage" src="./Images/Resource/truck.jpg" alt="" /></a>
            <div class="lamborghiniLogoWrapper">
                <span class="tileTextWrapper">SPECIAL ON INDUSTRIAL</span>
            </div>
        </div>
        <div class="tile tileBoxStandard tileBlue">
            <img alt="" src="./Images/Logo/contact.png" class="tileLogo" />
            <div class="tileTitleWrapper">
                <span>contact</span>
            </div>
        </div>
    </div>
</asp:Content>