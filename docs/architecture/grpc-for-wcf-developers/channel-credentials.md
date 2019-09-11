---
title: Channel credentials - gRPC for WCF Developers
description: How to implement and use gRPC channel credentials in ASP.NET Core 3.0
author: markrendle
ms.date: 09/02/2019
---

# Channel credentials

Channel credentials are, as the name implies, attached to the underlying gRPC channel. The standard form of channel credentials uses Client Certificate authentication, where the client provides an SSL/TLS certificate when making the connection, which is verified by the server before allowing any calls to be made.

Channel credentials can be combined with call credentials to provide comprehensive security for a gRPC service. The channel credentials prove that the client application is permitted to access the service, and the call credentials provide information about the person using the client application.

Client certificate authentication works for gRPC the same way it works for ASP.NET Core. The configuration process will be summarized here, but more information is available in the [Microsoft Docs](https://docs.microsoft.com/aspnet/core/security/authentication/certauth?view=aspnetcore-3.0).

For development purposes you can use a self-signed certificate, but for production you should use a proper HTTPS certificate signed by a trusted authority.

## Adding certificate authentication to the server

Certificate authentication needs to be configured both at the host level, for example on the Kestrel server, and in the ASP.NET Core pipeline.

### Configuring certificate validation on Kestrel

Kestrel (the ASP.NET Core HTTP server) can be configured to require a client certificate, and optionally to carry out some validation of the supplied certificate before accepting incoming connections. This configuration is done in the `CreateWebHostBuilder` method of the `Program` class, rather than in `Startup`.

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            var serverCert = ObtainServerCertificate();
            webBuilder.UseStartup<Startup>()
                .ConfigureKestrel(kestrelServerOptions => {
                    kestrelServerOptions.ConfigureHttpsDefaults(opt =>
                    {
                        opt.ClientCertificateMode = ClientCertificateMode.RequireCertificate;

                        // Verify that client certificate was issued by same CA as server certificate
                        opt.ClientCertificateValidation = (certificate, chain, errors) =>
                            certificate.Issuer == serverCert.Issuer;
                    });
                });
        });

```

The `ClientCertificateMode.RequireCertificate` setting will cause Kestrel to immediately reject any connection request that does not provide a client certificate, but it will not validate the certificate. Adding the `ClientCertificateValidation` callback enables Kestrel to validate the client certificate (in this case, ensuring that it was issued by the same *Certificate Authority* as the server certificate) at the point the connection is made, before the ASP.NET Core pipeline is engaged.

### Adding ASP.NET Core certificate authentication

Certificate authentication is provided by the Microsoft.AspNetCore.Authentication.Certificate package ([www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Certificate](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Certificate)).

Add the Certificate authentication service in `ConfigureServices`, and add Authentication and Authorization to the ASP.NET Core pipeline in `Configure`.

```csharp
public class Startup
{
    private readonly bool _isDevelopment;

    public Startup(IWebHostEnvironment env)
    {
        _isDevelopment = env.IsDevelopment();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
            .AddCertificate(options =>
            {
                if (_isDevelopment)
                {
                    // DO NOT DO THIS IN PRODUCTION!
                    options.RevocationMode = X509RevocationMode.NoCheck;
                }
            });
        services.AddAuthorization();
        services.AddGrpc();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapGrpcService<GreeterService>(); });
    }

}
```

## Providing channel credentials in the client application

With the Grpc.Net.Client package, certificates are configured on an `HttpClient` instance that is provided to the `GrpcChannel` used for the connection.

```csharp
class Program
{
    static async Task Main(string[] args)
    {
        // Assume path to client .pfx file and password are passed from command line
        var cert = new X509Certificate2(args[0], args[1]);

        var handler = new HttpClientHandler();
        handler.ClientCertificates.Add(cert);
        var httpClient = new HttpClient(handler);

        var channel = GrpcChannel.ForAddress("https://localhost:5001/", new GrpcChannelOptions
        {
            HttpClient = httpClient
        });

        var grpc = new Greeter.GreeterClient(channel);
        var response = await grpc.SayHelloAsync(new HelloRequest { Name = "Bob" });
        System.Console.WriteLine(response.Message);
    }
}
```

## Combining ChannelCredentials and CallCredentials

You can configure your server to use both certificate and token authentication by applying the certificate changes to the Kestrel server and using the JWT bearer middleware in ASP.NET Core.

To provide both ChannelCredentials and CallCredentials on the client, use the `ChannelCredentials.Create` method to apply the call credentials. Certificate authentication still needs to be applied using the `HttpClient` instance: if you pass any arguments to the `SslCredentials` constructor the internal client code will throw an exception. The `SslCredentials` parameter is only included in the `Grpc.Net.Client` package's `Create` method to maintain compatibility with the `Grpc.Core` package.

```csharp
var handler = new HttpClientHandler();
handler.ClientCertificates.Add(cert);

var httpClient = new HttpClient(handler);

var callCredentials = CallCredentials.FromInterceptor(((context, metadata) =>
    {
        metadata.Add("Authorization", $"Bearer {_token}");
    }));

var channelCredentials = ChannelCredentials.Create(new SslCredentials(), callCredentials);

var channel = GrpcChannel.ForAddress("https://localhost:5001/", new GrpcChannelOptions
{
    HttpClient = httpClient,
    Credentials = channelCredentials
});

var grpc = new Portfolios.PortfoliosClient(channel);
```

> [!TIP]
> You can use this `ChannelCredentials.Create` method for a client without certificate authentication, as a useful way to pass token credentials with every call made on the channel.

>[!div class="step-by-step"]
<!-->[Next](encryption.md)-->
