using ModelDTO;

namespace Webshop.UI.DataAccess
{
    public interface IDataAccess
    {
        CustomersDTO GetCustomerById(int id);
        ProductsDTO GetProductById(int id);
    }
}