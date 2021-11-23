using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelDTO;
using Webshop.UI.DataAccess;

namespace Webshop.UI.Pages.StorePage
{
    public class LoggedinIndexModel : PageModel
    {
        private readonly IDataAccess _dataaccess;
        
        public List<ProductsDTO> Products { get; set; }
        [BindProperty]
        public IEnumerable<ProductsDTO> product { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ShoppingCartDTO ShoppingCart { get; set; }
        public LoggedinIndexModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        public void OnGet(int id)
        {
            Products = _dataaccess.GetAllProducts().ToList();
            ShoppingCart = _dataaccess.GetShoppingCart(id);
            product = _dataaccess.Search(SearchTerm);

            if (ShoppingCart != null)
            {
                ShoppingCart = _dataaccess.GetCartById(id);
            }
            else
            {
                ShoppingCart = _dataaccess.CreateCart(id);
            }
        }
        public void OnGetClearCart()
        {
            if (ModelState.IsValid)
            {

            }
        }
        public void OnGetAddToCart(int id, int product)
        {
            if (ModelState.IsValid)
            {
                ProductsDTO products = _dataaccess.GetProductById(product);
                _dataaccess.AddToCart(products, id);
                Products = _dataaccess.GetAllProducts().ToList();
                ShoppingCart = _dataaccess.GetShoppingCart(id);
            }
            
        }
        public IActionResult OnPostGoBack()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/StorePage/LoggedinIndex", "ShoppingCart");
            }
            return Page();
        }
        public void OnGetMax()
        {
            Products = _dataaccess.MaxPrice();
        }
        public void OnGetSortMin(int id)
        {
            ShoppingCart = _dataaccess.GetShoppingCart(id);
            Products = _dataaccess.MinPrice();
        }
    }
}
