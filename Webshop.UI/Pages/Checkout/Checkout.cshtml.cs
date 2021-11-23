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
        public int id { get; set; }
        public CustomersDTO user { get; set; }
        public ShoppingCartDTO Cart { get; set; }
        public void OnGet(int id)
        {
            Cart = _dataaccess.GetShoppingCart(id);
            user = _dataaccess.GetCustomerById(id);
        }
        public IActionResult OnGetPay(int ccn, int products)
        {
            if (ModelState.IsValid)
            {
                _dataaccess.CardForms(ccn);
                _dataaccess.SaveRecipt(products);
                return RedirectToPage("/StorePage/LoggedinIndex");
            }
            return Page();
        }
    }
}
