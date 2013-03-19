using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace FirstForRentals.Entities
{
    [DataContract]
    public class RentalCollection
    {
        [DataMember]
        public string RentalId;

        [DataMember]
        public string StartDate;

        [DataMember]
        public string EndDate;

        [DataMember]
        public string StartDestination;

        [DataMember]
        public string EndDestination;

        [DataMember]
        public string RentalDate;

        [DataMember]
        public decimal RentalAmount;

        [DataMember]
        public decimal InsuranceAmount;

        [DataMember]
        public decimal ExtrasAmount;

        [DataMember]
        public decimal VatAmount;

        [DataMember]
        public decimal TotalAmount;

        [DataMember]
        public decimal DepositAmount;

        [DataMember]
        public string DepositStatus;

        [DataMember]
        public string PaymentStatus;

        public RentalCollection(string rentalId,string startDate, string endDate, string startDestination, string endDestination,
                                string rentalDate, decimal rentalAmount, decimal insuranceAmount, decimal extrasAmount, decimal vatAmount,
                                decimal totalAmount, decimal depositAmount, string depositStatus, string paymentStatus)
        {
            RentalId = rentalId;
            StartDate = startDate;
            EndDate = endDate;
            StartDestination = startDestination;
            EndDestination = endDestination;
            RentalDate = rentalDate;
            RentalAmount = rentalAmount;
            InsuranceAmount = insuranceAmount;
            ExtrasAmount = extrasAmount;
            VatAmount = vatAmount;
            TotalAmount = totalAmount;
            DepositAmount = depositAmount;
            DepositStatus = depositStatus;
            PaymentStatus = paymentStatus;
        }

        public static RentalCollection ReturnObject(string jsonString)
        {
            MemoryStream ms;
            RentalCollection collection;

            using (ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RentalCollection));
                collection = ser.ReadObject(ms) as RentalCollection;
            }

            return collection;
        }

    }
}