using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    public class CreditCard
    {
        [Required]
        [JsonProperty("ccn")]
        public string CreditCardNumber { get; set; }
        [Required]
        [JsonProperty("securitycode")]
        public int SecurityCode { get; set; }
    }
}
