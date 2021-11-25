using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelDTO;
using Webshop.UI.DataAccess;

namespace Webshop.UI.Pages.StorePage
{
    public class LoggedinIndexModel : PageModel
    {
        private readonly IDataAccess _dataaccess;
        [BindProperty]
        public List<ProductsDTO> Products { get; set; }
        [BindProperty]
        public ProductsDTO product { get; set; }
        [BindProperty]
        public int Cartid { get; set; }
        [BindProperty]
        public string Productname { get; set; }
        [BindProperty]
        public ShoppingCartDTO ShoppingCart { get; set; }
        public LoggedinIndexModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        public void OnGet(int id)
        {
            Products = _dataaccess.GetAllProducts().ToList();
            var cart = _dataaccess.GetAllCarts().ToList().SingleOrDefault(cart => cart.CartId == id);

            if (cart != null)
            {
                ShoppingCart = _dataaccess.GetCartById(id);
            }
            else
            {
                ShoppingCart = _dataaccess.CreateCart(id);
            }
            
        }
        public IActionResult OnPostSearch(int id)
        {
            Products = _dataaccess.GetAllProducts().ToList();
            ShoppingCart = _dataaccess.GetShoppingCart(id);
            
            if (!string.IsNullOrEmpty(Productname))
            {
                Products = Products.Where(p => p.Name.ToLower().Contains(Productname.ToLower())).ToList();
                return Page();
            }

            return RedirectToPage("/StorePage/LoggedinIndex", new { id = ShoppingCart.CartId});
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
        public void OnGetMax(int id)
        {
            ShoppingCart = _dataaccess.GetShoppingCart(id);
            Products = _dataaccess.MaxPrice();
        }
        public void OnGetSortMin(int id)
        {
            ShoppingCart = _dataaccess.GetShoppingCart(id);
            Products = _dataaccess.MinPrice();
        }
    }
}
