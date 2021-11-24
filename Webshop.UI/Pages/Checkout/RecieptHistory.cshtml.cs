using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;
using Webshop.UI.DataAccess;

namespace Webshop.UI.Pages.Checkout
{
    public class RecieptHistoryModel : PageModel
    {
        private readonly IDataAccess _dataaccess;

        public RecieptHistoryModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        public RecieptDTO Receipt { get; set; }
        public void OnGet(int id)
        {
            Receipt = _dataaccess.GetRecieptById(id);
        }
        
    }
}
