using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Data;
using FirstForRentals.Utilities;
using System.ServiceModel.Activation;

namespace FirstForRentals.WCF
{
    public class FirstForRentalsService : IFirstForRentalsService
    {
        public bool InsertCustomer(string provider, string name, string surname, string email)
        {
            try{
                var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
                var sp = new SqlCommand("sp_addCustomer @provider_uid, @name, @surname, @email");
                sp.Parameters.AddWithValue("@provider_uid",provider);
                sp.Parameters.AddWithValue("@name", name);
                sp.Parameters.AddWithValue("@surname", surname);
                sp.Parameters.AddWithValue("@email", email);
                
                
                sp.Connection = connection;
                connection.Open();

                sp.ExecuteNonQuery();

                connection.Close();

                return true;

            } catch(Exception ex) {
                return false;
            }
        }

        public string GetCustomers()
        {
            try
            {
                var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
                var dataSet = new DataSet();
                var dataAdapter = new SqlDataAdapter();
                var sp = new SqlCommand("sp_getAllCustomers");
                
                sp.Connection = connection;
                dataAdapter.SelectCommand = sp;

                connection.Open();

                dataAdapter.Fill(dataSet);

                connection.Close();

                var returnTable =  Utilities.TableTools.BuildHTMLTable(dataSet);

                return returnTable;

            }
            catch (Exception ex)
            {
                return "";
            }
        }


        public string GetCarsOverview()
        {
            var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
            var dataSet = new DataSet();
            var dataAdapter = new SqlDataAdapter();
            var sp = new SqlCommand("sp_getCarsOverview");
            
            sp.Connection = connection;
            dataAdapter.SelectCommand = sp;

            connection.Open();

            dataAdapter.Fill(dataSet);

            connection.Close();

            var returnJson = Utilities.CollectionHelper.ReturnCarCollectionOverview(dataSet);
            return returnJson;
        }

