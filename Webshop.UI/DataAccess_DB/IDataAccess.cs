﻿using ModelDTO;
using System.Collections.Generic;

namespace Webshop.UI.DataAccess
{
    public interface IDataAccess
    {
        IEnumerable<CustomersDTO> GetAllCustomers();
        IEnumerable<ProductsDTO> GetAllProducts();
        CustomersDTO LoginForms(string email, string password);
        CustomersDTO GetCustomerById(int id);
        ProductsDTO GetProductById(int id);
        ShoppingCartDTO CreateCart(int id);
        void EditItems(ProductsDTO product);
        IEnumerable<ShoppingCartDTO> GetAllCarts();
        void AddToCart(ProductsDTO products, int id);
        ShoppingCartDTO GetCartById(int id);
        ShoppingCartDTO GetShoppingCart(int id);
    }
}