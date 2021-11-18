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
        public IEnumerable<ShoppingCartDTO> GetAllCarts()
        {
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\ShoppingCart_DB.json";
            var jsonRead = File.ReadAllText(path);
            var jsonResponse = JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(jsonRead);

            return jsonResponse;
        }
        public IEnumerable<CustomersDTO> GetAllCustomers()
        {
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\DataSource_JSON.json";
            var jsonResponse = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<IEnumerable<CustomersDTO>>(jsonResponse);
        }

        public IEnumerable<ProductsDTO> GetAllProducts()
        {
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\DataSource_Products.json";
            var jsonResponse = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<IEnumerable<ProductsDTO>>(jsonResponse);
        }

        public CustomersDTO GetCustomerById(int id)
        {
            var users = GetAllCustomers().ToList();

            var user = users.Find(user => user.id == id);
            return user;
        }
        public ProductsDTO GetProductById(int id)
        {
            var products = GetAllProducts().ToList();

            var product = products.Find(product => product.Id == id);
            return product;
        }
        public bool UserNotFound(string email, string password)
        {
            var users = GetAllCustomers().ToList();
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
        public ShoppingCartDTO CreateCart(int id)
        {
            var CurrentCart = GetAllCarts().ToList();

            ShoppingCartDTO Cart = new ShoppingCartDTO();
            Cart.CartId = id;

            CurrentCart.Add(Cart);

            var serializeobject = JsonConvert.SerializeObject(CurrentCart);
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\ShoppingCart_DB.json";
            File.WriteAllText(path, serializeobject);

            return Cart;
        }
        


        public void EditItems(ProductsDTO product)
        {
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\DataSource_Products.json"; 
            var products = GetAllProducts().ToList();

            foreach (var item in products)
            {
                if (item.Id == product.Id) //If the items id matches with the user id the run the itiration
                {
                    var IndexOfUser = products.IndexOf(item); //Sparar index av item från users i en variabel.
                    products[IndexOfUser].Name = product.Name;
                    products[IndexOfUser].Price = product.Price;
                    products[IndexOfUser].Message = product.Message;
                }
            }

            var serializedUsers = JsonConvert.SerializeObject(products);
            File.WriteAllText(path, serializedUsers);

        }
    }
}
