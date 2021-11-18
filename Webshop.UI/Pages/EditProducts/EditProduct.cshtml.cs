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
    public class EditProductModel : PageModel
    {
        private readonly IDataAccess _dataaccess;

        public EditProductModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        [BindProperty]
        public ProductsDTO Product { get; set; }
        public void OnGet(int id)
        {
            Product = _dataaccess.GetProductById(id);
        }

        public IActionResult OnPostSave()
        {
            if (ModelState.IsValid)
            {
                _dataaccess.EditItems(Product);
                return RedirectToPage("/EditProducts/Products");
            }
            return Page();
        }
    }
}
