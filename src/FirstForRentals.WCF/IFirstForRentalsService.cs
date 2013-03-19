using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace FirstForRentals.WCF
{
    public interface IFirstForRentalsService
    {
        [OperationContract]
        bool InsertCustomer(string provider,string name, string surname, string email);

        [OperationContract]
        string GetCustomers();

        [OperationContract]
        string GetCarsOverview();

        [OperationContract]
        string GetCarFaultsOverview(int id);

        [OperationContract]
        string GetCarsByClass(string carClass);

        [OperationContract]
        bool InsertVehicleFault(int car, DateTime faultDate, string faultDetail, decimal faultAmount, 
                                bool serviceSuspension, bool insuranceClaim, string insuranceStatus);

        [OperationContract]
        bool InsertPayment(  string rental,string rentalDate, string startDestination, string endDestination, decimal rentalAmount, decimal insuranceAmount, 
                            decimal extrasAmount, decimal vatAmount, decimal totalAmount, decimal depositAmount, 
                            string depositStatus,string paymentStatus);

        [OperationContract]
        string InsertRental(string customer, string car,string startDate, string endDate,string startDestination,string endDestination);

        [OperationContract]
        string GetVehicleStatus(string id);

        [OperationContract]
        string GetSeasonalVariationGraph();

        [OperationContract]
        string GetVehiclePopularityGraph();

        [OperationContract]
        string GetIncomeTrendGraph();

        [OperationContract]
        string GetUserAuthorization(string uid, string name, string surname, string email);

        [OperationContract]
        string GetRentals();

        [OperationContract]
        string GetPayments();

        [OperationContract]
        string GetRentalAlerts();


    }
}

