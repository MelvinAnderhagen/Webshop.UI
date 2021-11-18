using ModelDTO;
using System.Collections.Generic;

namespace Webshop.UI.DataAccess
{
    public interface IDataAccess
    {
        IEnumerable<CustomersDTO> GetAllCustomers();
        IEnumerable<ProductsDTO> GetAllProducts();
        bool UserNotFound(string email, string password);
        CustomersDTO GetCustomerById(int id);
        ProductsDTO GetProductById(int id);
        void CreateCart(int id);
        void EditItems(ProductsDTO product);
    }
}