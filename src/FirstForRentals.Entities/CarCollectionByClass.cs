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
    public class CarCollectionByClass
    {
        [DataMember]
        List<Car> carCollection;

        public CarCollectionByClass()
        {
            carCollection = new List<Car>();
        }

        public void AddCar(string id,string make, string model, string costPerDay, string insurancePerDay, string available)
        {
            var newCar = new Car(id,make,model,costPerDay,insurancePerDay,available);
            carCollection.Add(newCar);
        }

        public string ToJson()
        {
            MemoryStream ms;
            byte[] json;
            string jsonReturnString;

            using (ms = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CarCollectionByClass));
                ser.WriteObject(ms, this);
                json = ms.ToArray();
            }

            jsonReturnString = Encoding.UTF8.GetString(json, 0, json.Length);
            return jsonReturnString;
        }
    }

    [DataContract]
    public class Car
    {
        [DataMember]
        public string Id;

        [DataMember]
        public string Make;

        [DataMember]
        public string Model;

        [DataMember]
        public string CostPerDay;

        [DataMember]
        public string InsurancePerDay;

        [DataMember]
        public string Available;

        public Car(string id, string make, string model,string costPerDay, string insurancePerday , string available)
        {
            Id = id;
            Make = make;
            Model = model;
            CostPerDay = costPerDay;
            InsurancePerDay = insurancePerday;
            Available = available;
        }
    }
}
