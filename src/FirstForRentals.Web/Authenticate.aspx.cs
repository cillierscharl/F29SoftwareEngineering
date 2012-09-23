<<<<<<< HEAD
﻿using System;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Web;
using DotNetOpenAuth.ApplicationBlock;
using DotNetOpenAuth.ApplicationBlock.Facebook;
using DotNetOpenAuth.OAuth2;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.RelyingParty;
using FirstForRentals.Web.WindowsLive_Auth;
using FirstForRentals.Web.Entities;

namespace FirstForRentals.Web
{
    public partial class Authenticate : System.Web.UI.Page
    {
        private static readonly WindowsLiveClient WlClient = new WindowsLiveClient
        {
            ClientIdentifier = ConfigurationManager.AppSettings["windowsLiveAppID"],
            ClientSecret = ConfigurationManager.AppSettings["WindowsLiveAppSecret"],
        };

        private static readonly FacebookClient FbClient = new FacebookClient
        {
            ClientIdentifier = ConfigurationManager.AppSettings["facebookAppID"],
            ClientSecret = ConfigurationManager.AppSettings["facebookAppSecret"],
        };

        private static string _provider;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                HttpCookie userCredentials = Request.Cookies["FirstForRentalsUserCredentials"];

                if (userCredentials != null)
                {
                    //Response.Redirect("./Default.aspx");
                }

