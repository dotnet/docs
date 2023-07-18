using Azure.Security.KeyVault.Secrets;
using Azure;
using Moq;

public class MockSecretClient : SecretClient
{
    AsyncPageable<SecretProperties> pageable;

    public MockSecretClient(AsyncPageable<SecretProperties> pageable)
    {
        this.pageable = pageable;
    }

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

    public override AsyncPageable<SecretProperties> GetPropertiesOfSecretsAsync(CancellationToken cancellationToken = default)
    {
        // Create a pageable that consists of a single page
        return pageable;
    }   
}
