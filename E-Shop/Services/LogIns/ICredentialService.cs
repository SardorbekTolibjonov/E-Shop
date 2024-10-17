using E_Shop.Models;

namespace E_Shop.Services.LogIns;

public interface ICredentialService
{
    Credential AddCredential(Credential credential);
    bool CredentialCheck(Credential credential);
}
