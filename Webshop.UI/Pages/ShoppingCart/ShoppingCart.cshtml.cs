using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;
using Webshop.UI.DataAccess;

namespace Webshop.UI.Pages.ShoppingCart
{
    public class ShoppingCartModel : PageModel
    {
        private readonly IDataAccess _dataaccess;

        public List<ProductsDTO> Cart { get; set; }
        public List<ProductsDTO> Products { get; set; }
        public ShoppingCartModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }

        public ProductsDTO Product { get; set; }
        public void OnGet(int id)
        { 
            _dataaccess.CreateCart(id);
        }
        public void OnGetAddToCart()
        {
            if (ModelState.IsValid)
            {
                
            }
        }
    }
}
