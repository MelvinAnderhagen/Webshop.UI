using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;
using Webshop.UI.DataAccess;

namespace Webshop.UI.Pages.Register
{
    public class RegisterNewCustomerModel : PageModel
    {
        private readonly IDataAccess _dataaccess;
        public CustomersDTO customer { get; set; }
        public RegisterNewCustomerModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostRegister(CustomersDTO customer)
        {
            if (ModelState.IsValid)
            {
                _dataaccess.RegisterCustomer(customer);
                return RedirectToPage("/Index", "RegisterNewCustomer");
            }
            return Page();
        }
    }
}
