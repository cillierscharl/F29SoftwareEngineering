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
    public class CallbackReturnContainer
    {
        [DataMember]
        public string ActionReturned;

        [DataMember]
        public List<string> Parameters;

        public CallbackReturnContainer(string actionReturned)
        {
            ActionReturned = actionReturned;
            Parameters = new List<string>();
        }

        public string ToJson()
        {
            MemoryStream ms;
            byte[] json;
            string jsonReturnString;

            using (ms = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CallbackReturnContainer));
                ser.WriteObject(ms, this);
                json = ms.ToArray();
            }

            jsonReturnString = Encoding.UTF8.GetString(json, 0, json.Length);
            return jsonReturnString;
        }
    }
}
