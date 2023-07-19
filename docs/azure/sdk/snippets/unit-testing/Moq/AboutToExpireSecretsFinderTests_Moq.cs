using Azure;
using Azure.Security.KeyVault.Secrets;
using Moq;

public class AboutToExpireSecretFinderTests_Moq
{
    [Fact]
    public async Task DoesNotReturnNonExpiringSecrets()
    {
        // Arrange
        // Create a page of enumeration results
        Page<SecretProperties> page = Page<SecretProperties>.FromValues(new[]
        {
            new SecretProperties("secret1") { ExpiresOn = null },
            new SecretProperties("secret2") { ExpiresOn = null }
        }, null, Mock.Of<Response>());

        // Create a pageable that consists of a single page
        AsyncPageable<SecretProperties> pageable =
            AsyncPageable<SecretProperties>.FromPages(new[] { page });

        // Setup a client mock object to return the pageable
        var clientMock = new Mock<SecretClient>();
        clientMock.Setup(c => c.GetPropertiesOfSecretsAsync(It.IsAny<CancellationToken>()))
            .Returns(pageable);

        // Create an instance of a class to test passing in the mock client
        var finder = new AboutToExpireSecretFinder(TimeSpan.FromDays(2), clientMock.Object);

        // Act
        string[] soonToExpire = await finder.GetAboutToExpireSecretsAsync();

        // Assert
        Assert.Empty(soonToExpire);
    }

    [Fact]
    public async Task ReturnsSecretsThatExpireSoon()
    {
        // Arrange

        // Create a page of enumeration results
        DateTimeOffset now = DateTimeOffset.Now;
        Page<SecretProperties> page = Page<SecretProperties>.FromValues(new[]
        {
            new SecretProperties("secret1") { ExpiresOn = now.AddDays(1) },
            new SecretProperties("secret2") { ExpiresOn = now.AddDays(2) },
            new SecretProperties("secret3") { ExpiresOn = now.AddDays(3) }
        }, null, Mock.Of<Response>());

        // Create a pageable that consists of a single page
        AsyncPageable<SecretProperties> pageable =
            AsyncPageable<SecretProperties>.FromPages(new[] { page });

        // Setup a client mock object to return the pageable
        var clientMock = new Mock<SecretClient>();
        clientMock.Setup(c => c.GetPropertiesOfSecretsAsync(It.IsAny<CancellationToken>()))
            .Returns(pageable);

        // Create an instance of a class to test passing in the mock client
        var finder = new AboutToExpireSecretFinder(TimeSpan.FromDays(2), clientMock.Object);

        // Act
        string[] soonToExpire = await finder.GetAboutToExpireSecretsAsync();

        // Assert
        Assert.Equal(new[] { "secret1", "secret2" }, soonToExpire);
    }
}