        public string GetCarFaultsOverview(int id)
        {
            try
            {
                var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
                var dataSet = new DataSet();
                var dataAdapter = new SqlDataAdapter();
                var sp = new SqlCommand("sp_getVehicleFaults @id");
                sp.Parameters.AddWithValue("@id", id);

                sp.Connection = connection;
                dataAdapter.SelectCommand = sp;

                connection.Open();

                dataAdapter.Fill(dataSet);

                connection.Close();

                var returnTable = Utilities.TableTools.BuildHTMLTable(dataSet);

                return returnTable;

            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string GetCarsByClass(string carClass)
        {
            var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
            var dataSet = new DataSet();
            var dataAdapter = new SqlDataAdapter();
            var sp = new SqlCommand("sp_getCarsByClass @class");

            sp.Parameters.AddWithValue("@class", carClass);

            sp.Connection = connection;
            dataAdapter.SelectCommand = sp;

            connection.Open();

            dataAdapter.Fill(dataSet);

            connection.Close();

            var returnJson = Utilities.CollectionHelper.ReturnCarClassCollection(dataSet);
            return returnJson;
        }


        public string InsertRental(string customer, string car,string startDate, string endDate,string startDestination,string endDestination)
        {
            var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
            var sp = new SqlCommand("sp_addRental @customer, @car, @s_date, @e_date, @s_destination, @e_destination");

            sp.Parameters.AddWithValue("@customer", customer);
            sp.Parameters.AddWithValue("@car", car);
            sp.Parameters.AddWithValue("@s_date", startDate);
            sp.Parameters.AddWithValue("@e_date", endDate);
            sp.Parameters.AddWithValue("@s_destination", startDestination);
            sp.Parameters.AddWithValue("@e_destination", endDestination);

            sp.Connection = connection;
            connection.Open();

            var rentailID = sp.ExecuteScalar();

            connection.Close();

            return rentailID.ToString();
        }

        public bool InsertPayment(string rental, string rentalDate, string startDestination, string endDestination, decimal rentalAmount, decimal insuranceAmount,
                            decimal extrasAmount, decimal vatAmount, decimal totalAmount, decimal depositAmount,
                            string depositStatus, string paymentStatus)
        {
            try
            {
                var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
                var sp = new SqlCommand(@"sp_addPayment @rental, @rental_date, @rental_amount,
                                                        @insurance_amount, @extras_amount, @vat_amount, 
                                                        @total_amount,@deposit_amount,@deposit_status,
                                                        @payment_status");

                sp.Parameters.AddWithValue("@rental", rental);
                sp.Parameters.AddWithValue("@rental_date", rentalDate);
                sp.Parameters.AddWithValue("@rental_amount", rentalAmount);
                sp.Parameters.AddWithValue("@insurance_amount", insuranceAmount);
                sp.Parameters.AddWithValue("@extras_amount", extrasAmount);
                sp.Parameters.AddWithValue("@vat_amount", vatAmount);
                sp.Parameters.AddWithValue("@total_amount", totalAmount);
                sp.Parameters.AddWithValue("@deposit_amount", depositAmount);
                sp.Parameters.AddWithValue("@deposit_status", depositStatus);
                sp.Parameters.AddWithValue("@payment_status", paymentStatus);


                sp.Connection = connection;
                connection.Open();

                sp.ExecuteNonQuery();

                connection.Close();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertVehicleFault(int car, DateTime faultDate, string faultDetail, decimal faultAmount, bool serviceSuspension, bool insuranceClaim, string insuranceStatus)
        {
            try
            {
                var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
                var sp = new SqlCommand("sp_addVehicleFault @car, @fault_date, @fault_detail, @fault_amount, @fault_service_suspension, @fault_insurance_claim, @fault_insurance_claim_status");

                sp.Parameters.AddWithValue("@car", car);
                sp.Parameters.AddWithValue("@fault_date", faultDate);
                sp.Parameters.AddWithValue("@fault_detail", faultDetail);
                sp.Parameters.AddWithValue("@fault_amount",faultAmount);
                sp.Parameters.AddWithValue("@fault_service_suspension", serviceSuspension);
                sp.Parameters.AddWithValue("@fault_insurance_claim", insuranceClaim);
                sp.Parameters.AddWithValue("@fault_insurance_claim_status", insuranceStatus);


                sp.Connection = connection;
                connection.Open();

                sp.ExecuteNonQuery();

                connection.Close();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string GetVehicleStatus(string id)
        {
            var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
            var dataSet = new DataSet();
            var dataAdapter = new SqlDataAdapter();
            var sp = new SqlCommand("sp_getVehicleStatus @ID");

            sp.Parameters.AddWithValue("@ID", id);

            sp.Connection = connection;
            dataAdapter.SelectCommand = sp;

            connection.Open();

            dataAdapter.Fill(dataSet);

            connection.Close();

            var returnJson = Utilities.CollectionHelper.ReturnCarStatus(dataSet);
            return returnJson;
        }

        public string GetSeasonalVariationGraph()
        {
            var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
            var dataSet = new DataSet();
            var dataAdapter = new SqlDataAdapter();
            var sp = new SqlCommand("sp_getSeasonalVariation");

            sp.Connection = connection;
            dataAdapter.SelectCommand = sp;

            connection.Open();

            dataAdapter.Fill(dataSet);

            connection.Close();

            var returnJson = Utilities.CollectionHelper.ReturnGraphData(dataSet);
            return returnJson;
        }

        public string GetVehiclePopularityGraph()
        {
            var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
            var dataSet = new DataSet();
            var dataAdapter = new SqlDataAdapter();
            var sp = new SqlCommand("sp_getVehiclePopularity");

            sp.Connection = connection;
            dataAdapter.SelectCommand = sp;

            connection.Open();

            dataAdapter.Fill(dataSet);

            connection.Close();

            var returnJson = Utilities.CollectionHelper.ReturnGraphData(dataSet);
            return returnJson;
        }

        
        public string GetIncomeTrendGraph()
        {
            var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
            var dataSet = new DataSet();
            var dataAdapter = new SqlDataAdapter();
            var sp = new SqlCommand("sp_getIncomeTrend");

            sp.Connection = connection;
            dataAdapter.SelectCommand = sp;

            connection.Open();

            dataAdapter.Fill(dataSet);

            connection.Close();

            var returnJson = Utilities.CollectionHelper.ReturnGraphData(dataSet);
            return returnJson;
        }

        public string GetUserAuthorization(string uid,string name,string surname,string email)
        {
            try
            {

                var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
                var sp = new SqlCommand("sp_authenticateUser @provider_uid, @name, @surname, @email");


                sp.Parameters.AddWithValue("@provider_uid", uid);
                sp.Parameters.AddWithValue("@name", name);
                sp.Parameters.AddWithValue("@surname", surname);
                sp.Parameters.AddWithValue("@email", email);

                sp.Connection = connection;
                connection.Open();

                var userType = sp.ExecuteScalar();

                connection.Close();

                return userType.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        public string GetRentals()
        {
            try
            {
                var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
                var dataSet = new DataSet();
                var dataAdapter = new SqlDataAdapter();
                var sp = new SqlCommand("sp_getRentals");

                sp.Connection = connection;
                dataAdapter.SelectCommand = sp;

                connection.Open();

                dataAdapter.Fill(dataSet);

                connection.Close();

                var returnTable = Utilities.TableTools.BuildHTMLTable(dataSet);

                return returnTable;

            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string GetPayments()
        {
            try
            {
                var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
                var dataSet = new DataSet();
                var dataAdapter = new SqlDataAdapter();
                var sp = new SqlCommand("sp_getPayments");

                sp.Connection = connection;
                dataAdapter.SelectCommand = sp;

                connection.Open();

                dataAdapter.Fill(dataSet);

                connection.Close();

                var returnTable = Utilities.TableTools.BuildHTMLTable(dataSet);

                return returnTable;

            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string GetRentalAlerts(){
            try
            {
                var connection = new SqlConnection(RoleEnvironment.GetConfigurationSettingValue("SQLConnectionString"));
                var dataSet = new DataSet();
                var dataAdapter = new SqlDataAdapter();
                var sp = new SqlCommand("sp_getAlerts");

                sp.Connection = connection;
                dataAdapter.SelectCommand = sp;

                connection.Open();

                dataAdapter.Fill(dataSet);

                connection.Close();

                var returnTable = Utilities.TableTools.BuildHTMLTable(dataSet);

                return returnTable;

            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
