<<<<<<< HEAD
﻿using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace FirstForRentals.Web.WindowsLive_Auth
{
    [DataContract]
    public class WindowsLiveDetail
    {
        private static DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(WindowsLiveDetail));

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "link")]
        public Uri Link { get; set; }

        [DataMember(Name = "gender")]
        public string Gender { get; set; }

        [DataMember(Name = "emails")]
        public WindowsLiveEmailDetail Email { get; set; }

        [DataMember(Name = "updated_time")]
        public string UpdatedTime { get; set; }

        [DataMember(Name = "locale")]
        public string Locale { get; set; }

        public static WindowsLiveDetail Deserialize(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentNullException("json");
            }

            return Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(json)));
        }

        public static WindowsLiveDetail Deserialize(Stream jsonStream)
        {
            if (jsonStream == null)
            {
                throw new ArgumentNullException("jsonStream");
            }

            return (WindowsLiveDetail)jsonSerializer.ReadObject(jsonStream);
        }
    }

    [DataContract]
    public class WindowsLiveEmailDetail
    {
        [DataMember(Name = "preferred")]
        public string Preferred { get; set; }

        [DataMember(Name = "account")]
        public string Account { get; set; }

        [DataMember(Name = "personal")]
        public string Personal { get; set; }

        [DataMember(Name = "business")]
        public string Business { get; set; }

    }

    
=======
﻿using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace FirstForRentals.Web.WindowsLive_Auth
{
    [DataContract]
    public class WindowsLiveDetail
    {
        private static DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(WindowsLiveDetail));

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "link")]
        public Uri Link { get; set; }

        [DataMember(Name = "gender")]
        public string Gender { get; set; }

        [DataMember(Name = "emails")]
        public WindowsLiveEmailDetail Email { get; set; }

        [DataMember(Name = "updated_time")]
        public string UpdatedTime { get; set; }

        [DataMember(Name = "locale")]
        public string Locale { get; set; }

        public static WindowsLiveDetail Deserialize(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentNullException("json");
            }

            return Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(json)));
        }

        public static WindowsLiveDetail Deserialize(Stream jsonStream)
        {
            if (jsonStream == null)
            {
                throw new ArgumentNullException("jsonStream");
            }

            return (WindowsLiveDetail)jsonSerializer.ReadObject(jsonStream);
        }
    }

    [DataContract]
    public class WindowsLiveEmailDetail
    {
        [DataMember(Name = "preferred")]
        public string Preferred { get; set; }

        [DataMember(Name = "account")]
        public string Account { get; set; }

        [DataMember(Name = "personal")]
        public string Personal { get; set; }

        [DataMember(Name = "business")]
        public string Business { get; set; }

    }

    
>>>>>>> origin/master
}