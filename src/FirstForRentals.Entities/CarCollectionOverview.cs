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
    public class CarCollectionOverview
    {
        [DataMember]
        List<CarCollection> CarCategoryCollection;

        public CarCollectionOverview()
        {
            CarCategoryCollection = new List<CarCollection>();
        }

        public void AddCategory(CarCollection category)
        {
            CarCategoryCollection.Add(category);
        }

        public CarCollection FindCollectionByName(string name)
        {
            foreach (CarCollection collection in CarCategoryCollection)
            {
                if (collection.CategoryName == name)
                {
                    return collection;
                }
            }
            return null;
        }

        public string ToJson()
        {
            MemoryStream ms;
            byte[] json;
            string jsonReturnString;

            using (ms = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CarCollectionOverview));
                ser.WriteObject(ms, this);
                json = ms.ToArray();
            }

            jsonReturnString = Encoding.UTF8.GetString(json, 0, json.Length);
            return jsonReturnString;
        }
    }

    [DataContract]
    public class CarCollection
    {
        [DataMember]
        public string CategoryName;

        [DataMember]
        public List<CarDetail> categoryCarCollection;

        public CarCollection(string categoryName)
        {
            CategoryName = categoryName;
            categoryCarCollection = new List<CarDetail>();
        }

        public void AddCar(string id, string car_class, string registration, string mileage, string year, string service_start_date, string service_end_date, string service_status, string rental_status, string make, string model)
        {
            var newCar = new CarDetail(id,car_class, registration, mileage, year, service_start_date, service_end_date, service_status, rental_status, make, model);
            categoryCarCollection.Add(newCar);
        }

        public void AddCar(CarDetail car)
        {
            categoryCarCollection.Add(car);
        }
    }

    [DataContract]
    public class CarDetail
    {
        [DataMember(Order = 0)]
        public string Id;

        [DataMember (Order=1)]
        public string Class;

        [DataMember(Order = 2)]
        public string Registration;

        [DataMember(Order = 3)]
        public string Mileage;

        [DataMember(Order = 4)]
        public string Year;

        [DataMember(Order = 5)]
        public string Service_Start_Date;

        [DataMember(Order = 6)]
        public string Service_End_Date;

        [DataMember(Order = 7)]
        public string Service_Status;

        [DataMember(Order = 8)]
        public string Rental_Status;

        [DataMember(Order = 9)]
        public string Make;

        [DataMember(Order = 10)]
        public string Model;

        public CarDetail(string id,string car_class, string registration, string mileage, string year, string service_start_date, string service_end_date, string service_status, string rental_status, string make, string model)
        {
            Id = id;
            Class = car_class;
            Registration = registration;
            Mileage = mileage;
            Year = year;
            Service_Start_Date = service_start_date;
            Service_End_Date = service_end_date;
            Service_Status = service_status;
            Rental_Status = rental_status;
            Make = make;
            Model = model;
        }

        public string ToJson()
        {
            MemoryStream ms;
            byte[] json;
            string jsonReturnString;

            using (ms = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CarDetail));
                ser.WriteObject(ms, this);
                json = ms.ToArray();
            }

            jsonReturnString = Encoding.UTF8.GetString(json, 0, json.Length);
            return jsonReturnString;
        }
    }
}