                if(_provider != null)
                {
                    HandleProviderResponse();
                }
            }else
            {
                HandleRequest();
            }
        }

        private void HandleProviderResponse()
        {
            switch(_provider)
            {
                case "windowslive":
                    HandleWindowsLiveResponse();
                    break;
                case "twitter":
                    HandleTwitterResponse();
                    break;
                case "facebook":
                    HandleFacebookResponse();
                    break;
                case "google":
                    HandleGoogleResponse();
                    break;
                case "yahoo":
                    HandleYahooResponse();
                    break;
            }
        }

        private void HandleGoogleResponse()
        {
            using (var openid = new OpenIdRelyingParty())
            {
                var response = openid.GetResponse();
                if (response == null) return;
 
                switch (response.Status)
                {
                    // If user was authenticated
                    case AuthenticationStatus.Authenticated:
                        // This is where you would look for any OpenID extension responses included
                        // in the authentication assertion.
                        var fetchResponse = response.GetExtension<FetchResponse>();
                        
                        string firstName = fetchResponse.GetAttributeValue(WellKnownAttributes.Name.First); 
                        string lastName = fetchResponse.GetAttributeValue(WellKnownAttributes.Name.Last);
                        string email = fetchResponse.GetAttributeValue(WellKnownAttributes.Contact.Email) ?? "N/A";

                        AuthenticatedUser(firstName, lastName, email, email,"Google");

                        break;
                    // User has cancelled the OpenID Dance
                    case AuthenticationStatus.Canceled:

                        break;
                    // Authentication failed
                    case AuthenticationStatus.Failed:

                        break;
                }
            }
        }

        private void HandleYahooResponse()
        {
            using (var openid = new OpenIdRelyingParty())
            {
                var response = openid.GetResponse();
                switch (response.Status)
                {
                    // If user was authenticated
                    case AuthenticationStatus.Authenticated:
                        // This is where you would look for any OpenID extension responses included
                        // in the authentication assertion.
                        var fetchResponse = response.GetExtension<FetchResponse>();

                        string firstName = fetchResponse.GetAttributeValue(WellKnownAttributes.Name.First);
                        string lastName = fetchResponse.GetAttributeValue(WellKnownAttributes.Name.Last);
                        string email = fetchResponse.GetAttributeValue(WellKnownAttributes.Contact.Email) ?? "N/A";

                        AuthenticatedUser(firstName, lastName, email, email,"Yahoo");

                        break;
                    // User has cancelled the OpenID Dance
                    case AuthenticationStatus.Canceled:

                        break;
                    // Authentication failed
                    case AuthenticationStatus.Failed:

                        break;
                }
            }
        }

        private void HandleFacebookResponse()
        {
            IAuthorizationState authorization = FbClient.ProcessUserAuthorization();
            if (authorization != null)
            {
                var request = WebRequest.Create("https://graph.facebook.com/me?access_token=" + Uri.EscapeDataString(authorization.AccessToken));
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        var graph = FacebookGraph.Deserialize(responseStream);
                        AuthenticatedUser(graph.FirstName, graph.LastName, "", graph.Id.ToString(CultureInfo.CurrentCulture),"Facebook");
                    }
                }
            }
        }

        private void HandleWindowsLiveResponse()
        {
            IAuthorizationState authorization = WlClient.ProcessUserAuthorization();
            if (authorization != null)
            {
                var request =
                    WebRequest.Create("https://apis.live.net/v5.0/me?access_token=" + Uri.EscapeDataString(authorization.AccessToken));
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        var graph = WindowsLiveDetail.Deserialize(responseStream);
                        AuthenticatedUser(graph.FirstName, graph.LastName, graph.Email.Account, graph.Id,"Windows Live");
                    }
                }
            }
        }

        private void HandleTwitterResponse()
        {
            string screenName;
            int userId;
            if (TwitterConsumer.TryFinishSignInWithTwitter(out screenName, out userId))
            {
                AuthenticatedUser(screenName, "", screenName, userId.ToString(CultureInfo.CurrentCulture),"Twitter");
            }
        }

        private void HandleRequest()
        {
            string authProvider = hdnAuthType.Value;
            _provider = authProvider;

            switch (authProvider)
            {
                case "google":
                    GoogleLogin();
                    break;
                case "yahoo":
                    YahooLogin();
                    break;
                case "windowslive":
                    WindowsLiveLogin();
                    break;
                case "twitter":
                    TwitterLogin();
                    break;
                case "facebook":
                    FacebookLogin();
                    break;
            }
        }

        private static void GoogleLogin()
        {
            // Create a new instance of OpenIdRelyingParty
            using (var openid = new OpenIdRelyingParty())
            {
                var request = openid.CreateRequest(ConfigurationManager.AppSettings["googleOAuthAddress"]);

                var fetchRequest = new FetchRequest();
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.First);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.Last);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.HomeAddress.Country);
                request.AddExtension(fetchRequest);

                // Issue request to OP
                request.RedirectToProvider();
            }
        }

        private static void YahooLogin()
        {
            // Create a new instance of OpenIdRelyingParty
            using (var openid = new OpenIdRelyingParty())
            {
                var request = openid.CreateRequest(ConfigurationManager.AppSettings["yahooOAuthAddress"]);

                var fetchRequest = new FetchRequest();
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.First);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.Last);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.HomeAddress.Country);
                request.AddExtension(fetchRequest);

                // Issue request to OP
                request.RedirectToProvider();
            }
        }

        private static void WindowsLiveLogin()
        {
            WlClient.RequestUserAuthorization(new[] { WindowsLiveClient.Scopes.Basic, "wl.emails" });
        }

        private static void TwitterLogin()
        {
            TwitterConsumer.StartSignInWithTwitter(true).Send();
        }

        private static void FacebookLogin()
        {
            FbClient.RequestUserAuthorization();
        }

        private void AuthenticatedUser(string firstname, string lastname, string email, string uid , string authProvider)
        {
            var user = new User
                           {
                               FirstName = firstname,
                               LastName = lastname,
                               FullName = firstname + " " + lastname,
                               Email = email,
                               Uid = uid,
                               Provider = authProvider  
                           };


            HttpCookie retroUserCredentials = new HttpCookie("FirstForRentalsUserCredentials", user.ToJson()) { Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Add(retroUserCredentials);
            Response.Redirect("./Default.aspx");

            //if (result.Length > 0)
            //{
            //    HttpCookie retroUserCredentials = new HttpCookie("retroUserCredentials", user.ToJson()) { Expires = DateTime.Now.AddDays(30) };
            //    Response.Cookies.Add(retroUserCredentials);
            //    Response.Redirect("./Manage.aspx");
            //}
            //else
            //{
            //    client.AccessRequest(retroUser);
            //    ClientScript.RegisterStartupScript(this.GetType(), "alertKey",
            //                                       "window.alert('Unauthorized User, Access Request Sent.');", true);
            //}
        }
    }
