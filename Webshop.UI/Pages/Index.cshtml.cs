using DataSource_DB;
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
        private readonly IDataSource _datasource;

        [BindProperty]
        [JsonProperty("productid")]
        public int Id { get; set; }
        [BindProperty]
        public List<ProductsDTO> Products { get; set; }
        [BindProperty]
        public ProductsDTO Product { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IDataSource datasource, IDataAccess dataaccess)
        {
            _logger = logger;
            _dataaccess = dataaccess;
            _datasource = datasource;
        }

        public void OnGet()
        {
            Products = _datasource.GetAllProducts().ToList();
        }

        public void OnPostAddToCart()
        {
            if (ModelState.IsValid)
            {
                _dataaccess.GetProductById(Id);
            }
            
        }

    }
}
