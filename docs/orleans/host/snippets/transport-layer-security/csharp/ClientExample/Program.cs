using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Connections.Security;
using Orleans.Hosting;

// <BasicClientTlsConfiguration>
using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(builder =>
    {
        builder
            .UseLocalhostClustering()
            .UseTls(StoreName.My, "my-certificate-subject", allowInvalid: false, StoreLocation.CurrentUser, options =>
            {
                options.OnAuthenticateAsServer = (connection, sslOptions) =>
                {
                    sslOptions.ClientCertificateRequired = true;
                };
            });
    })
    .ConfigureLogging(logging => logging.AddConsole())
    .Build();

await host.RunAsync();
// </BasicClientTlsConfiguration>

class ClientDevelopmentExample
{
    public static async Task ConfigureDevelopmentTls()
    {
        // <ClientDevelopmentTlsConfiguration>
        var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

        using IHost host = Host.CreateDefaultBuilder()
            .UseOrleansClient(builder =>
            {
                builder
                    .UseLocalhostClustering()
                    .UseTls(StoreName.My, "localhost", allowInvalid: isDevelopment, StoreLocation.CurrentUser, options =>
                    {
                        if (isDevelopment)
                        {
                            options.AllowAnyRemoteCertificate();
                        }

                        options.OnAuthenticateAsServer = (connection, sslOptions) =>
                        {
                            sslOptions.ClientCertificateRequired = true;
                        };
                    });
            })
            .ConfigureLogging(logging => logging.AddConsole())
            .Build();

        await host.RunAsync();
        // </ClientDevelopmentTlsConfiguration>
    }
}

class ClientCertificateExample
{
    public static async Task ConfigureTlsWithCertificate()
    {
        // <ClientCertificateTlsConfiguration>
        using var cert = X509CertificateLoader.LoadPkcs12FromFile("path/to/certificate.pfx", "password");

        using IHost host = Host.CreateDefaultBuilder()
            .UseOrleansClient(builder =>
            {
                builder
                    .UseLocalhostClustering()
                    .UseTls(cert, options =>
                    {
                        options.OnAuthenticateAsServer = (connection, sslOptions) =>
                        {
                            sslOptions.ClientCertificateRequired = true;
                        };
                    });
            })
            .ConfigureLogging(logging => logging.AddConsole())
            .Build();

        await host.RunAsync();
        // </ClientCertificateTlsConfiguration>
    }
}
