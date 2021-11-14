using DataSource_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.UI.DataAccess
{
    public class DataAccess
    {
        private readonly IDataSource _dataSource;

        public DataAccess(IDataSource dataSource )
        {
            _dataSource = dataSource;
        }

        public void GetAllCust()
        {

        }
    }
}
