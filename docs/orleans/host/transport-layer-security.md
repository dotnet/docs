---
title: Transport Layer Security (TLS)
description: Learn how to configure Transport Layer Security (TLS) in .NET Orleans to secure network communication between hosts.
ms.date: 10/28/2025
ms.topic: how-to
ai-usage: ai-assisted
---

# Transport Layer Security (TLS)

Transport Layer Security (TLS) is a cryptographic protocol that secures network communication between Orleans silos and clients. Configure TLS to implement mutual authentication and encrypt data in transit, protecting your Orleans deployment from unauthorized access and eavesdropping.

## Prerequisites

Before configuring TLS, ensure you have:

- An Orleans application with the [Microsoft.Orleans.Server](https://www.nuget.org/packages/Microsoft.Orleans.Server) NuGet package installed for silos.
- The [Microsoft.Orleans.Client](https://www.nuget.org/packages/Microsoft.Orleans.Client) NuGet package installed for clients.
- The [Microsoft.Orleans.Connections.Security](https://www.nuget.org/packages/Microsoft.Orleans.Connections.Security) NuGet package installed for both silos and clients.
- A valid X.509 certificate for authentication, either in the Windows certificate store or as a file.

## Configure TLS on silos

To enable TLS on an Orleans silo, use the <xref:Orleans.Hosting.OrleansConnectionSecurityHostingExtensions.UseTls%2A> extension method. This method provides several overloads for different certificate configuration scenarios.

### Basic TLS configuration

The following example shows how to configure TLS using a certificate from the Windows certificate store:

:::code language="csharp" source="./snippets/transport-layer-security/csharp/SiloExample/Program.cs" id="BasicTlsConfiguration":::
:::code language="vb" source="./snippets/transport-layer-security/vb/SiloExample/Program.vb" id="BasicTlsConfiguration":::

In the preceding code:

- The `StoreName.My` parameter specifies the certificate store location (Personal certificates).
- The `"my-certificate-subject"` parameter identifies the certificate by its subject name.
- The `allowInvalid: false` parameter ensures that only valid certificates are accepted in production.
- The `StoreLocation.CurrentUser` parameter specifies the certificate store scope.
- The `OnAuthenticateAsClient` callback sets the target host for client authentication.

### Development environment configuration

For development and testing, you might need to use self-signed certificates. The following example shows how to configure TLS with relaxed validation for development:

:::code language="csharp" source="./snippets/transport-layer-security/csharp/SiloExample/Program.cs" id="DevelopmentTlsConfiguration":::
:::code language="vb" source="./snippets/transport-layer-security/vb/SiloExample/Program.vb" id="DevelopmentTlsConfiguration":::

In the preceding code:

- The `isDevelopment` flag determines whether to use relaxed certificate validation.
- The <xref:Orleans.Connections.Security.TlsOptions.AllowAnyRemoteCertificate%2A> method disables certificate validation in development.

> [!WARNING]
> Never use `AllowAnyRemoteCertificate()` or `allowInvalid: true` in production deployments. These settings disable important security checks and expose your application to security vulnerabilities.

### Certificate file configuration

If you have a certificate file instead of using the certificate store, configure TLS as shown in the following example:

:::code language="csharp" source="./snippets/transport-layer-security/csharp/SiloExample/Program.cs" id="CertificateTlsConfiguration":::
:::code language="vb" source="./snippets/transport-layer-security/vb/SiloExample/Program.vb" id="CertificateTlsConfiguration":::

In the preceding code:

- The <xref:System.Security.Cryptography.X509Certificates.X509CertificateLoader.LoadPkcs12FromFile%2A> method loads a certificate from a PKCS#12 file (PFX format).
- The certificate is passed directly to the `UseTls` method.

### Advanced TLS configuration

For production deployments, you might need more control over certificate validation and protocol selection. The following example demonstrates advanced TLS configuration:

:::code language="csharp" source="./snippets/transport-layer-security/csharp/SiloExample/Program.cs" id="AdvancedTlsConfiguration":::
:::code language="vb" source="./snippets/transport-layer-security/vb/SiloExample/Program.vb" id="AdvancedTlsConfiguration":::

In the preceding code:

- The <xref:Orleans.Connections.Security.TlsOptions.LocalServerCertificateSelector%2A> callback dynamically selects the appropriate server certificate.
- The <xref:Orleans.Connections.Security.TlsOptions.RemoteCertificateValidation%2A> callback provides custom validation logic for remote certificates.
- The <xref:Orleans.Connections.Security.TlsOptions.CheckCertificateRevocation%2A> property enables certificate revocation checking.

## Configure TLS on clients

Orleans clients require similar TLS configuration to securely connect to TLS-enabled silos.

### Basic client TLS configuration

The following example shows how to configure TLS on an Orleans client:

:::code language="csharp" source="./snippets/transport-layer-security/csharp/ClientExample/Program.cs" id="BasicClientTlsConfiguration":::
:::code language="vb" source="./snippets/transport-layer-security/vb/ClientExample/Program.vb" id="BasicClientTlsConfiguration":::

In the preceding code:

- The <xref:Orleans.Hosting.OrleansConnectionSecurityClientBuilderExtensions.UseTls%2A> extension method configures TLS for the client.
- The <xref:Orleans.Connections.Security.TlsOptions.OnAuthenticateAsServer%2A> callback configures server authentication options.
- The `ClientCertificateRequired` property enables mutual TLS by requiring the client to present a certificate.

### Development client configuration

For development environments, configure the client with relaxed validation as shown in the following example:

:::code language="csharp" source="./snippets/transport-layer-security/csharp/ClientExample/Program.cs" id="ClientDevelopmentTlsConfiguration":::
:::code language="vb" source="./snippets/transport-layer-security/vb/ClientExample/Program.vb" id="ClientDevelopmentTlsConfiguration":::

### Certificate file client configuration

Configure a client using a certificate file as shown in the following example:

:::code language="csharp" source="./snippets/transport-layer-security/csharp/ClientExample/Program.cs" id="ClientCertificateTlsConfiguration":::
:::code language="vb" source="./snippets/transport-layer-security/vb/ClientExample/Program.vb" id="ClientCertificateTlsConfiguration":::

## Best practices

Follow these best practices when configuring TLS in Orleans:

- **Use the latest TLS protocol**: Always prefer TLS 1.2 or TLS 1.3 for the strongest security. Avoid TLS 1.0 and TLS 1.1, which have known vulnerabilities.
- **Let the OS choose the protocol version**: Don't explicitly set TLS protocol versions in production code. Instead, defer to operating system defaults to automatically select the best protocol. Only explicitly set protocol versions if you have a specific compatibility requirement with legacy systems. When you explicitly set protocol versions, your application can't automatically benefit from newer protocols added in future OS updates.
- **Validate certificates**: Always validate certificate chains, expiration dates, and hostname matches in production. Never use `AllowAnyRemoteCertificate()` or disable certificate validation outside of development environments.
- **Enable certificate revocation checking**: Use <xref:Orleans.Connections.Security.TlsOptions.CheckCertificateRevocation%2A> to verify that certificates haven't been revoked.
- **Use strong certificates**: Ensure your X.509 certificates use strong key lengths (at least 2048 bits for RSA) and are signed by a trusted Certificate Authority (CA).
- **Secure certificate storage**: Protect private keys with appropriate file permissions or by using hardware security modules (HSMs).
- **Keep certificates current**: Monitor certificate expiration dates and renew certificates before they expire.
- **Keep software updated**: Regularly update your .NET runtime and operating system to receive the latest security patches and protocol support.

For more information on .NET TLS best practices, see [Transport Layer Security (TLS) best practices with .NET](../../framework/network-programming/tls.md) and [TLS/SSL best practices](../../core/extensions/sslstream-best-practices.md).

## See also

- [Client configuration](configuration-guide/client-configuration.md)
- [Server configuration](configuration-guide/server-configuration.md)
- <xref:Orleans.Connections.Security.TlsOptions>
- <xref:Orleans.Hosting.OrleansConnectionSecurityHostingExtensions.UseTls%2A>
- [Orleans Transport Layer Security (TLS) sample](/samples/dotnet/samples/orleans-transport-layer-security-tls/)
