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
    public Product[] AddCart(int[] id)
    {
        Product[] products = this.memoryStorageBroker.ReadAllProducts();
        if (!IsProductAvailable(products))
            return new Product[0]; 

        return AddProductToCart(id, products);
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

    private Product[] AddProductToCart(int[] id, Product[] products)
    {
        int count = id.Length, cartIndex = 0;
        Product[] cartProducts = new Product[count];

        foreach (Product product in products)
        {
            for (int i = 0; i < id.Length; i++)
            {
                if (product.Id == id[i])
                    cartProducts[cartIndex++] = product;
            }
            
        }

        return cartProducts;
    }
}
