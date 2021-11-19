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
        public CustomersDTO user { get; set; }
        [BindProperty]
        public List<CustomersDTO> Users { get; set; }
        public string AlertsCaller { get; set; }
        public string Feedback { get; set; }
        public LoginModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        public void OnGet()
        {
            Users = _dataaccess.GetAllCustomers().ToList();
        }

        public IActionResult OnPostLogin()
        {
            if (ModelState.IsValid) 
            {
                CustomersDTO customer = _dataaccess.LoginForms(user.Email, user.Password); 
                if (customer != null)
                {
                    return RedirectToPage("/StorePage/LoggedinIndex", "Login", new { Id = customer.Id});
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
