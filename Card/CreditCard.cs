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
        
        [JsonProperty("money")]
        public int Money { get; set; }
    }
}
