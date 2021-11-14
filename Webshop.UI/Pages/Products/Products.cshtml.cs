using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;

namespace Webshop.UI.Pages.Products
{
    public class ProductsModel : PageModel
    {
        [BindProperty]
        public ProductsDTO Products { get; set; }
        public void OnGet()
        {
        }
    }
}
