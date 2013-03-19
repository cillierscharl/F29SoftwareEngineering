using FirstForRentals.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstForRentals.Web
{
    public partial class Application : System.Web.UI.Page, ICallbackEventHandler
    {
        private CallbackReturnContainer returnObject;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Hookup Client Side Event Handlers
                ClientScriptManager cm = Page.ClientScript;
                String cbReference = cm.GetCallbackEventReference(this, "arg", "ReceiveServerData", "");
                String callbackScript = "function CallServer(arg, context) {" + cbReference + "; }";
                cm.RegisterClientScriptBlock(this.GetType(), "CallServer", callbackScript, true);
                //

                string contextClass = Page.RouteData.Values["contextClass"].ToString();

                var client = new FirstForRentalsService();
                var carCollectionResponse = client.GetCarsByClass(contextClass);

                ClientScript.RegisterClientScriptBlock(this.GetType(), "carCollectionKey", "var carCollectionByClass = " + carCollectionResponse, true);
            }


        }


        // Callback Event Handlers

        public void RaiseCallbackEvent(string param)
        {
            var callbackContainer = CallbackParameterContainer.ReturnCallbackParameters(param);
            if (callbackContainer.Operation == "GET")
            {
                HandleGetCallback(callbackContainer);
            }
            else if (callbackContainer.Operation == "POST")
            {
                HandlePostCallback(callbackContainer);
            }

        }

        public string GetCallbackResult()
        {
            return returnObject.ToJson();
        }

        //
        private void HandlePostCallback(CallbackParameterContainer instructionSet)
        {
            switch (instructionSet.ActionRequested)
            {
                case "AddRental":
                    AddRental(instructionSet);
                    break;
            }
        }

        private void HandleGetCallback(CallbackParameterContainer instructionSet)
        {
            switch (instructionSet.ActionRequested)
            {
                //case "GetFaults":
                //    GetFaults(instructionSet);
                //    break;
            }
        }
        //

        private void AddRental(CallbackParameterContainer instructionSet)
        {
            var client = new FirstForRentalsService();
            var collection = RentalCollection.ReturnObject(instructionSet.Parameters[0]);

            var rentailId = client.InsertRental("1",collection.RentalId,collection.StartDate,collection.EndDate,collection.StartDestination,collection.EndDestination);

            var status = client.InsertPayment(rentailId, collection.RentalDate, collection.StartDestination, collection.EndDestination, collection.RentalAmount,
                                collection.InsuranceAmount,collection.ExtrasAmount,collection.VatAmount,collection.TotalAmount,
                                collection.DepositAmount,collection.DepositStatus,collection.PaymentStatus);
            
            if(status){
                returnObject = new CallbackReturnContainer("VehicleRentalAdded");
            }
            
        }
    }
}