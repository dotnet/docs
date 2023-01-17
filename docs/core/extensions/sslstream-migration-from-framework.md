---
title: Migrate from .NET Framework to .NET
description: Learn how to migrate code using SslStream in .NET Framework to .NET.
author: rzikm
ms.author: radekzikmund
ms.date: 1/9/2023
---

# Migrate from .NET Framework to .NET

.NET Core brought many improvements as well as breaking changes to how <xref:System.Net.Security.SslStream> works. The most important change related to network security is that the <xref:System.Net.ServicePointManager> class has been mostly obsoleted and affects only the legacy <xref:System.Net.WebRequest> interface.

Since .NET, allowed SSL/TLS protocols and certificate validation callbacks must be configured separately for each <xref:System.Net.Security.SslStream> instance via the <xref:System.Net.Security.SslServerAuthenticationOptions> or <xref:System.Net.Security.SslClientAuthenticationOptions>. In order to configure network security options used in HTTPS in <xref:System.Net.Http.HttpClient>, you need to configure the security options in the underlying handler. The default handler used by <xref:System.Net.Http.HttpClient> is <xref:System.Net.Http.SocketsHttpHandler> which has <xref:System.Net.Http.SocketsHttpHandler.SslOptions> property accepting <xref:System.Net.Security.SslClientAuthenticationOptions>.

Consider the following example, as it demonstrates how to create an <xref:System.Net.Http.HttpClient> with a custom certificate validation callback:

```csharp
bool CustomCertificateValidator(
    object sender,
    X509Certificate? certificate,
    X509Chain? chain,
    SslPolicyErrors sslPolicyErrors)
{
    // TODO: Always returns false. 
    // Need to implement certificate evaluation logic.
    return false;
}

HttpClient httpClient = new(
    new SocketsHttpHandler
    {
        SslOptions =
        {
            RemoteCertificateValidationCallback = CustomCertificateValidator
        }
    });
```

Following table show how to migrate individual <xref:System.Net.ServicePointManager> properties related to SSL/TLS.

| Source API | Target API |
|---|---|
| <xref:System.Net.ServicePointManager.CheckCertificateRevocationList> | Set appropriate <xref:System.Security.Cryptography.X509Certificates.X509RevocationMode> on <xref:System.Net.Security.SslClientAuthenticationOptions.CertificateRevocationCheckMode?displayProperty=nameWithType>. |
| <xref:System.Net.ServicePointManager.EncryptionPolicy> | Use <xref:System.Net.Security.SslClientAuthenticationOptions.EncryptionPolicy?displayProperty=nameWithType>. |
| <xref:System.Net.ServicePointManager.SecurityProtocol> | Use <xref:System.Net.Security.SslClientAuthenticationOptions.EnabledSslProtocols?displayProperty=nameWithType>. |
| <xref:System.Net.ServicePointManager.ServerCertificateValidationCallback> | Use <xref:System.Net.Security.SslClientAuthenticationOptions.RemoteCertificateValidationCallback?displayProperty=nameWithType>. |
