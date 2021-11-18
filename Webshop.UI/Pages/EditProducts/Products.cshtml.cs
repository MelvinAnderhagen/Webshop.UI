using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;
using Newtonsoft.Json;
using Webshop.UI.DataAccess;

namespace Webshop.UI.Pages.EditProducts
{
    public class ProductsModel : PageModel
    {
        private readonly IDataAccess _dataaccess;
        public ProductsModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public List<ProductsDTO> Prods { get; set; }
        public void OnGet()
        {
            Prods = _dataaccess.GetAllProducts().ToList();
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
