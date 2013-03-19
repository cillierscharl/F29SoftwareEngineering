using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace FirstForRentals.Web.Entities
{

    [DataContract]
    public class FirstForRentalsUser
    {
        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName;

        [DataMember]
        public string FullName;

        [DataMember]
        public string Email;

        [DataMember]
        public string Uid;

        [DataMember]
        public string Provider;

        [DataMember]
        public string GravatarUrl;

        [DataMember]
        public string UserType;

        public string ToJson()
        {
            MemoryStream ms;
            byte[] json;
            string jsonReturnString;

            using (ms = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(FirstForRentalsUser));
                ser.WriteObject(ms, this);
                json = ms.ToArray();
            }

            jsonReturnString = Encoding.UTF8.GetString(json, 0, json.Length);
            return jsonReturnString;
        }

        public static FirstForRentalsUser ToEntity(string stringUser)
        {
            MemoryStream ms;
            FirstForRentalsUser user;

            using (ms = new MemoryStream(Encoding.UTF8.GetBytes(stringUser)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(FirstForRentalsUser));
                user = ser.ReadObject(ms) as FirstForRentalsUser;
            }

            return user;
        }
    }
}