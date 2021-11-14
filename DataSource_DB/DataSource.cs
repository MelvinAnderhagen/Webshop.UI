using ModelDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource_DB
{
    public class DataSource : IDataSource
    {
        public IEnumerable<CustomersDTO> GetAllCustomers()
        {
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\DataSource_JSON.json";
            var jsonResponse = File.ReadAllText(path);
            var customers = JsonConvert.DeserializeObject<IEnumerable<CustomersDTO>>(jsonResponse);

            return customers;
        }
        public IEnumerable<ProductsDTO> GetAllProducts()
        {
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\DataSource_Products.json";
            var jsonResponse = File.ReadAllText(path);
            var products = JsonConvert.DeserializeObject<IEnumerable<ProductsDTO>>(jsonResponse);

            return products;
        }
    }
}
