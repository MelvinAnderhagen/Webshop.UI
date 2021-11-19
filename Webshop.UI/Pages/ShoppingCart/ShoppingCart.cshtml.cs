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

        public ShoppingCartDTO Cart { get; set; }
        public ShoppingCartModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        public void OnGet(int id)
        {
            Cart = _dataaccess.GetShoppingCart(id);
        }
        public void OnGetAddToCart(int id)
        {
            if (ModelState.IsValid)
            {
                
            }
        }
    }
}
