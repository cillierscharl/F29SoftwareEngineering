using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstForRentals.Web
{
    public partial class admin_customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            customerSearchOption.ClientIDMode = ClientIDMode.Static;
            paymentSearchOption.ClientIDMode = ClientIDMode.Static;
            rentalSearchOption.ClientIDMode = ClientIDMode.Static;

            var client = new FirstForRentalsService();

            var customerResponse = client.GetCustomers();
            var paymentResponse = client.GetPayments();
            var rentalResponse = client.GetRentals();

            customerSearchOption.InnerHtml = customerResponse;
            paymentSearchOption.InnerHtml = paymentResponse;
            rentalSearchOption.InnerHtml = rentalResponse;
        }
    }
}