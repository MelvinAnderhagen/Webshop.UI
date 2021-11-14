﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDTO
{
    public class CustomersDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("phonenumber")]
        public long TelNum { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
