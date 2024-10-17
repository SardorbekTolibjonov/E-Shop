using E_Shop.Brokers.Loggings;
using E_Shop.Brokers.Storage;
using E_Shop.Models;

namespace E_Shop.Services.LogIns;

public class CredentialService : ICredentialService
{
    private readonly IFileStorageBroker fileStorageBroker;
    private readonly ILoggingBroker loggingBroker;
    public CredentialService()
    {
        this.fileStorageBroker = new FileStorageBroker();
        this.loggingBroker = new LoggingBroker();
    }
    public Credential AddCredential(Credential credential)
    {
        if(CredentialCheck(credential) is true)
        {
            this.loggingBroker.LogError("Credential is already exist");
            return new Credential();
        }

        return ValidateAndAddCredential(credential);
    }

    public bool CredentialCheck(Credential credential)
    {
        Credential[] credentials = this.fileStorageBroker.GetAllCredential();

        if(!IsCredentialAvailable(credentials))
            return false;

        foreach(Credential credentialItem in credentials)
        {
            if(credentialItem.Id == credential.Id)
                return true;
        }

        return false;
    }

    private bool IsCredentialAvailable(Credential[] credentials) =>
        credentials!=null && credentials.Length > 0;

    private Credential ValidateAndAddCredential(Credential credential)
    {
        if (credential.Id is 0
            || String.IsNullOrWhiteSpace(credential.UserName)
            || String.IsNullOrWhiteSpace(credential.Password))
        {
            this.loggingBroker.LogError("Credential invalid");
            return new Credential();
        }
        else
            return this.fileStorageBroker.Add(credential);
    }
}
