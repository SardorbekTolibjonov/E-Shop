using E_Shop.Models;

namespace E_Shop.Brokers.Storage;

public class MemoryStorageBroker : IMemoryStorageBroker
{
    private Product[] products = new Product[]
    {
        new Product{Id = 1, Name = "Apple", Price = 120, Weight = 20},
        new Product{Id = 2, Name = "Banana", Price = 60, Weight = 25},
        new Product{Id = 3, Name = "Orange", Price = 80, Weight = 30},
        new Product{Id = 4, Name = "Strawberry", Price = 150, Weight = 10},
        new Product{Id = 5, Name = "Pineapple", Price = 250, Weight = 100},
        new Product{Id = 6, Name = "Grapes", Price = 200, Weight = 50},
        new Product{Id = 7, Name = "Mango", Price = 180, Weight = 35},
        new Product{Id = 8, Name = "Watermelon", Price = 300, Weight = 500},
        new Product{Id = 9, Name = "Peach", Price = 130, Weight = 40},
        new Product{Id = 10, Name = "Pear", Price = 90, Weight = 35}
    };


    public Product[] ReadAllProducts() 
        => products;

    
}
