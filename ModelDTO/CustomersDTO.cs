using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDTO
{
    public class CustomersDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [EmailAddress]
        [JsonProperty("email")]
        [Required]
        public string Email { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        //[JsonProperty("CCN")]
        //public int CreditCardNumber { get; set; }
    }
}
