using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSource_DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;
using Newtonsoft.Json;

namespace Webshop.UI.Pages.EditProducts
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
        [BindProperty]
        public List<ProductsDTO> Prods { get; set; }
        public void OnGet()
        {
            Prods = _datasource.GetAllProducts().ToList();
        }

        public IActionResult OnPostEdit()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/EditProducts/EditProduct", "Products", new { id = Id });
            }
            return Page();
        }
    }
}
