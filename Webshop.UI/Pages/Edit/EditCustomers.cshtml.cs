using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;
using Webshop.UI.DataAccess;

namespace Webshop.UI.Pages.Edit
{
    public class EditCustomersModel : PageModel
    {
        private readonly IDataAccess _dataaccess;
        public EditCustomersModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        [BindProperty]
        public CustomersDTO Customer { get; set; }
        public void OnGet(int id)
        {
            Customer = _dataaccess.GetCustomerById(id);
        }
        public IActionResult OnPostSave()
        {
            if (ModelState.IsValid)
            {
                _dataaccess.EditCustomer(Customer);
                return RedirectToPage("/Edit/Customers");
            }
            return Page();
        }
    }
}
