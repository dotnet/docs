---
title: Using the Postgres Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data in Postgres.
ms.topic: concept-article
ms.date: 10/24/2024
---
# Using the Postgres Vector Store connector (Preview)

> [!WARNING]
> The Postgres Vector Store functionality is in preview, and improvements that require breaking changes might still occur in limited circumstances before release.

## Overview

The Postgres Vector Store connector can be used to access and manage data in Postgres and also supports [Neon Serverless Postgres](https://azuremarketplace.microsoft.com/en-us/marketplace/apps/neon1722366567200.neon_serverless_postgres_azure_prod).

The connector has the following characteristics.

| Feature Area | Support |
|--|--|
| Collection maps to | Postgres table |
| Supported key property types | <ul><li>short</li><li>int</li><li>long</li><li>string</li><li>Guid</li></ul> |
| Supported data property types | <ul><li>bool</li><li>short</li><li>int</li><li>long</li><li>float</li><li>double</li><li>decimal</li><li>string</li><li>DateTime</li><li>DateTimeOffset</li><li>Guid</li><li>byte[]</li><li>bool Enumerables</li><li>short Enumerables</li><li>int Enumerables</li><li>long Enumerables</li><li>float Enumerables</li><li>double Enumerables</li><li>decimal Enumerables</li><li>string Enumerables</li><li>DateTime Enumerables</li><li>DateTimeOffset Enumerables</li><li>Guid Enumerables</li></ul> |
| Supported vector property types | <ul><li>ReadOnlyMemory\<float\></li><li>Embedding\<float\></li><li>float[]</li><li>ReadOnlyMemory\<Half\></li><li>Embedding\<Half\></li><li>Half[]</li><li>BitArray</li><li>Pgvector.SparseVector</li></ul> |
| Supported index types | Hnsw |
| Supported distance functions | <ul><li>CosineDistance</li><li>CosineSimilarity</li><li>DotProductSimilarity</li><li>EuclideanDistance</li><li>ManhattanDistance</li></ul> |
| Supported filter clauses | <ul><li>AnyTagEqualTo</li><li>EqualTo</li></ul> |
| Supports multiple vectors in a record | Yes |
| IsIndexed supported? | No |
| IsFullTextIndexed supported? | No |
| StorageName supported? | Yes |
| HybridSearch supported? | No |

## Limitations

> [!IMPORTANT]
> When initializing `NpgsqlDataSource` manually, it is necessary to call `UseVector` on the `NpgsqlDataSourceBuilder`. This enables vector support. Without this, usage of the VectorStore implementation will fail.

Here is an example of how to call `UseVector`.

```csharp
NpgsqlDataSourceBuilder dataSourceBuilder = new("Host=localhost;Port=5432;Username=postgres;Password=example;Database=postgres;");
dataSourceBuilder.UseVector();
NpgsqlDataSource dataSource = dataSourceBuilder.Build();
```

When using the `AddPostgresVectorStore` dependency injection registration method with a connection string, the datasource will be constructed by this method and will automatically have `UseVector` applied.

## Get started

Add the Postgres Vector Store connector NuGet package to your project.

```dotnetcli
dotnet add package Microsoft.SemanticKernel.Connectors.PgVector --prerelease
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods from the Semantic Kernel connector packages.

```csharp
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddPostgresVectorStore("<Connection String>");
```

Where `<Connection String>` is a connection string to the Postgres instance, in the format that [Npgsql](https://www.npgsql.org/) expects, for example `Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres`.

Extension methods that take no parameters are also provided. These require an instance of [NpgsqlDataSource](https://www.npgsql.org/doc/api/Npgsql.NpgsqlDataSource.html) to be separately registered with the dependency injection container. Note that `UseVector` must be called on the builder to enable vector support via [pgvector-dotnet](https://github.com/pgvector/pgvector-dotnet?tab=readme-ov-file#npgsql-c):

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPostgresVectorStore("<Connection String>");
```

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Npgsql;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<NpgsqlDataSource>(sp =>
{
    NpgsqlDataSourceBuilder dataSourceBuilder = new("<Connection String>");
    dataSourceBuilder.UseVector();
    return dataSourceBuilder.Build();
});
builder.Services.AddPostgresVectorStore();
```

You can construct a Postgres Vector Store instance directly with a custom data source or with a connection string.

```csharp
using Microsoft.SemanticKernel.Connectors.PgVector;
using Npgsql;

NpgsqlDataSourceBuilder dataSourceBuilder = new("<Connection String>");
dataSourceBuilder.UseVector();
NpgsqlDataSource dataSource = dataSourceBuilder.Build();
var vectorStore = new PostgresVectorStore(dataSource, ownsDataSource: true);
```

```csharp
using Microsoft.SemanticKernel.Connectors.PgVector;

var connection = new PostgresVectorStore("<Connection String>");
```

It's possible to construct a direct reference to a named collection with a custom data source or with a connection string.

```csharp
using Microsoft.SemanticKernel.Connectors.PgVector;
using Npgsql;

NpgsqlDataSourceBuilder dataSourceBuilder = new("<Connection String>");
dataSourceBuilder.UseVector();
var dataSource = dataSourceBuilder.Build();

var collection = new PostgresCollection<string, Hotel>(dataSource, "skhotels", ownsDataSource: true);
```

```csharp
using Microsoft.SemanticKernel.Connectors.PgVector;

var collection = new PostgresCollection<string, Hotel>("<Connection String>", "skhotels");
```

## Data mapping

The Postgres connector provides a default mapper when mapping data from the data model to storage.
The default mapper uses the model annotations or record definition to determine the type of each property and to map the model
into a Dictionary that can be serialized to Postgres.

- The data model property annotated as a key will be mapped to the PRIMARY KEY in the Postgres table.
- The data model properties annotated as data will be mapped to a table column in Postgres.
- The data model properties annotated as vectors will be mapped to a table column that has the pgvector `VECTOR` type in Postgres.

### Property name override

You can provide override field names to use in storage that is different from the
property names on the data model. This allows you to match table column names even
if they don't match the property names on the data model.

The property name override is done by setting the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> option via the data model attributes or record definition.

Here is an example of a data model with <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> set on its attributes and how it will be represented in Postgres as a table, assuming the Collection name is `Hotels`.

```csharp
using System;
using Microsoft.Extensions.VectorData;

public class Hotel
{
    [VectorStoreKey(StorageName = "hotel_id")]
    public int HotelId { get; set; }

    [VectorStoreData(StorageName = "hotel_name")]
    public string HotelName { get; set; }

    [VectorStoreData(StorageName = "hotel_description")]
    public string Description { get; set; }

    [VectorStoreVector(Dimensions: 4, DistanceFunction = DistanceFunction.CosineDistance, IndexKind = IndexKind.Hnsw, StorageName = "hotel_description_embedding")]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
```

```sql
CREATE TABLE IF NOT EXISTS public."Hotels" (
    "hotel_id" INTEGER PRIMARY KEY NOT NULL,
    hotel_name TEXT,
    hotel_description TEXT,
    hotel_description_embedding VECTOR(4)
);
```

## Vector indexing

The `hotel_description_embedding` in the above `Hotel` model is a vector property with `IndexKind.HNSW`
indexing. This index will be created automatically when the collection is created.
HNSW is the only index type supported for index creation. IVFFlat index building requires that data already
exist in the table at index creation time, and so it is not appropriate for the creation of an empty table.
You are free to create and modify indexes on tables outside of the connector, which will
be used by the connector when performing queries.

## Use with Entra authentication

Azure Database for PostgreSQL provides the ability to connect to your database using [Entra authentication](/azure/postgresql/flexible-server/concepts-azure-ad-authentication).
This removes the need to store a username and password in your connection string.
To use Entra authentication for an Azure DB for PostgreSQL database, you can use the following Npgsql extension method and set a connection string that does not have a username or password:

```csharp
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Identity;
using Npgsql;

namespace Program;

public static class NpgsqlDataSourceBuilderExtensions
{
    private static readonly TokenRequestContext s_azureDBForPostgresTokenRequestContext = new(["https://ossrdbms-aad.database.windows.net/.default"]);

    public static NpgsqlDataSourceBuilder UseEntraAuthentication(this NpgsqlDataSourceBuilder dataSourceBuilder, TokenCredential? credential = default)
    {
        credential ??= new DefaultAzureCredential();

        if (dataSourceBuilder.ConnectionStringBuilder.Username == null)
        {
            var token = credential.GetToken(s_azureDBForPostgresTokenRequestContext, default);
            SetUsernameFromToken(dataSourceBuilder, token.Token);
        }

        SetPasswordProvider(dataSourceBuilder, credential, s_azureDBForPostgresTokenRequestContext);

        return dataSourceBuilder;
    }

    public static async Task<NpgsqlDataSourceBuilder> UseEntraAuthenticationAsync(this NpgsqlDataSourceBuilder dataSourceBuilder, TokenCredential? credential = default, CancellationToken cancellationToken = default)
    {
        credential ??= new DefaultAzureCredential();

        if (dataSourceBuilder.ConnectionStringBuilder.Username == null)
        {
            var token = await credential.GetTokenAsync(s_azureDBForPostgresTokenRequestContext, cancellationToken).ConfigureAwait(false);
            SetUsernameFromToken(dataSourceBuilder, token.Token);
        }

        SetPasswordProvider(dataSourceBuilder, credential, s_azureDBForPostgresTokenRequestContext);

        return dataSourceBuilder;
    }

    private static void SetPasswordProvider(NpgsqlDataSourceBuilder dataSourceBuilder, TokenCredential credential, TokenRequestContext tokenRequestContext)
    {
        dataSourceBuilder.UsePasswordProvider(_ =>
        {
            var token = credential.GetToken(tokenRequestContext, default);
            return token.Token;
        }, async (_, ct) =>
        {
            var token = await credential.GetTokenAsync(tokenRequestContext, ct).ConfigureAwait(false);
            return token.Token;
        });
    }

    private static void SetUsernameFromToken(NpgsqlDataSourceBuilder dataSourceBuilder, string token)
    {
        var username = TryGetUsernameFromToken(token);

        if (username != null)
        {
            dataSourceBuilder.ConnectionStringBuilder.Username = username;
        }
        else
        {
            throw new Exception("Could not determine username from token claims");
        }
    }

    private static string? TryGetUsernameFromToken(string jwtToken)
    {
        // Split the token into its parts (Header, Payload, Signature)
        var tokenParts = jwtToken.Split('.');
        if (tokenParts.Length != 3)
        {
            return null;
        }

        // The payload is the second part, Base64Url encoded
        var payload = tokenParts[1];

        // Add padding if necessary
        payload = AddBase64Padding(payload);

        // Decode the payload from Base64Url
        var decodedBytes = Convert.FromBase64String(payload);
        var decodedPayload = Encoding.UTF8.GetString(decodedBytes);

        // Parse the decoded payload as JSON
        var payloadJson = JsonSerializer.Deserialize<JsonElement>(decodedPayload);

        // Try to get the username from 'upn', 'preferred_username', or 'unique_name' claims
        if (payloadJson.TryGetProperty("upn", out var upn))
        {
            return upn.GetString();
        }
        else if (payloadJson.TryGetProperty("preferred_username", out var preferredUsername))
        {
            return preferredUsername.GetString();
        }
        else if (payloadJson.TryGetProperty("unique_name", out var uniqueName))
        {
            return uniqueName.GetString();
        }

        return null;
    }

    private static string AddBase64Padding(string base64) => (base64.Length % 4) switch
    {
        2 => base64 + "==",
        3 => base64 + "=",
        _ => base64,
    };
}
```

Now you can use the `UseEntraAuthentication` method to set up the connection string for the Postgres connector:

```csharp
using Microsoft.SemanticKernel.Connectors.Postgres;

var connectionString = "Host=mydb.postgres.database.azure.com;Port=5432;Database=postgres;SSL Mode=Require;";  // No Username or Password
var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
dataSourceBuilder.UseEntraAuthentication();
dataSourceBuilder.UseVector();
var dataSource = dataSourceBuilder.Build();

var vectorStore = new PostgresVectorStore(dataSource, ownsDataSource: true);
```

By default, the `UseEntraAuthentication` method uses the [DefaultAzureCredential](/dotnet/api/azure.identity.defaultazurecredential) to authenticate with Azure AD. You can also provide a custom `TokenCredential` implementation if needed.