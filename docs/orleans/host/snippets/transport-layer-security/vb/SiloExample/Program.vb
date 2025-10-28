Imports System

Imports System.Net
Imports System.Net.Security
Imports System.Security.Authentication
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Extensions.Hosting
Imports Microsoft.Extensions.Logging
Imports Orleans.Connections.Security
Imports Orleans.Hosting

Module Program
    ' <BasicTlsConfiguration>
    Sub Main(args As String())
        Dim hostBuilder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
        hostBuilder.UseOrleans(Sub(builder)
                                   builder _
                                       .UseLocalhostClustering() _
                                       .UseTls(StoreName.My, "my-certificate-subject", allowInvalid:=False, StoreLocation.CurrentUser,
                                           Sub(options)
                                               options.OnAuthenticateAsClient = Sub(connection, sslOptions)
                                                                                    sslOptions.TargetHost = "my-certificate-subject"
                                                                                End Sub
                                           End Sub)
                               End Sub)
        hostBuilder.ConfigureLogging(Sub(logging) logging.AddConsole())
        Dim host = hostBuilder.Build()

        host.RunAsync().Wait()
    End Sub
    ' </BasicTlsConfiguration>
End Module

Class DevelopmentExample
    ' <DevelopmentTlsConfiguration>
    Public Shared Async Function ConfigureDevelopmentTls() As Task
        Dim isDevelopment As Boolean = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") = "Development"

        Dim hostBuilder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
        hostBuilder.UseOrleans(Sub(builder)
                                   builder _
                                       .UseLocalhostClustering() _
                                       .UseTls(StoreName.My, "localhost", allowInvalid:=isDevelopment, StoreLocation.CurrentUser,
                                           Sub(options)
                                               options.OnAuthenticateAsClient = Sub(connection, sslOptions)
                                                                                    sslOptions.TargetHost = "localhost"
                                                                                End Sub

                                               If isDevelopment Then
                                                   options.AllowAnyRemoteCertificate()
                                               End If
                                           End Sub)
                               End Sub)
        hostBuilder.ConfigureLogging(Sub(logging) logging.AddConsole())
        Dim host = hostBuilder.Build()

        Await host.RunAsync()
        host.Dispose()
    End Function
    ' </DevelopmentTlsConfiguration>
End Class

Class CertificateExample
    ' <CertificateTlsConfiguration>
    Public Shared Async Function ConfigureTlsWithCertificate() As Task
        Dim cert As X509Certificate2 = X509CertificateLoader.LoadPkcs12FromFile("path/to/certificate.pfx", "password")
        
        Dim hostBuilder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
        hostBuilder.UseOrleans(Sub(builder)
                                   builder _
                                       .UseLocalhostClustering() _
                                       .UseTls(cert,
                                           Sub(options)
                                               options.OnAuthenticateAsClient = Sub(connection, sslOptions)
                                                                                    sslOptions.TargetHost = cert.GetNameInfo(X509NameType.DnsName, False)
                                                                                End Sub
                                           End Sub)
                               End Sub)
        hostBuilder.ConfigureLogging(Sub(logging) logging.AddConsole())
        Dim host = hostBuilder.Build()

        Await host.RunAsync()
        host.Dispose()
        cert.Dispose()
    End Function
    ' </CertificateTlsConfiguration>
End Class

Class AdvancedExample
    ' <AdvancedTlsConfiguration>
    Public Shared Async Function ConfigureAdvancedTls() As Task
        Dim hostBuilder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
        hostBuilder.UseOrleans(Sub(builder)
                                   builder _
                                       .UseLocalhostClustering() _
                                       .UseTls(StoreName.My, "my-certificate-subject", allowInvalid:=False, StoreLocation.LocalMachine,
                                           Sub(options)
                                               options.LocalServerCertificateSelector = Function(sender, serverName)
                                                                                            Using store As New X509Store(StoreName.My, StoreLocation.LocalMachine)
                                                                                                store.Open(OpenFlags.ReadOnly)
                                                                                                Dim certs = store.Certificates.Find(X509FindType.FindBySubjectName, If(serverName, "my-certificate-subject"), validOnly:=True)
                                                                                                Return If(certs.Count > 0, certs(0), Nothing)
                                                                                            End Using
                                                                                        End Function

                                               options.RemoteCertificateValidation = Function(certificate, chain, sslPolicyErrors)
                                                                                         If sslPolicyErrors = SslPolicyErrors.None Then
                                                                                             Return True
                                                                                         End If

                                                                                         Return False
                                                                                     End Function

                                               options.OnAuthenticateAsClient = Sub(connection, sslOptions)
                                                                                    sslOptions.TargetHost = "my-certificate-subject"
                                                                                End Sub

                                               options.CheckCertificateRevocation = True
                                           End Sub)
                               End Sub)
        hostBuilder.ConfigureLogging(Sub(logging) logging.AddConsole())
        Dim host = hostBuilder.Build()

        Await host.RunAsync()
        host.Dispose()
    End Function
    ' </AdvancedTlsConfiguration>
End Class
