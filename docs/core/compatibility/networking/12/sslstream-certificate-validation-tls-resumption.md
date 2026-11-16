---
title: "Breaking change - SslStream skips certificate validation on resumed TLS sessions"
description: "Learn about the breaking change in .NET 12 where SslStream skips peer certificate validation on resumed initial TLS handshakes on Windows and Linux."
ms.date: 10/13/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/56298
---

# SslStream skips certificate validation on resumed TLS sessions

In .NET 12, <xref:System.Net.Security.SslStream> doesn't rebuild the peer certificate chain or invoke the configured <xref:System.Net.Security.RemoteCertificateValidationCallback> during a resumed initial TLS handshake on Windows and Linux by default.

## Version introduced

.NET 12 Preview 1

## Previous behavior

Previously, `SslStream` rebuilt the peer certificate chain and invoked the configured `RemoteCertificateValidationCallback` for every successful handshake, including resumed TLS sessions.

## New behavior

Starting in .NET 12, `SslStream` skips the peer certificate chain rebuild and remote-certificate validation callback during a resumed initial TLS handshake on Windows and Linux by default. The original full handshake still validates the certificate and invokes the configured callback.

The <xref:System.Net.Security.SslStream.RemoteCertificate> property remains populated with the certificate cached from the original full handshake.

Because the TLS backends on Apple platforms and Android don't provide a reliable resumption signal, certificate validation continues to run on resumed connections on those platforms.

The change applies only to resumed initial handshakes. Renegotiation and TLS 1.3 post-handshake authentication still fully validate a newly presented peer certificate.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

During a resumed, abbreviated TLS handshake, the peer doesn't resend its certificate. The original full handshake already established and validated the peer's identity. To avoid repeated work and allocations and align with common TLS implementations, `SslStream` skips repeated certificate-chain construction and callback invocation.

For implementation details, see [dotnet/runtime#133174](https://github.com/dotnet/runtime/pull/133174).

## Recommended action

Don't use `RemoteCertificateValidationCallback` as a per-connection notification for resumed TLS sessions. Perform authorization and connection-specific checks independently of the callback.

To restore the previous behavior, enable the `System.Net.Security.RevalidateCertificateOnTlsResume` <xref:System.AppContext> switch at startup, before any TLS handshakes:

```csharp
AppContext.SetSwitch(
    "System.Net.Security.RevalidateCertificateOnTlsResume",
    isEnabled: true);
```

Alternatively, set the `DOTNET_SYSTEM_NET_SECURITY_REVALIDATECERTIFICATEONTLSRESUME` environment variable to `1` before the process starts. Either setting restores the certificate chain rebuild and remote-certificate validation callback on resumed handshakes.

To disable TLS resumption instead, set <xref:System.Net.Security.SslClientAuthenticationOptions.AllowTlsResume> or <xref:System.Net.Security.SslServerAuthenticationOptions.AllowTlsResume> to `false` on the authentication options.

## Affected APIs

- <xref:System.Net.Security.SslStream.AuthenticateAsClient*>
- <xref:System.Net.Security.SslStream.AuthenticateAsClientAsync*>
- <xref:System.Net.Security.SslStream.AuthenticateAsServer*>
- <xref:System.Net.Security.SslStream.AuthenticateAsServerAsync*>
- <xref:System.Net.Security.SslClientAuthenticationOptions.RemoteCertificateValidationCallback>
- <xref:System.Net.Security.SslServerAuthenticationOptions.RemoteCertificateValidationCallback>
