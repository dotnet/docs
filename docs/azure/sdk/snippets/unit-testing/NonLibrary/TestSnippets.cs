﻿using Azure;
using Azure.Security.KeyVault.Secrets;

namespace UnitTestingSampleApp.NonLibrary;

public class TestSnippets
{
    public void ResponseTypeTSnippets()
    {
        // <MockResponseT>
        KeyVaultSecret keyVaultSecret = SecretModelFactory.KeyVaultSecret(
            new SecretProperties("secret"), "secretValue");

        Response<KeyVaultSecret> response = Response.FromValue(keyVaultSecret, new MockResponse());
        // </MockResponseT>
    }

    public void PagingSnippets()
    {
        // <SingleResponsePage>
        Page<SecretProperties> responsePage = Page<SecretProperties>.FromValues(
            new[] {
                new SecretProperties("secret1"),
                new SecretProperties("secret2")
            },
            continuationToken: null,
            new MockResponse());
        // </SingleResponsePage>

        // <MultipleResponsePage>
        Page<SecretProperties> page1 = Page<SecretProperties>.FromValues(
            new[]
            {
                new SecretProperties("secret1"),
                new SecretProperties("secret2")
            },
            "continuationToken",
            new MockResponse());

        Page<SecretProperties> page2 = Page<SecretProperties>.FromValues(
            new[]
            {
                new SecretProperties("secret3"),
                new SecretProperties("secret4")
            },
            "continuationToken2",
            new MockResponse());

        Page<SecretProperties> lastPage = Page<SecretProperties>.FromValues(
            new[]
            {
                new SecretProperties("secret5"),
                new SecretProperties("secret6")
            },
            continuationToken: null,
            new MockResponse());

        Pageable<SecretProperties> pageable = Pageable<SecretProperties>
            .FromPages(new[] { page1, page2, lastPage });

        AsyncPageable<SecretProperties> asyncPageable = AsyncPageable<SecretProperties>
            .FromPages(new[] { page1, page2, lastPage });
        // </MultipleResponsePage>
    }
}
