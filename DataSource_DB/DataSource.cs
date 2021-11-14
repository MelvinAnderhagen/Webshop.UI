using ModelDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource_DB
{
    public class DataSource : IDataSource
    {
        public List<CustomersDTO> GetPath()
        {
            var Path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\DataSource_JSON.json";
            var Customers = JsonConvert.DeserializeObject<List<CustomersDTO>>(Path);
            return Customers;
        }
    }
}
