using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDTO
{
    public class ShoppingCartDTO
    {
        public List<ProductsDTO> CartItems { get; set; }
        [JsonProperty("cartid")]
        public int CartId { get; set; }
    }
}
