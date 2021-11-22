using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDTO
{
    public class OrderDTO
    {
        [JsonProperty("items")]
        public List<ProductsDTO> Items { get; set; }
        [JsonProperty("cost")]
        public int Price { get; set; }
        [JsonProperty("ispaid")]
        public bool isPaid { get; set; }
        [JsonProperty("recieptid")]
        public int RecieptId { get; set; }
    }
}
