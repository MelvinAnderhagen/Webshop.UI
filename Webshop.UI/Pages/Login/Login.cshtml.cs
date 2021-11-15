using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSource_DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;
using Webshop.UI.DataAccess;

namespace Webshop.UI.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly IDataSource _datasource;
        private readonly IDataAccess _dataaccess;
        [BindProperty]
        public CustomersDTO Customer { get; set; }
        public string AlertsCaller { get; set; }
        public string Feedback { get; set; }
        public LoginModel(IDataSource datasource, IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
            _datasource = datasource;
        }
        
        public void OnGet()
        {
            var user = _datasource.GetAllCustomers().ToList();
        }

        public void OnPostLogin()
        {
            if (ModelState.IsValid) //Modelstate är en summering av våra anotationer
            {
                if (_dataaccess.UserNotFound(Customer.Email, Customer.Password))
                {
                    AlertsCaller = "alert alert-success";
                    Feedback = "You have successfully logged in."; //Uppfyller vi kraven av vår modelstate.
                }
                else
                {
                    AlertsCaller = "alert alert-danger";
                    Feedback = "Email or Password is incorrect.";
                }

            }
            

        }
    }
}
