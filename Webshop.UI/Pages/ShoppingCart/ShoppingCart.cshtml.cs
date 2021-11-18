using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;

namespace Webshop.UI.Pages.ShoppingCart
{
    public class ShoppingCartModel : PageModel
    {
        public ProductsDTO Product { get; set; }
        public void OnGet()
        {
        }
    }
}
