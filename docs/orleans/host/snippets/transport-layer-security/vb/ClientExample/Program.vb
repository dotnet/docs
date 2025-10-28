Imports System

Imports System.Security.Authentication
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Extensions.Hosting
Imports Microsoft.Extensions.Logging
Imports Orleans.Connections.Security
Imports Orleans.Hosting

Module Program
    ' <BasicClientTlsConfiguration>
    Sub Main(args As String())
        Dim hostBuilder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
        hostBuilder.UseOrleansClient(Sub(builder)
                                         builder _
                                             .UseLocalhostClustering() _
                                             .UseTls(StoreName.My, "my-certificate-subject", allowInvalid:=False, StoreLocation.CurrentUser,
                                                 Sub(options)
                                                     options.OnAuthenticateAsServer = Sub(connection, sslOptions)
                                                                                          sslOptions.ClientCertificateRequired = True
                                                                                      End Sub
                                                 End Sub)
                                     End Sub)
        hostBuilder.ConfigureLogging(Sub(logging) logging.AddConsole())
        Dim host = hostBuilder.Build()

        host.RunAsync().Wait()
    End Sub
    ' </BasicClientTlsConfiguration>
End Module

Class ClientDevelopmentExample
    ' <ClientDevelopmentTlsConfiguration>
    Public Shared Async Function ConfigureDevelopmentTls() As Task
        Dim isDevelopment As Boolean = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") = "Development"

        Dim hostBuilder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
        hostBuilder.UseOrleansClient(Sub(builder)
                                         builder _
                                             .UseLocalhostClustering() _
                                             .UseTls(StoreName.My, "localhost", allowInvalid:=isDevelopment, StoreLocation.CurrentUser,
                                                 Sub(options)
                                                     If isDevelopment Then
                                                         options.AllowAnyRemoteCertificate()
                                                     End If

                                                     options.OnAuthenticateAsServer = Sub(connection, sslOptions)
                                                                                          sslOptions.ClientCertificateRequired = True
                                                                                      End Sub
                                                 End Sub)
                                     End Sub)
        hostBuilder.ConfigureLogging(Sub(logging) logging.AddConsole())
        Dim host = hostBuilder.Build()

        Await host.RunAsync()
        host.Dispose()
    End Function
    ' </ClientDevelopmentTlsConfiguration>
End Class

Class ClientCertificateExample
    ' <ClientCertificateTlsConfiguration>
    Public Shared Async Function ConfigureTlsWithCertificate() As Task
        Dim cert As X509Certificate2 = X509CertificateLoader.LoadPkcs12FromFile("path/to/certificate.pfx", "password")
        
        Dim hostBuilder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
        hostBuilder.UseOrleansClient(Sub(builder)
                                         builder _
                                             .UseLocalhostClustering() _
                                             .UseTls(cert,
                                                 Sub(options)
                                                     options.OnAuthenticateAsServer = Sub(connection, sslOptions)
                                                                                          sslOptions.ClientCertificateRequired = True
                                                                                      End Sub
                                                 End Sub)
                                     End Sub)
        hostBuilder.ConfigureLogging(Sub(logging) logging.AddConsole())
        Dim host = hostBuilder.Build()

        Await host.RunAsync()
        host.Dispose()
        cert.Dispose()
    End Function
    ' </ClientCertificateTlsConfiguration>
End Class
