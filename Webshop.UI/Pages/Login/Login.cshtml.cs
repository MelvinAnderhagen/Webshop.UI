using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;
using Webshop.UI.DataAccess;

namespace Webshop.UI.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly IDataAccess _dataaccess;
        [BindProperty]
        public CustomersDTO Customer { get; set; }
        public string AlertsCaller { get; set; }
        public string Feedback { get; set; }
        [BindProperty]
        public int Id { get; set; }
        public LoginModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        public void OnGet()
        {
            var user = _dataaccess.GetAllCustomers().ToList();
        }

        public IActionResult OnPostLogin()
        {
            if (ModelState.IsValid) 
            {
                if (_dataaccess.UserNotFound(Customer.Email, Customer.Password))
                {
                    AlertsCaller = "alert alert-success";
                    Feedback = "You have successfully logged in."; 
                    return RedirectToPage("/StorePage/LoggedinIndex", "Login", new { id = Id});
                }
                else
                {
                    AlertsCaller = "alert alert-danger";
                    Feedback = "Email or Password is incorrect.";
                }
            }
            return Page();

        }
    }
}
