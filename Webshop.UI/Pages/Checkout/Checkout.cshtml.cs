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
        public CreditCard card { get; set; }
        public string Feedback { get; set; }
        public string Alert { get; set; }
        [BindProperty]
        public ShoppingCartDTO Cart { get; set; }
        public void OnGet(int id)
        {
            Cart = _dataaccess.GetShoppingCart(id);
        }
        public IActionResult OnPostPay(int id)
        {
            if (ModelState.IsValid)
            {
                if (_dataaccess.CardForms(card.CreditCardNumber, card.SecurityCode))
                {
                    _dataaccess.SaveRecipt(id);
                    _dataaccess.ClearCartById(id);
                    return RedirectToPage("/Checkout/RecieptHistory");
                }
                else if (!_dataaccess.CardForms(card.CreditCardNumber, card.SecurityCode))
                {
                    Feedback = "Invalid creditcard number or security code";
                    Alert = "alert alert-danger";
                }
                
            }
            Cart = _dataaccess.GetShoppingCart(id);

            return Page();
        }
    }
}
