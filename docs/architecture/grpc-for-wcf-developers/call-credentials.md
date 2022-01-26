---
title: Call credentials - gRPC for WCF Developers
description: How to implement and use gRPC call credentials in ASP.NET Core 3.0.
ms.date: 12/14/2021
---

# Call credentials

Call credentials are all based on a token passed in metadata with each request.

## WS-Federation

ASP.NET Core supports WS-Federation using the [WsFederation](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.WsFederation) NuGet package. WS-Federation is the closest available alternative to Windows Authentication, which isn't supported over HTTP/2. Users are authenticated by using Active Directory Federation Services (AD FS), which provides a token that can be used to authenticate with ASP.NET Core.

For more information on how to get started with this authentication method, see [Authenticate users with WS-Federation in ASP.NET Core](/aspnet/core/security/authentication/ws-federation).

## JWT Bearer tokens

The [JSON Web Token](https://jwt.io) (JWT) standard provides a way to encode information about a user and their claims in an encoded string. It also provides a way to sign that token, so that the consumer can verify the integrity of the token by using public key cryptography. You can use various services, such as IdentityServer4, to authenticate users and generate OpenID Connect (OIDC) tokens to use with gRPC and HTTP APIs.

ASP.NET Core 6.0 can handle JWTs by using the JWT Bearer package. The configuration is exactly the same for a gRPC application as it is for an ASP.NET Core MVC application. Here, we'll focus on JWT Bearer tokens, because they're easier to develop with than WS-Federation.

## Add authentication and authorization to the server

The JWT Bearer package isn't included in ASP.NET Core 6.0 by default. Install the [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer) NuGet package in your app.

Add the Authentication service in the _Program.cs_ class, and configure the JWT Bearer handler:

```csharp
//
//
builder.Services.AddGrpc();

var signingKey = ObtainSigningKeySomehow();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateActor = false,
                ValidateLifetime = true,
                IssuerSigningKey = signingKey
            };
    });
//
//
```

The `IssuerSigningKey` property requires an implementation of `Microsoft.IdentityModels.Tokens.SecurityKey` with the cryptographic data necessary to validate the signed tokens. Store this token securely in a *secrets server*, like Azure Key Vault.

Next, add the Authorization service, which controls access to the system:

```csharp
    services.AddAuthorization(options =>
    {
        options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
        {
            policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
            policy.RequireClaim(ClaimTypes.Name);
        });
    });

```

> [!TIP]
> Authentication and authorization are two separate steps. You use authentication to determine the user's identity. You use authorization to decide whether that user is allowed to access various parts of the system.

Now add the authentication and authorization middleware to the ASP.NET Core pipeline in the _Program.cs_:

```csharp
//
    app.UseRouting();

    // Authenticate, then Authorize
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGrpcService<PortfolioService>();
    });
}
```

Finally, apply the `[Authorize]` attribute to any services or methods to be secured, and use the `User` property from the underlying `HttpContext` to verify permissions.

```csharp
[Authorize]
public override async Task<GetResponse> Get(GetRequest request, ServerCallContext context)
{
    if (!TryValidateUser(request.TraderId, context.GetHttpContext().User))
    {
        throw new RpcException(new Status(StatusCode.PermissionDenied, "Denied."));
    }

    var portfolio = await _repository.GetAsync(traderId, request.PortfolioId);

    return new GetResponse
    {
        Portfolio = Portfolio.FromRepositoryModel(portfolio)
    };
}
```

## Provide call credentials in the client application

After you've obtained a JWT token from an identity server, you can use it to authenticate gRPC calls from the client by adding it as a metadata header on the call, as follows:

```csharp
public async Task ShowPortfolioAsync(int portfolioId)
{
    var headers = new Grpc.Core.Metadata
    {
        { "Authorization", $"Bearer {_userToken}" }
    };
    var request = new GetRequest
    {
        TraderId = _userId,
        PortfolioId = portfolioId
    };
    var response = await _portfoliosClient.GetAsync(request, headers);

    // Display portfolio
}
```

Now you've secured your gRPC service by using JWT bearer tokens as call credentials. A version of the [portfolios sample gRPC application with authentication and authorization added](https://github.com/dotnet-architecture/grpc-for-wcf-developers/tree/main/PortfoliosSample/grpc/TraderSysAuth) is on GitHub.

>[!div class="step-by-step"]
>[Previous](security.md)
>[Next](channel-credentials.md)
