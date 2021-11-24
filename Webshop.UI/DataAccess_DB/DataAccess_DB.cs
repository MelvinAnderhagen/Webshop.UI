using Card;
using ModelDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Webshop.UI.DataAccess
{
    public class DataAccess_DB : IDataAccess
    {
        public RecieptDTO GetRecieptById(int id)
        {
            var reciept = GetAllReciepts().ToList();
            
            foreach (var item in reciept.FindAll(x => x.UserId == id))
            {
                return item;
            }
            
            return null;
        }
        public void SaveRecipt(int id)
        {
            var path1 = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\DataSource_Reciept.json";
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\ShoppingCart_DB.json";
            var jsonRead1 = File.ReadAllText(path);
            var jsonRead = File.ReadAllText(path1);
            var reciepts = JsonConvert.DeserializeObject<List<RecieptDTO>>(jsonRead);
            var carts = JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(jsonRead1);

            var shoppingcart = carts.Single(cart => cart.CartId == id);
            
            RecieptDTO reciept = new RecieptDTO();
            reciept.RecieptId = Guid.NewGuid();
            reciept.UserId = shoppingcart.CartId;
            reciept.Items = shoppingcart.CartItems;
            reciepts.Add(reciept);
            reciept.isPaid = true;
            

            var serialize = JsonConvert.SerializeObject(reciepts);
            File.WriteAllText(path1, serialize);
        }
        public bool CardForms(string ccn, int sc)
        {
            var cards = GetAllCards().ToList();
            foreach (var card in cards)
            {
                if (ccn == card.CreditCardNumber && sc == card.SecurityCode)
                {
                    return true;
                }
            }
            return false;
        }
        public IEnumerable<RecieptDTO> GetAllReciepts()
        {
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\DataSource_Reciept.json";
            var jsonRead = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<IEnumerable<RecieptDTO>>(jsonRead);
        }
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
            var user = users.Single(user => user.Id == id);
            return user;
        }
        public ShoppingCartDTO GetCartById(int id)
        {
            var carts = GetAllCarts().ToList();
            var findcart = carts.Single(cart => cart.CartId == id);
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
            var users = GetAllCustomers().ToList(); //Inputs customer list in users
            foreach (var item in users) //foreach item in users (goes through the list of customers)
            {
                if (password == item.Password && email == item.Email) //If password and email matches with customer json
                {
                    return item; //return item
                }
            }
            return null; //otherwise return null
        }
        public void AddToCart(ProductsDTO product, int id)
        {
            
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\ShoppingCart_DB.json";
            var jsonRead = File.ReadAllText(path);
            var carts = JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(jsonRead);
            var shoppingcart = carts.Single(cart => cart.CartId == id);
            var indexofcart = carts.IndexOf(shoppingcart);

            List<ProductsDTO> products = new List<ProductsDTO>();
            if (carts[indexofcart].CartItems != null)
            {
                foreach (var item in carts[indexofcart].CartItems)
                {
                    products.Add(new ProductsDTO { id = item.id, Name = item.Name, Price = item.Price, Image = item.Image });
                }
            }
            
            products.Add(new ProductsDTO { id = product.id, Name = product.Name, Price = product.Price, Image = product.Image });

            carts[indexofcart].CartItems = products;
            var serialized = JsonConvert.SerializeObject(carts);
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
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\ShoppingCart_DB.json";
            var jsonRead = File.ReadAllText(path);
            var CurrentCart = JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(jsonRead);
            var ShoppingCart = CurrentCart.Single(cart => cart.CartId == id); //Takes that list and finds cart id

            return ShoppingCart; //Returns id
        }
        public void ClearCartById(int id)
        {
            var status = GetAllCarts().ToList(); //Saves Cartlist in variable named status
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\ShoppingCart_DB.json";

            var cart = status.Single(cart => cart.CartId == id); 
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
        public List<ProductsDTO> MinPrice()
        {
            var products = GetAllProducts().ToList();
            products.Sort((x, y) => x.Price.CompareTo(y.Price));
            return products;
        }
        public List<ProductsDTO> MaxPrice()
        {
            var products = GetAllProducts().ToList();
            products.Reverse();
            products.Sort();
            return products;
        }
        public IEnumerable<CreditCard> GetAllCards()
        {
            var path = @"C:\Users\melvi\Source\Repos\Webshop.UI\DataSource_DB\Card_DataSource.json";
            var jsonresponse = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<IEnumerable<CreditCard>>(jsonresponse);
        }

        
    }
}
