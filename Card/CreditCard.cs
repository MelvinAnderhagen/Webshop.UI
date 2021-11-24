using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    public class CreditCard
    {
        [JsonProperty("ccn")]
        public string CreditCardNumber { get; set; }
        [JsonProperty("securitycode")]
        public int SecurityCode { get; set; }
    }
}
