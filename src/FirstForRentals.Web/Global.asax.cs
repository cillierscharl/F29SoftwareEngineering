using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace FirstForRentals.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapPageRoute("Application",
            "Application/{contextClass}",
            "~/Application.aspx");

            RouteTable.Routes.MapPageRoute("Admin_Customer",
                "Admin/Customer",
                "~/admin_customer.aspx");

            RouteTable.Routes.MapPageRoute("Admin_Vehicles",
                "Admin/Vehicles",
                "~/admin_vehicle.aspx");


            RouteTable.Routes.MapPageRoute("Admin_Statistics",
                "Admin/Statistics",
                "~/admin_statistics.aspx");

            RouteTable.Routes.MapPageRoute("Home",
                "Home",
                "~/home.aspx");

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}