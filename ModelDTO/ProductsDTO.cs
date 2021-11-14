using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDTO
{
    public class ProductsDTO
    {
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
