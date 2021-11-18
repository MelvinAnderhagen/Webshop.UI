using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;
using Newtonsoft.Json;
using Webshop.UI.DataAccess;

namespace Webshop.UI.Pages.StorePage
{
    public class LoggedinIndexModel : PageModel
    {
        private readonly IDataAccess _dataaccess;

        [BindProperty]
        [JsonProperty("productid")]
        public int Id { get; set; }
        [BindProperty]
        public List<ProductsDTO> Products { get; set; }
        [BindProperty]
        public ProductsDTO Product { get; set; }
        public LoggedinIndexModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        public void OnGet()
        {
            Products = _dataaccess.GetAllProducts().ToList();
        }
        public void OnPostAddToCart()
        {
            if (ModelState.IsValid)
            {
                var id = _dataaccess.GetProductById(Id);
                JsonConvert.SerializeObject(id);
            }
        }
    }
}
