using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSource_DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;
using Webshop.UI.DataAccess;

namespace Webshop.UI.Pages.Products
{
    public class ProductsModel : PageModel
    {
        private readonly IDataAccess _dataaccess;
        private readonly IDataSource _datasource;
        public ProductsModel(IDataSource datasource, IDataAccess dataAccess)
        {
            _datasource = datasource;
            _dataaccess = dataAccess;
        }
        [BindProperty]
        public int Id { get; set; }
        public List<ProductsDTO> Products { get; set; }
        public void OnGet()
        {
            Products = _datasource.GetAllProducts().ToList();
        }
        public IActionResult OnPostAddToCart()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("ShoppingCart/ShoppingCart", "ShoppingCart", new { id = Id });
            }
            return Page();
        }
    }
}
