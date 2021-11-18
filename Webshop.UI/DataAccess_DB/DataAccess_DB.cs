using DataSource_DB;
using ModelDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.UI.DataAccess
{
    public class DataAccess_DB : IDataAccess
    {
        private readonly IDataSource _dataSource;

        public DataAccess_DB(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        
        public CustomersDTO GetCustomerById(int id)
        {
            var users = _dataSource.GetAllCustomers().ToList();

            var user = users.Find(user => user.id == id);
            return user;
        }
        public ProductsDTO GetProductById(int id)
        {
            var products = _dataSource.GetAllProducts().ToList();

            var product = products.Find(product => product.Id == id);
            return product;
        }
        public bool UserNotFound(string email, string password)
        {
            var users = _dataSource.GetAllCustomers().ToList();
            var Found = false;

            foreach (var cust in users)
            {
                if (email == cust.Email && password == cust.Password)
                {
                    Found = true;
                }
            }
            return Found;
        }
        public void AddToCart(int id)
        {
            

            
        }
        public void EditItems(ProductsDTO product)
        {
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\DataSource_Products.json"; 
            var products = _dataSource.GetAllProducts().ToList();

            foreach (var item in products)
            {
                if (item.Id == product.Id) //If the items id matches with the user id the run the itiration
                {
                    var IndexOfUser = products.IndexOf(item); //Sparar index av item från users i en variabel.
                    products[IndexOfUser].Name = product.Name;
                    products[IndexOfUser].Price = product.Price;
                }
            }

            var serializedUsers = JsonConvert.SerializeObject(products);
            File.WriteAllText(path, serializedUsers);

        }
    }
}
