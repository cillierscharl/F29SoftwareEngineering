<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authenticate.aspx.cs" Inherits="FirstForRentals.Web.Authenticate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Retro - Authenticate</title>
    <script type="text/javascript" src="JS/Lib/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="js/Pages/auth.js" ></script>

    <link href="css/auth.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnAuthType" />
    
    <div class="backGradientTop"></div>
    <div class="backGradientBottom"></div>

    <div class="bottomLine"></div>
    
    <div class="loginContainer">
        <span class="retroHeading" style="color: #2C98EB;">first for rentals</span><br />
        <span class="authHeading">authentication</span><br />
        
        <div class="loginProviders">
            <div data-authProvider="google" class="entityContainer entityContainerBlock metroBlue"><img alt="" src="./Images/logo/google.gif" /></div>
            <div data-authProvider="facebook" class="entityContainer entityContainerBlock metroBlue"><img alt="" src="./Images/logo/facebook.gif" /></div>
            <div data-authProvider="openid" class="entityContainer entityContainerBlock metroBlue"><img alt="" src="./Images/logo/myopenid.gif" /></div>
            <div data-authProvider="windowslive" class="entityContainer entityContainerBlock metroBlue"><img id="wlSignIn" alt="" src="./Images/logo/windows-live.jpg" /></div>
            <div data-authProvider="yahoo" class="entityContainer entityContainerBlock metroBlue"><img alt="" src="./Images/logo/yahoo.jpg"/></div>
            <div data-authProvider="twitter" class="entityContainer entityContainerBlock metroBlue"><img alt="" src="./Images/logo/twitter.png"/></div>
        </div>
    </div>
    </form>
</body>
</html>