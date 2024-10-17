using E_Shop.Models;

namespace E_Shop.Brokers.Storage;

public interface IMemoryStorageBroker
{
    Product[] ReadAllProducts();
}
