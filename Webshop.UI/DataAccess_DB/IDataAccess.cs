using Card;
using ModelDTO;
using System.Collections.Generic;

namespace Webshop.UI.DataAccess
{
    public interface IDataAccess
    {
        
        List<ProductsDTO> MinPrice();
        List<ProductsDTO> MaxPrice();
        IEnumerable<ProductsDTO> Search(string searchTerm);
        void ClearCartById(int id);
        void SaveRecipt(int id);
        bool CardForms(int ccn);
        IEnumerable<CustomersDTO> GetAllCustomers();
        IEnumerable<ProductsDTO> GetAllProducts();
        CustomersDTO LoginForms(string email, string password);
        CustomersDTO GetCustomerById(int id);
        ProductsDTO GetProductById(int id);
        ShoppingCartDTO CreateCart(int id);
        void RegisterCustomer(CustomersDTO customer);
        void EditItems(ProductsDTO product);
        IEnumerable<ShoppingCartDTO> GetAllCarts();
        void AddToCart(ProductsDTO product, int id);
        ShoppingCartDTO GetCartById(int id);
        ShoppingCartDTO GetShoppingCart(int id);
        void EditCustomer(CustomersDTO customer);
    }
}