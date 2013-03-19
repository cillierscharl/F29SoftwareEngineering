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
    public class GraphCollectionContainer
    {
        [DataMember]
        List<string> Keys;

        [DataMember]
        List<List<string>> Values;

        public GraphCollectionContainer(List<string> keys, List<List<string>> values)
        {
            Keys = keys;
            Values = values;
        }

        public string ToJson()
        {
            MemoryStream ms;
            byte[] json;
            string jsonReturnString;

            using (ms = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(GraphCollectionContainer));
                ser.WriteObject(ms, this);
                json = ms.ToArray();
            }

            jsonReturnString = Encoding.UTF8.GetString(json, 0, json.Length);
            return jsonReturnString;
        }
    }
}
