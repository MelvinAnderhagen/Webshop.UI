using ModelDTO;
using System.Collections.Generic;

namespace DataSource_DB
{
    public interface IDataSource
    {
        IEnumerable<CustomersDTO> GetAllCustomers();
        IEnumerable<ProductsDTO> GetAllProducts();
        IEnumerable<ProductsDTO> GetAllCartItems();
    }
}