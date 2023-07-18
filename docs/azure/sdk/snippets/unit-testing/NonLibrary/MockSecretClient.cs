using Azure.Security.KeyVault.Secrets;
using Azure;

public class MockSecretClient : SecretClient
{
    public override Response<KeyVaultSecret> GetSecret(
        string name,
        string version = null,
        CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public override Task<Response<KeyVaultSecret>> GetSecretAsync(
        string name,
        string version = null,
        CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
