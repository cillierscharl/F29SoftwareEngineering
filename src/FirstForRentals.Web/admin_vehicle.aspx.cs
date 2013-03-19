using FirstForRentals.Entities;
using System;
using System.Globalization;
using System.Web.UI;

namespace FirstForRentals.Web
{
    public partial class admin_vehicle : System.Web.UI.Page , ICallbackEventHandler
    {
        private CallbackReturnContainer returnObject;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Hookup Client Side Event Handlers
                ClientScriptManager cm = Page.ClientScript;
                String cbReference = cm.GetCallbackEventReference(this, "arg","ReceiveServerData", "");
                String callbackScript = "function CallServer(arg, context) {" + cbReference + "; }";
                cm.RegisterClientScriptBlock(this.GetType(),"CallServer", callbackScript, true);
                //

                var client = new FirstForRentalsService();
                var overviewResponse = client.GetCarsOverview();

                ClientScript.RegisterClientScriptBlock(this.GetType(), "carOverviewKey", "var carOverview = " + overviewResponse, true);

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
            switch (instructionSet.ActionRequested) {
                case "AddFault" :
                    AddFault(instructionSet);
                    break;
            }
        }

        private void HandleGetCallback(CallbackParameterContainer instructionSet)
        {
            switch (instructionSet.ActionRequested)
            {
                case "GetFaults":
                    GetFaults(instructionSet);
                    break;
                case "GetVehicleStatus":
                    GetVehicleStatus(instructionSet);
                    break;
                case "GetVehicleAlerts":
                    GetVehicleAlerts();
                    break;
            }
        }
        //

        void GetVehicleAlerts()
        {
            var client = new FirstForRentalsService();
            var resultString = client.GetRentalAlerts();

            returnObject = new CallbackReturnContainer("ReturnVehicleAlerts");
            returnObject.Parameters.Add(resultString);
        }

        void GetFaults(CallbackParameterContainer instructionSet)
        {
            var client = new FirstForRentalsService();
            var resultString = client.GetCarFaultsOverview(int.Parse(instructionSet.Parameters[0].ToString()));

            returnObject = new CallbackReturnContainer("ReturnVehicleFaults");
            returnObject.Parameters.Add(resultString);
        }

        void GetVehicleStatus(CallbackParameterContainer instructionSet)
        {
            var client = new FirstForRentalsService();
            var resultString = client.GetVehicleStatus(instructionSet.Parameters[0].ToString());

            returnObject = new CallbackReturnContainer("VehicleStatus");
            returnObject.Parameters.Add(resultString);
        }

        void AddFault(CallbackParameterContainer instructionSet)
        {

            int car;
            if(Int32.TryParse(instructionSet.Parameters[0].ToString(),out car))
            {

            }

            DateTime faultDate;
            if(DateTime.TryParse(instructionSet.Parameters[1].ToString(),out faultDate))
            {

            }

            string faultDetail = instructionSet.Parameters[2];

            decimal faultAmount = decimal.Parse(instructionSet.Parameters[3].ToString(),CultureInfo.InvariantCulture);

            bool faultServiceSuspension;
            bool.TryParse(instructionSet.Parameters[4].ToString(), out faultServiceSuspension);

            bool faultInsuranceClaim;
            bool.TryParse(instructionSet.Parameters[5].ToString(), out faultInsuranceClaim);

            string faultInsuranceClaimStatus;
            if(faultInsuranceClaim == true)
            {
                faultInsuranceClaimStatus = "Submitted";
            }else {
                faultInsuranceClaimStatus = "";
            }

            var client = new FirstForRentalsService();
            var response = client.InsertVehicleFault(car,faultDate,faultDetail,faultAmount,faultServiceSuspension,faultInsuranceClaim,faultInsuranceClaimStatus);

            if (response)
            {
                returnObject = new CallbackReturnContainer("VehicleFaultAdded");
            }
            else
            {

            }
        }



    }
}