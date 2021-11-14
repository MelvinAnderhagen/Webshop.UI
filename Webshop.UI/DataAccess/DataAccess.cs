using DataSource_DB;
using ModelDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.UI.DataAccess
{
    public class DataAccess
    {
        private readonly IDataSource _dataSource;

        public DataAccess(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public void GetAllCust()
        {
            _dataSource.GetPath();
        }
        public CustomersDTO GetById(int id)
        {
           var users = _dataSource.GetPath().ToList();

            var user = users.Find(user => user.Id == id);
            return user;
        }

    }
}
