using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSource_DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;

namespace Webshop.UI.Pages.Products
{
    public class ProductsModel : PageModel
    {
        private readonly IDataSource _datasource;
        public ProductsModel(IDataSource datasource)
        {
            _datasource = datasource;
        }
        [BindProperty]
        public int Id { get; set; }
        public List<ProductsDTO> Products { get; set; }
        public void OnGet()
        {
            Products = _datasource.GetAllProducts().ToList();
        }
        public IActionResult OnPostAdd()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/ShoppingCart/ShoppingCart", "Products", new { id = Id });
            }
            return Page();
        }
    }
}
