---
title: Call credentials - gRPC for WCF Developers
description: How to implement and use gRPC call credentials in ASP.NET Core 3.0
author: markrendle
ms.date: 09/02/2019
---

# Call credentials

Call credentials are all based on some kind of token passed in metadata with each request.

## WS-Federation

ASP.NET Core supports WS-Federation using the [WsFederation](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.WsFederation) package. This is the closest thing to Windows Authentication that is supported over HTTP/2. Users are authenticated using Active Directory Federation Services (ADFS), which provides a token that can be used to authenticate with ASP.NET Core.

For more information on how to get started with this authentication method, please refer to the [Authenticate users with WS-Federation in ASP.NET Core](https://docs.microsoft.com/aspnet/core/security/authentication/ws-federation?view=aspnetcore-3.0) documentation.

## JWT Bearer tokens

The [JSON Web Token](https://jwt.io) standard provides a way to encode information about a user and their claims in an encoded string, and to sign that token in such a way that the consumer can verify the integrity of the token using public key cryptography. You can use various services, such as IdentityServer4, to authenticate users and generate OpenID Connect (OIDC) tokens to use with gRPC and HTTP APIs.

ASP.NET Core 3.0 can handle JSON Web Tokens using the JWT Bearer package. The configuration is exactly the same for a gRPC application as an ASP.NET Core MVC application.

This chapter will focus on JWT Bearer tokens as they are simpler to develop with than WS-Federation.

## Adding authentication and authorization to the server

The JWT Bearer package is not included in ASP.NET Core 3.0 by default; it must be installed from NuGet: [https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer).

Add the Authentication service in the Startup class and configure the JWT Bearer handler.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddGrpc();

    var signingKey = ObtainSigningKeySomehow();

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

}
```

The `IssuerSigningKey` property requires an implementation of `Microsoft.IdentityModels.Tokens.SecurityKey` with the cryptographic data necessary to validate the signed tokens. This token should be stored securely in a *secrets server* like Azure KeyVault.

Next add the Authorization service, which controls access to the system.

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
> Authentication and Authorization are two separate steps. Authentication is used to determine the user's identity. Authorization decides whether that user is allowed to access various parts of the system.

Now add the Authentication and Authorization middleware to the ASP.NET Core pipeline in the `Configure` method.

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

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

## Providing call credentials in the client application

Once you have obtained a JWT token from an identity server, you can use it to authenticate gRPC calls from the client by adding it as a metadata header on the call.

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

You have now secured your gRPC service using JWT bearer tokens as call credentials.

>[!div class="step-by-step"]
<!-->[Next](channel-credentials.md)-->
