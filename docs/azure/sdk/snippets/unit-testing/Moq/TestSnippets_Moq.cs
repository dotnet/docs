using Azure.Security.KeyVault.Secrets;
using Azure;
using Moq;

namespace UnitTestingSampleApp.Moq;

public class TestSnippets_Moq
{
    [Fact]
    public async Task ServiceClientSnippets()
    {
        // <MockSecretClient>
        KeyVaultSecret keyVaultSecret = SecretModelFactory.KeyVaultSecret(
            new SecretProperties("secret"), "secretValue");

        Mock<SecretClient> clientMock = new Mock<SecretClient>();
        clientMock.Setup(c => c.GetSecret(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>())
            )
            .Returns(Response.FromValue(keyVaultSecret, Mock.Of<Response>()));

        clientMock.Setup(c => c.GetSecretAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>())
            )
            .ReturnsAsync(Response.FromValue(keyVaultSecret, Mock.Of<Response>()));

        SecretClient secretClient = clientMock.Object;
        // </MockSecretClient>
    }

    [Fact]
    public async Task ResponseTypeSnippets()
    {
        // <MockResponseType>
        Mock<Response> responseMock = new Mock<Response>();
        responseMock.SetupGet(r => r.Status).Returns(200);

        Response response = responseMock.Object;
        // </MockResponseType>
    }

    [Fact]
    public async Task ResponseTypeTSnippets()
    {
        // <MockResponseTypeT>
        KeyVaultSecret keyVaultSecret = SecretModelFactory.KeyVaultSecret(
            new SecretProperties("secret"), "secretValue");
        Response<KeyVaultSecret> response = Response.FromValue(keyVaultSecret, Mock.Of<Response>());
        // </MockResponseTypeT>
    }


    [Fact]
    public async Task PaggingSnippets()
    {
        // <SingleResponsePage>
        Page<SecretProperties> responsePage = Page<SecretProperties>.FromValues(
            new[] {
                new SecretProperties("secret1"),
                new SecretProperties("secret2")
            },
            continuationToken: null,
            Mock.Of<Response>());
        // </SingleResponsePage>

        // <MultipleResponsePage>
        Page<SecretProperties> page1 = Page<SecretProperties>.FromValues(
            new[]
            {
                new SecretProperties("secret1"),
                new SecretProperties("secret2")
            },
            "continuationToken",
            Mock.Of<Response>());

        Page<SecretProperties> page2 = Page<SecretProperties>.FromValues(
            new[]
            {
                new SecretProperties("secret3"),
                new SecretProperties("secret4")
            },
            "continuationToken2",
            Mock.Of<Response>());

        Page<SecretProperties> lastPage = Page<SecretProperties>.FromValues(
            new[]
            {
                new SecretProperties("secret5"),
                new SecretProperties("secret6")
            },
            continuationToken: null,
            Mock.Of<Response>());

        Pageable<SecretProperties> pageable = Pageable<SecretProperties>.FromPages(new[] { page1, page2, lastPage });
        AsyncPageable<SecretProperties> asyncPageable = AsyncPageable<SecretProperties>.FromPages(new[] { page1, page2, lastPage });
        // <MultipleResponsePage>
    }

}
