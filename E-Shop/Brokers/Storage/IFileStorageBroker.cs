using E_Shop.Models;

namespace E_Shop.Brokers.Storage;

public interface IFileStorageBroker
{
    Credential Add(Credential credential);
    Credential[] GetAllCredential();
}
