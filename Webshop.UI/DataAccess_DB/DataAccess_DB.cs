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

            var user = users.Find(user => user.Id == id);
            return user;
        }
        public ProductsDTO GetProductById(int id)
        {
            var products = _dataSource.GetAllProducts().ToList();

            var product = products.Find(user => user.Id == id);
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
    }
}
