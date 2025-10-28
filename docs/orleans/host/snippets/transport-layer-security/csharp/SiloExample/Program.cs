using System.Net;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Connections.Security;
using Orleans.Hosting;

// <BasicTlsConfiguration>
using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleans(builder =>
    {
        builder
            .UseLocalhostClustering()
            .UseTls(StoreName.My, "my-certificate-subject", allowInvalid: false, StoreLocation.CurrentUser, options =>
            {
                options.OnAuthenticateAsClient = (connection, sslOptions) =>
                {
                    sslOptions.TargetHost = "my-certificate-subject";
                };
            });
    })
    .ConfigureLogging(logging => logging.AddConsole())
    .Build();

await host.RunAsync();
// </BasicTlsConfiguration>

class DevelopmentExample
{
    public static async Task ConfigureDevelopmentTls()
    {
        // <DevelopmentTlsConfiguration>
        var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

        using IHost host = Host.CreateDefaultBuilder()
            .UseOrleans(builder =>
            {
                builder
                    .UseLocalhostClustering()
                    .UseTls(StoreName.My, "localhost", allowInvalid: isDevelopment, StoreLocation.CurrentUser, options =>
                    {
                        options.OnAuthenticateAsClient = (connection, sslOptions) =>
                        {
                            sslOptions.TargetHost = "localhost";
                        };

                        if (isDevelopment)
                        {
                            options.AllowAnyRemoteCertificate();
                        }
                    });
            })
            .ConfigureLogging(logging => logging.AddConsole())
            .Build();

        await host.RunAsync();
        // </DevelopmentTlsConfiguration>
    }
}

class CertificateExample
{
    public static async Task ConfigureTlsWithCertificate()
    {
        // <CertificateTlsConfiguration>
        using var cert = X509CertificateLoader.LoadPkcs12FromFile("path/to/certificate.pfx", "password");

        using IHost host = Host.CreateDefaultBuilder()
            .UseOrleans(builder =>
            {
                builder
                    .UseLocalhostClustering()
                    .UseTls(cert, options =>
                    {
                        options.OnAuthenticateAsClient = (connection, sslOptions) =>
                        {
                            sslOptions.TargetHost = cert.GetNameInfo(X509NameType.DnsName, false);
                        };
                    });
            })
            .ConfigureLogging(logging => logging.AddConsole())
            .Build();

        await host.RunAsync();
        // </CertificateTlsConfiguration>
    }
}

class AdvancedExample
{
    public static async Task ConfigureAdvancedTls()
    {
        // <AdvancedTlsConfiguration>
        using IHost host = Host.CreateDefaultBuilder()
            .UseOrleans(builder =>
            {
                builder
                    .UseLocalhostClustering()
                    .UseTls(StoreName.My, "my-certificate-subject", allowInvalid: false, StoreLocation.LocalMachine, options =>
                    {
                        options.LocalServerCertificateSelector = (sender, serverName) =>
                        {
                            using var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                            store.Open(OpenFlags.ReadOnly);
                            var certs = store.Certificates.Find(X509FindType.FindBySubjectName, serverName ?? "my-certificate-subject", validOnly: true);
                            return certs.Count > 0 ? certs[0] : null;
                        };

                        options.RemoteCertificateValidation = (certificate, chain, sslPolicyErrors) =>
                        {
                            if (sslPolicyErrors == SslPolicyErrors.None)
                            {
                                return true;
                            }

                            return false;
                        };

                        options.OnAuthenticateAsClient = (connection, sslOptions) =>
                        {
                            sslOptions.TargetHost = "my-certificate-subject";
                        };

                        options.CheckCertificateRevocation = true;
                    });
            })
            .ConfigureLogging(logging => logging.AddConsole())
            .Build();

        await host.RunAsync();
        // </AdvancedTlsConfiguration>
    }
}
