using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Card;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;
using Webshop.UI.DataAccess;

namespace Webshop.UI.Pages.Checkout
{
    public class CheckoutModel : PageModel
    {
        private readonly IDataAccess _dataaccess;

        public CheckoutModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        [BindProperty]
        public CustomersDTO user { get; set; }
        [BindProperty]
        public ShoppingCartDTO Cart { get; set; }
        public void OnGet(int id)
        {
            Cart = _dataaccess.GetShoppingCart(id);
            
        }
        public IActionResult OnPostPay(int id)
        {
            if (_dataaccess.CardForms(user.CreditCardNumber))
            {
                _dataaccess.SaveRecipt(id);

                return RedirectToPage("/StorePage/LoggedinIndex");
            }
            Cart = _dataaccess.GetShoppingCart(id);
            
            return Page();
        }
    }
}
