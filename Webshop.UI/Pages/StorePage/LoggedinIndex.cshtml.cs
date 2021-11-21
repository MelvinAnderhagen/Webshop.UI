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
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public List<ProductsDTO> Products { get; set; }
        [BindProperty]
        public ShoppingCartDTO ShoppingCart { get; set; }
        public LoggedinIndexModel(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        public void OnGetLogin(int id)
        {
            Products = _dataaccess.GetAllProducts().ToList();
            ShoppingCart = _dataaccess.GetShoppingCart(id);

            if (ShoppingCart != null)
            {
                ShoppingCart = _dataaccess.GetCartById(id);
            }
            else
            {
                ShoppingCart = _dataaccess.CreateCart(id);
            }

        }
        public void OnGetAddToCart(ProductsDTO product, int id)
        {
            if (ModelState.IsValid)
            {
                _dataaccess.AddToCart(product, id);
            }
            
        }
    }
}
