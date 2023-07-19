using Azure.Security.KeyVault.Secrets;
using Azure;
using NSubstitute;

namespace UnitTestingSampleApp.Moq;

public class TestSnippets_NSubstitute
{
    public void ServiceClientSnippets()
    {
        // <MockSecretClient>
        KeyVaultSecret keyVaultSecret = SecretModelFactory.KeyVaultSecret(
            new SecretProperties("secret"), "secretValue");

        SecretClient clientMock = Substitute.For<SecretClient>();
        clientMock.GetSecret(
                Arg.Any<string>(),
                Arg.Any<string>(),
                Arg.Any<CancellationToken>()
            )
            .Returns(Response.FromValue(keyVaultSecret, Substitute.For<Response>()));

        clientMock.GetSecretAsync(
                Arg.Any<string>(),
                Arg.Any<string>(),
                Arg.Any<CancellationToken>()
            )
            .Returns(Response.FromValue(keyVaultSecret, Substitute.For<Response>()));

        SecretClient secretClient = clientMock;
        // </MockSecretClient>
    }

    public void ResponseTypeSnippets()
    {
        // <MockResponse>
        Response responseMock = Substitute.For<Response>();
        responseMock.Status.Returns(200);

        Response response = responseMock;
        // </MockResponse>
    }

    public void ResponseTypeTSnippets()
    {
        // <MockResponseT>
        KeyVaultSecret keyVaultSecret = SecretModelFactory.KeyVaultSecret(
            new SecretProperties("secret"), "secretValue");
        Response<KeyVaultSecret> response = Response.FromValue(keyVaultSecret, Substitute.For<Response>());
        // </MockResponseT>
    }


    public void PaggingSnippets()
    {
        // <SingleResponsePage>
        Page<SecretProperties> responsePage = Page<SecretProperties>.FromValues(
            new[] {
                new SecretProperties("secret1"),
                new SecretProperties("secret2")
            },
            continuationToken: null,
            Substitute.For<Response>());
        // </SingleResponsePage>

        // <MultipleResponsePage>
        Page<SecretProperties> page1 = Page<SecretProperties>.FromValues(
            new[]
            {
                new SecretProperties("secret1"),
                new SecretProperties("secret2")
            },
            "continuationToken",
            Substitute.For<Response>());

        Page<SecretProperties> page2 = Page<SecretProperties>.FromValues(
            new[]
            {
                new SecretProperties("secret3"),
                new SecretProperties("secret4")
            },
            "continuationToken2",
            Substitute.For<Response>());

        Page<SecretProperties> lastPage = Page<SecretProperties>.FromValues(
            new[]
            {
                new SecretProperties("secret5"),
                new SecretProperties("secret6")
            },
            continuationToken: null,
            Substitute.For<Response>());

        Pageable<SecretProperties> pageable = Pageable<SecretProperties>
            .FromPages(new[] { page1, page2, lastPage });

        AsyncPageable<SecretProperties> asyncPageable = AsyncPageable<SecretProperties>
            .FromPages(new[] { page1, page2, lastPage });
        // </MultipleResponsePage>
    }

}
