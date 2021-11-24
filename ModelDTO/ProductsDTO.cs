using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [JsonProperty("productname")]
        public string Name { get; set; }
        [JsonProperty("productid")]
        public int id { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