=======
﻿using System;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Web;
using DotNetOpenAuth.ApplicationBlock;
using DotNetOpenAuth.ApplicationBlock.Facebook;
using DotNetOpenAuth.OAuth2;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.RelyingParty;
using FirstForRentals.Web.WindowsLive_Auth;
using FirstForRentals.Web.Entities;

namespace FirstForRentals.Web
{
    public partial class Authenticate : System.Web.UI.Page
    {
        private static readonly WindowsLiveClient WlClient = new WindowsLiveClient
        {
            ClientIdentifier = ConfigurationManager.AppSettings["windowsLiveAppID"],
            ClientSecret = ConfigurationManager.AppSettings["WindowsLiveAppSecret"],
        };

        private static readonly FacebookClient FbClient = new FacebookClient
        {
            ClientIdentifier = ConfigurationManager.AppSettings["facebookAppID"],
            ClientSecret = ConfigurationManager.AppSettings["facebookAppSecret"],
        };

        private static string _provider;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                HttpCookie userCredentials = Request.Cookies["FirstForRentalsUserCredentials"];

                if (userCredentials != null)
                {
                    //Response.Redirect("./Default.aspx");
                }

                if(_provider != null)
                {
                    HandleProviderResponse();
                }
            }else
            {
                HandleRequest();
            }
        }

        private void HandleProviderResponse()
        {
            switch(_provider)
            {
                case "windowslive":
                    HandleWindowsLiveResponse();
                    break;
                case "twitter":
                    HandleTwitterResponse();
                    break;
                case "facebook":
                    HandleFacebookResponse();
                    break;
                case "google":
                    HandleGoogleResponse();
                    break;
                case "yahoo":
                    HandleYahooResponse();
                    break;
            }
        }

        private void HandleGoogleResponse()
        {
            using (var openid = new OpenIdRelyingParty())
            {
                var response = openid.GetResponse();
                if (response == null) return;
 
                switch (response.Status)
                {
                    // If user was authenticated
                    case AuthenticationStatus.Authenticated:
                        // This is where you would look for any OpenID extension responses included
                        // in the authentication assertion.
                        var fetchResponse = response.GetExtension<FetchResponse>();
                        
                        string firstName = fetchResponse.GetAttributeValue(WellKnownAttributes.Name.First); 
                        string lastName = fetchResponse.GetAttributeValue(WellKnownAttributes.Name.Last);
                        string email = fetchResponse.GetAttributeValue(WellKnownAttributes.Contact.Email) ?? "N/A";

                        AuthenticatedUser(firstName, lastName, email, email,"Google");

                        break;
                    // User has cancelled the OpenID Dance
                    case AuthenticationStatus.Canceled:

                        break;
                    // Authentication failed
                    case AuthenticationStatus.Failed:

                        break;
                }
            }
        }

        private void HandleYahooResponse()
        {
            using (var openid = new OpenIdRelyingParty())
            {
                var response = openid.GetResponse();
                switch (response.Status)
                {
                    // If user was authenticated
                    case AuthenticationStatus.Authenticated:
                        // This is where you would look for any OpenID extension responses included
                        // in the authentication assertion.
                        var fetchResponse = response.GetExtension<FetchResponse>();

                        string firstName = fetchResponse.GetAttributeValue(WellKnownAttributes.Name.First);
                        string lastName = fetchResponse.GetAttributeValue(WellKnownAttributes.Name.Last);
                        string email = fetchResponse.GetAttributeValue(WellKnownAttributes.Contact.Email) ?? "N/A";

                        AuthenticatedUser(firstName, lastName, email, email,"Yahoo");

                        break;
                    // User has cancelled the OpenID Dance
                    case AuthenticationStatus.Canceled:

                        break;
                    // Authentication failed
                    case AuthenticationStatus.Failed:

                        break;
                }
            }
        }

        private void HandleFacebookResponse()
        {
            IAuthorizationState authorization = FbClient.ProcessUserAuthorization();
            if (authorization != null)
            {
                var request = WebRequest.Create("https://graph.facebook.com/me?access_token=" + Uri.EscapeDataString(authorization.AccessToken));
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        var graph = FacebookGraph.Deserialize(responseStream);
                        AuthenticatedUser(graph.FirstName, graph.LastName, "", graph.Id.ToString(CultureInfo.CurrentCulture),"Facebook");
                    }
                }
            }
        }

        private void HandleWindowsLiveResponse()
        {
            IAuthorizationState authorization = WlClient.ProcessUserAuthorization();
            if (authorization != null)
            {
                var request =
                    WebRequest.Create("https://apis.live.net/v5.0/me?access_token=" + Uri.EscapeDataString(authorization.AccessToken));
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        var graph = WindowsLiveDetail.Deserialize(responseStream);
                        AuthenticatedUser(graph.FirstName, graph.LastName, graph.Email.Account, graph.Id,"Windows Live");
                    }
                }
            }
        }

        private void HandleTwitterResponse()
        {
            string screenName;
            int userId;
            if (TwitterConsumer.TryFinishSignInWithTwitter(out screenName, out userId))
            {
                AuthenticatedUser(screenName, "", screenName, userId.ToString(CultureInfo.CurrentCulture),"Twitter");
            }
        }

        private void HandleRequest()
        {
            string authProvider = hdnAuthType.Value;
            _provider = authProvider;

            switch (authProvider)
            {
                case "google":
                    GoogleLogin();
                    break;
                case "yahoo":
                    YahooLogin();
                    break;
                case "windowslive":
                    WindowsLiveLogin();
                    break;
                case "twitter":
                    TwitterLogin();
                    break;
                case "facebook":
                    FacebookLogin();
                    break;
            }
        }

        private static void GoogleLogin()
        {
            // Create a new instance of OpenIdRelyingParty
            using (var openid = new OpenIdRelyingParty())
            {
                var request = openid.CreateRequest(ConfigurationManager.AppSettings["googleOAuthAddress"]);

                var fetchRequest = new FetchRequest();
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.First);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.Last);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.HomeAddress.Country);
                request.AddExtension(fetchRequest);

                // Issue request to OP
                request.RedirectToProvider();
            }
        }

        private static void YahooLogin()
        {
            // Create a new instance of OpenIdRelyingParty
            using (var openid = new OpenIdRelyingParty())
            {
                var request = openid.CreateRequest(ConfigurationManager.AppSettings["yahooOAuthAddress"]);

                var fetchRequest = new FetchRequest();
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.First);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.Last);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.HomeAddress.Country);
                request.AddExtension(fetchRequest);

                // Issue request to OP
                request.RedirectToProvider();
            }
        }

        private static void WindowsLiveLogin()
        {
            WlClient.RequestUserAuthorization(new[] { WindowsLiveClient.Scopes.Basic, "wl.emails" });
        }

        private static void TwitterLogin()
        {
            TwitterConsumer.StartSignInWithTwitter(true).Send();
        }

        private static void FacebookLogin()
        {
            FbClient.RequestUserAuthorization();
        }

        private void AuthenticatedUser(string firstname, string lastname, string email, string uid , string authProvider)
        {
            var user = new User
                           {
                               FirstName = firstname,
                               LastName = lastname,
                               FullName = firstname + " " + lastname,
                               Email = email,
                               Uid = uid,
                               Provider = authProvider  
                           };


            HttpCookie retroUserCredentials = new HttpCookie("FirstForRentalsUserCredentials", user.ToJson()) { Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Add(retroUserCredentials);
            Response.Redirect("./Default.aspx");

            //if (result.Length > 0)
            //{
            //    HttpCookie retroUserCredentials = new HttpCookie("retroUserCredentials", user.ToJson()) { Expires = DateTime.Now.AddDays(30) };
            //    Response.Cookies.Add(retroUserCredentials);
            //    Response.Redirect("./Manage.aspx");
            //}
            //else
            //{
            //    client.AccessRequest(retroUser);
            //    ClientScript.RegisterStartupScript(this.GetType(), "alertKey",
            //                                       "window.alert('Unauthorized User, Access Request Sent.');", true);
            //}
        }
    }
>>>>>>> origin/master
}