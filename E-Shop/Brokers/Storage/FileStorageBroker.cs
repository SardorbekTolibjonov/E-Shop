using E_Shop.Models;

namespace E_Shop.Brokers.Storage;

public class FileStorageBroker : IFileStorageBroker
{
    private const string FilePath = "../../../Assets/Credential.txt";
    public FileStorageBroker()
    {
        EnsureFileExists();
    }
    public Credential Add(Credential credential)
    {
        string credentialLine = $"{credential.Id}*{credential.UserName}*{credential.Password}\n";

        File.AppendAllText(FilePath, credentialLine);

        return credential;
    }

    public Credential[] GetAllCredential()
    {
        string[] credentialLines = File.ReadAllLines(FilePath);
        int count = credentialLines.Length;
        Credential[] credentials = new Credential[count];

        for(int i = 0; i<count; i++)
        {
            string[] credentialProperties = credentialLines[i].Split("*");
            Credential credential = new Credential()
            {
                Id = int.Parse(credentialProperties[0]),
                UserName = credentialProperties[1],
                Password = credentialProperties[2]
            };
            credentials[i] = credential;
        }

        return credentials;
    }

    private void EnsureFileExists()
    {
        bool fileExist = File.Exists(FilePath);

        if (fileExist is false)
        {
            File.Create(FilePath).Close();
        }
    }
}
