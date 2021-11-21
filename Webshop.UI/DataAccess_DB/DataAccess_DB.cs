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
            return JsonConvert.DeserializeObject<IEnumerable<ShoppingCartDTO>>(jsonRead);
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
            var user = users.Find(user => user.Id == id);
            return user;
        }
        public ShoppingCartDTO GetCartById(int id)
        {
            var carts = GetAllCarts().ToList();
            var findcart = carts.Find(cart => cart.CartId == id);
            return findcart;
        }
        public ProductsDTO GetProductById(int id)
        {
            var products = GetAllProducts().ToList();
            var product = products.Single(product => product.id == id);
            return product;
        }
        public void RegisterCustomer(CustomersDTO customer)
        {
            var result = GetAllCustomers().ToList();
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\DataSource_JSON.json";
            List<CustomersDTO> customers = new List<CustomersDTO>();
            foreach (var item in result)
            {
                customers.Add(new CustomersDTO { Email = item.Email, Name = item.Name, Password = item.Password, Id = item.Id });
            }

            customers.Add(new CustomersDTO { Email = customer.Email, Name = customer.Name, Password = customer.Password, Id = customer.Id});

            var serizalize = JsonConvert.SerializeObject(customers);

            File.WriteAllText(path, serizalize);
        }
        public CustomersDTO LoginForms(string email, string password)
        {
            var users = GetAllCustomers().ToList();
            foreach (var item in users)
            {
                if (password == item.Password && email == item.Email)
                {
                    return item;
                }
            }
            return null;
        }
        public void AddToCart(ProductsDTO product , int id)
        {
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\ShoppingCart_DB.json";
            var jsonRead = File.ReadAllText(path);
            var status = JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(jsonRead);

            var shoppingcart = GetCartById(id);
            var indexofcart = status.IndexOf(shoppingcart);

            List<ProductsDTO> products = new List<ProductsDTO>();

            foreach (var item in status[indexofcart].CartItems)
            {
                products.Add(new ProductsDTO { id = item.id, Name = item.Name, Price = item.Price, Image = product.Image });
            }

            products.Add(new ProductsDTO { id = product.id, Name = product.Name, Price = product.Price, Image = product.Image });

            status[indexofcart].CartItems = products;
            var serialized = JsonConvert.SerializeObject(status);
            File.WriteAllText(path, serialized);
        }

        public ShoppingCartDTO CreateCart(int id)
        {
            var CurrentCart = GetAllCarts().ToList(); //Sends in list of type ShoppingCart and saves it in a variable
            ShoppingCartDTO Cart = new ShoppingCartDTO(); //Makes a new ShoppingCart object
            Cart.CartId = id; //Assigns the same Id to the cart as the customer
            CurrentCart.Add(Cart); //Adds a new cart to the list
            var serializeobject = JsonConvert.SerializeObject(CurrentCart);
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\ShoppingCart_DB.json";
            File.WriteAllText(path, serializeobject);
            return Cart;
        }
        public ShoppingCartDTO GetShoppingCart(int id)
        {
            var CurrentCart = GetAllCarts().ToList(); //Gets a list of type shoppingcartDTO 
            var ShoppingCart = CurrentCart.Find(cart => cart.CartId == id); //Takes that list and finds cart id
            return ShoppingCart; //Returns id
        }
        
        public void ClearCartById(int id)
        {
            var status = GetAllCarts().ToList(); //Injecting list of type shoppingcart
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\ShoppingCart_DB.json";

            var cart = status.Find(cart => cart.CartId == id); //Finding exact item using Id
            var update = status.IndexOf(cart); //Making a variable with the index of that Id
            status[update].CartItems = null; //Making that value become null. 
            var serialized = JsonConvert.SerializeObject(status); 
            File.WriteAllText(path, serialized); //Overwriting all for that specific object by using Id and file path.
        }
        public void EditItems(ProductsDTO product)
        {
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\DataSource_Products.json"; 
            var products = GetAllProducts().ToList();

            foreach (var item in products)
            {
                if (item.id == product.id) //If the items id matches with the user id the run the itiration
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
        public void EditCustomer(CustomersDTO customer)
        {
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\DataSource_JSON.json";
            var customers = GetAllCustomers().ToList();

            foreach (var item in customers)
            {
                if (item.Id == customer.Id) //If the items id matches with the user id the run the itiration
                {
                    var IndexOfUser = customers.IndexOf(item); //Sparar index av item från users i en variabel.
                    customers[IndexOfUser].Name = customer.Name;
                    customers[IndexOfUser].Email = customer.Email;
                    customers[IndexOfUser].Password = customer.Password;
                    customers[IndexOfUser].Id = customer.Id;
                }
            }

            var serializedUsers = JsonConvert.SerializeObject(customers);
            File.WriteAllText(path, serializedUsers);

        }
    }
}
