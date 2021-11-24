using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDTO
{
    public class RecieptDTO
    {
        [JsonProperty("items")]
        public List<ProductsDTO> Items { get; set; }
        [JsonProperty("ispaid")]
        public bool isPaid { get; set; }
        [JsonProperty("recieptid")]
        public Guid RecieptId { get; set; }
        [JsonProperty("uid")]
        public int UserId { get; set; }
    }
}
