// <Limitations>
NpgsqlDataSourceBuilder dataSourceBuilder = new("Host=localhost;Port=5432;Username=postgres;Password=example;Database=postgres;");
dataSourceBuilder.UseVector();
NpgsqlDataSource dataSource = dataSourceBuilder.Build();
// </Limitations>

// <GetStarted1>
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddPostgresVectorStore("<Connection String>");
// </GetStarted1>

// <GetStarted2>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPostgresVectorStore("<Connection String>");
// </GetStarted2>

// <GetStarted3>
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
// </GetStarted3>

// <GetStarted4>
using Microsoft.SemanticKernel.Connectors.PgVector;
using Npgsql;

NpgsqlDataSourceBuilder dataSourceBuilder = new("<Connection String>");
dataSourceBuilder.UseVector();
NpgsqlDataSource dataSource = dataSourceBuilder.Build();
var vectorStore = new PostgresVectorStore(dataSource, ownsDataSource: true);
// </GetStarted4>

// <GetStarted5>
using Microsoft.SemanticKernel.Connectors.PgVector;

var connection = new PostgresVectorStore("<Connection String>");
// </GetStarted5>

// <GetStarted6>
using Microsoft.SemanticKernel.Connectors.PgVector;
using Npgsql;

NpgsqlDataSourceBuilder dataSourceBuilder = new("<Connection String>");
dataSourceBuilder.UseVector();
var dataSource = dataSourceBuilder.Build();

var collection = new PostgresCollection<string, Hotel>(dataSource, "skhotels", ownsDataSource: true);
// </GetStarted6>

// <GetStarted7>
using Microsoft.SemanticKernel.Connectors.PgVector;

var collection = new PostgresCollection<string, Hotel>("<Connection String>", "skhotels");
// </GetStarted7>

// <PropertyNameOverride>
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
// </PropertyNameOverride>

// <UseWithEntraAuthentication1>
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
// </UseWithEntraAuthentication1>

// <UseWithEntraAuthentication2>
using Microsoft.SemanticKernel.Connectors.Postgres;

var connectionString = "Host=mydb.postgres.database.azure.com;Port=5432;Database=postgres;SSL Mode=Require;";  // No Username or Password
var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
dataSourceBuilder.UseEntraAuthentication();
dataSourceBuilder.UseVector();
var dataSource = dataSourceBuilder.Build();

var vectorStore = new PostgresVectorStore(dataSource, ownsDataSource: true);
// </UseWithEntraAuthentication2>