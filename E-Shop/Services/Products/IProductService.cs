﻿using E_Shop.Models;

namespace E_Shop.Services.Products;

public interface IProductService
{
    Product[] AddCart(int[] id);
    Product[] GetAllProduct();
}
