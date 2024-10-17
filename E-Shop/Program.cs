using E_Shop.Brokers.Storage;
using E_Shop.Models;

namespace E_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFileStorageBroker broker = new FileStorageBroker();
            IMemoryStorageBroker memoryBroker = new MemoryStorageBroker();
            Credential credential = new Credential()
            {
                Id = 1,
                UserName = "admin",
                Password = "admin",
            };

            broker.Add(credential);
            Credential[] credentials = broker.GetAllCredential();
            foreach (Credential credential1 in credentials)
            {
                Console.WriteLine($"{credential1.Id} - {credential1.UserName} - {credential1.Password}");
            }
        }
    }
}
