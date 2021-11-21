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
    public class CustomersModel : PageModel
    {
        private readonly IDataAccess _dataaccess;
        [BindProperty]
        public int Id { get; set; }
        public CustomersModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        public List<CustomersDTO> Customers { get; set; }
        public void OnGet()
        {
            Customers = _dataaccess.GetAllCustomers().ToList();
        }
        public IActionResult OnGetEdit()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/Edit/EditCustomers", "Customers", new { id = Id });
            }
            return Page();
        }
    }
}
