using Azure.Security.KeyVault.Secrets;

public class AboutToExpireSecretFinder
{
    private readonly TimeSpan _threshold;
    private readonly SecretClient _client;

    public AboutToExpireSecretFinder(TimeSpan threshold, SecretClient client)
    {
        _threshold = threshold;
        _client = client;
    }

    public async Task<string[]> GetAboutToExpireSecretsAsync()
    {
        List<string> secretsAboutToExpire = new();

        await foreach (var secret in _client.GetPropertiesOfSecretsAsync())
        {
            if (secret.ExpiresOn.HasValue &&
                secret.ExpiresOn.Value - DateTimeOffset.Now <= _threshold)
            {
                secretsAboutToExpire.Add(secret.Name);
            }
        }

        return secretsAboutToExpire.ToArray();
    }
}