using ModelDTO;
using System.Collections.Generic;

namespace Webshop.UI.DataAccess
{
    public interface IDataAccess
    {
        bool UserNotFound(string email, string password);
        CustomersDTO GetCustomerById(int id);
        ProductsDTO GetProductById(int id);
        void AddToCart(int id);
        void EditItems(ProductsDTO product);
    }
}