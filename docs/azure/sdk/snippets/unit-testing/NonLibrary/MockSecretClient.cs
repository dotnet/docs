using Azure.Security.KeyVault.Secrets;
using Azure;

namespace UnitTestingSampleApp.NonLibrary;

public sealed class MockSecretClient : SecretClient
{
    AsyncPageable<SecretProperties> _pageable;

    // Allow a pageable to be passed in for mocking different responses
    public MockSecretClient(AsyncPageable<SecretProperties> pageable)
    {
        _pageable = pageable;
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

    public override AsyncPageable<SecretProperties> GetPropertiesOfSecretsAsync
        (CancellationToken cancellationToken = default)
    {
        // Return the pageable that was passed in
        return _pageable;
    }
}
