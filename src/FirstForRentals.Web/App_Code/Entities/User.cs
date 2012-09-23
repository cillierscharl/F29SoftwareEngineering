<<<<<<< HEAD
﻿using System;
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
    public class User
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

        public string ToJson()
        {
            MemoryStream ms;
            byte[] json;
            string jsonReturnString;

            using (ms = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(User));
                ser.WriteObject(ms, this);
                json = ms.ToArray();
            }

            jsonReturnString = Encoding.UTF8.GetString(json, 0, json.Length);
            return jsonReturnString;
        }

        public static User ReturnUser(string stringUser)
        {
            MemoryStream ms;
            User user;

            using (ms = new MemoryStream(Encoding.UTF8.GetBytes(stringUser)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(User));
                user = ser.ReadObject(ms) as User;
            }

            return user;
        }
    }
=======
﻿using System;
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
    public class User
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

        public string ToJson()
        {
            MemoryStream ms;
            byte[] json;
            string jsonReturnString;

            using (ms = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(User));
                ser.WriteObject(ms, this);
                json = ms.ToArray();
            }

            jsonReturnString = Encoding.UTF8.GetString(json, 0, json.Length);
            return jsonReturnString;
        }

        public static User ReturnUser(string stringUser)
        {
            MemoryStream ms;
            User user;

            using (ms = new MemoryStream(Encoding.UTF8.GetBytes(stringUser)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(User));
                user = ser.ReadObject(ms) as User;
            }

            return user;
        }
    }
>>>>>>> origin/master
}