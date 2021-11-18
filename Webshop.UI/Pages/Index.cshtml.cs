using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ModelDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.UI.DataAccess;

namespace Webshop.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDataAccess _dataaccess;

        [BindProperty]
        public List<ProductsDTO> Products { get; set; }
       
        public IndexModel(ILogger<IndexModel> logger, IDataAccess dataaccess)
        {
            _logger = logger;
            _dataaccess = dataaccess;
        }

        public void OnGet()
        {
            Products = _dataaccess.GetAllProducts().ToList();
        }

        
    }
}
