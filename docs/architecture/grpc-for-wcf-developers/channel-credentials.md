---
title: Channel credentials - gRPC for WCF Developers
description: How to implement and use gRPC channel credentials in ASP.NET Core 3.0.
ms.date: 06/28/2021
---

# Channel credentials

As the name implies, channel credentials are attached to the underlying gRPC channel. The standard form of channel credentials uses client certificate authentication. In this process, the client provides a TLS certificate when it's making the connection, and then the server verifies this certificate before allowing any calls to be made.

You can combine channel credentials with call credentials to provide comprehensive security for a gRPC service. The channel credentials prove that the client application is allowed to access the service, and the call credentials provide information about the person who is using the client application.

Client certificate authentication works for gRPC the same way it works for ASP.NET Core. For more information, see [Configure certificate authentication in ASP.NET Core](/aspnet/core/security/authentication/certauth).

For development purposes you can use a self-signed certificate, but for production you should use a proper HTTPS certificate signed by a trusted authority.

## Add certificate authentication to the server

Configure certificate authentication both at the host level (for example, on the Kestrel server), and in the ASP.NET Core pipeline.

### Configure certificate validation on Kestrel

You can configure Kestrel (the ASP.NET Core HTTP server) to require a client certificate, and optionally to carry out some validation of the supplied certificate, before accepting incoming connections. You specify this configuration in the _Program.cs_:

```csharp
var builder = WebApplication.CreateBuilder(args);
var serverCert = ObtainServerCertificate();
builder.WebHost.UseKestrel(kestrelServerOptions => {
    kestrelServerOptions.ConfigureHttpsDefaults(opt =>
    {
        opt.ClientCertificateMode = ClientCertificateMode.RequireCertificate;

        // Verify that client certificate was issued by same CA as server certificate
        opt.ClientCertificateValidation = (certificate, chain, errors) =>
            certificate.Issuer == serverCert.Issuer;
    });

});
```

The `ClientCertificateMode.RequireCertificate` setting causes Kestrel to immediately reject any connection request that doesn't provide a client certificate, but this setting by itself won't validate a certificate that is provided. Add the `ClientCertificateValidation` callback to enable Kestrel to validate the client certificate at the point the connection is made, before the ASP.NET Core pipeline is engaged. (In this case, the callback ensures that it was issued by the same *Certificate Authority* as the server certificate.)

### Add ASP.NET Core certificate authentication

The [Microsoft.AspNetCore.Authentication.Certificate](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.Certificate) NuGet package provides certificate authentication.

Add the certificate authentication service in the _Program.cs_, and add authentication and authorization to the ASP.NET Core pipeline.

```csharp
//
builder.Services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
            .AddCertificate(options =>
            {
                options.AllowedCertificateTypes = CertificateTypes.Chained;
                options.RevocationMode = X509RevocationMode.NoCheck;

                options.Events = new CertificateAuthenticationEvents
                {
                    OnCertificateValidated = DevelopmentModeCertificateHelper.Validate
                };
            });
builder.Services.AddAuthorization();
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();

app.UseAuthentication();
app.UseEndpoints(endpoints => { endpoints.MapGrpcService<GreeterService>(); });
//
```

## Provide channel credentials in the client application

With the `Grpc.Net.Client` package, you configure certificates on an <xref:System.Net.Http.HttpClient> instance that is provided to the `GrpcChannel` used for the connection.

### Load a client certificate from a .PFX file

A certificate can be loaded from a _.pfx_ file.

```csharp
class Program
{
    static async Task Main(string[] args)
    {
        // Assume path to a client .pfx file and password are passed from command line
        // On Windows this would probably be a reference to the Certificate Store
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

### Load a client certificate from certificate and private key .PEM files

A certificate can be loaded from a certificate and private key _.pem_ file.

```csharp
class Program
{
    static async Task Main(string[] args)
    {
        // Assume path to a certificate and private key .pem files are passed from command line
        string certificatePem = File.ReadAllText(args[0]);
        string privateKeyPem = File.ReadAllText(args[1]);
        var cert = X509Certificate2.CreateFromPem(certificatePem, privateKeyPem);

        var handler = new HttpClientHandler();
        handler.ClientCertificates.Add(cert);
        using HttpClient httpClient = new(handler);

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

> [!NOTE]
> Due to an internal Windows bug as [documented here](https://github.com/dotnet/runtime/issues/23749#issuecomment-388231655), you'll need to apply the following workaround if the certificate is created from a certificate and private key PEM data.
>
> ```csharp
> X509Certificate2 cert = X509Certificate2.CreateFromPem(certificatePem, rsaPrivateKeyPem);
> if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
> {
>     var originalCert = cert;
>     cert = new X509Certificate2(cert.Export(X509ContentType.Pkcs12));
>     originalCert.Dispose();
> }
> ```

## Combine ChannelCredentials and CallCredentials

You can configure your server to use both certificate and token authentication. To do this, apply the certificate changes to the Kestrel server, and use the JWT bearer middleware in ASP.NET Core.

To provide both `ChannelCredentials` and `CallCredentials` on the client, use the `ChannelCredentials.Create` method to apply the call credentials. You still need to apply certificate authentication by using the <xref:System.Net.Http.HttpClient> instance. If you pass any arguments to the `SslCredentials` constructor, the internal client code throws an exception. The `SslCredentials` parameter is only included in the `Grpc.Net.Client` package's `Create` method to maintain compatibility with the `Grpc.Core` package.

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
> You can use the `ChannelCredentials.Create` method for a client without certificate authentication. This is a useful way to pass token credentials with every call made on the channel.

A version of the [FullStockTicker sample gRPC application with certificate authentication added](https://github.com/dotnet-architecture/grpc-for-wcf-developers/tree/main/FullStockTickerSample/grpc/FullStockTickerAuth/FullStockTicker) is on GitHub.

>[!div class="step-by-step"]
>[Previous](call-credentials.md)
>[Next](encryption.md)
