using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstForRentals.Web
{
    public partial class admin_statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var client = new FirstForRentalsService();
            
                var seasonalGraphResponse = client.GetSeasonalVariationGraph();
                var popularityGraphResponse = client.GetVehiclePopularityGraph();
                var incomeTrendGraphResponse = client.GetIncomeTrendGraph();

                ClientScript.RegisterClientScriptBlock(this.GetType(), "seasonalVariationKey", "var seasonalVariation = " + seasonalGraphResponse, true);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "popularityGraphKey", ";var popularityGraph = " + popularityGraphResponse, true);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "incomeTrendGraphKey", ";var incomeTrendGraph = " + incomeTrendGraphResponse, true);
            }
        }
    }
}