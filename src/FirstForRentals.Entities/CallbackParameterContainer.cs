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
    public class CallbackParameterContainer
    {
        [DataMember]
        public string ActionRequested;

        [DataMember]
        public string Operation;

        [DataMember]
        public List<string> Parameters;

        public static CallbackParameterContainer ReturnCallbackParameters(string parameterJson)
        {
            MemoryStream ms;
            CallbackParameterContainer parameterContainer;

            using (ms = new MemoryStream(Encoding.UTF8.GetBytes(parameterJson)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CallbackParameterContainer));
                parameterContainer = ser.ReadObject(ms) as CallbackParameterContainer;
            }

            return parameterContainer;
        }
    }
}
