using ModelDTO;
using System.Collections.Generic;

namespace DataSource_DB
{
    public interface IDataSource
    {
        IEnumerable<CustomersDTO> GetPath();
    }
}