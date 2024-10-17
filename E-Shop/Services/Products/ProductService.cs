using E_Shop.Brokers.Loggings;
using E_Shop.Brokers.Storage;
using E_Shop.Models;

namespace E_Shop.Services.Products;

public class ProductService : IProductService
{
    private readonly IMemoryStorageBroker memoryStorageBroker;

    public ProductService()
    {
        this.memoryStorageBroker = new MemoryStorageBroker();
    }
    public Product[] AddCart(int[] ids)
    {
        Product[] products = this.memoryStorageBroker.ReadAllProducts();
        

        if (!IsProductAvailable(products) || !IsIdAvailable(ids))
            return new Product[0]; 

        return AddProductToCart(ids, products);
    }

    public Product[] GetAllProduct()
    {
        Product[] products = this.memoryStorageBroker.ReadAllProducts();
        if(!IsProductAvailable(products))
            return new Product[0];
        return products;
    }

    private bool IsProductAvailable(Product[] products) =>
     products != null && products.Length > 0;

    private Product[] AddProductToCart(int[] ids, Product[] products)
    {
        int count = ids.Length, cartIndex = 0;
        Product[] cartProducts = new Product[count];

        foreach (Product product in products)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                if (product.Id == ids[i])
                    cartProducts[cartIndex++] = product;
            }
            
        }

        return cartProducts;
    }

    private bool IsIdAvailable(int[] ids) =>
        ids != null && ids.Length > 0;
}
