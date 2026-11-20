---
title: Troubleshoot SslStream authentication issues
description: Learn how to troubleshoot and investigate issues when performing authentication with SslStream in .NET.
author: rzikm
ms.author: radekzikmund
ms.date: 08/24/2026
ai-usage: ai-assisted
---

# Troubleshoot `SslStream` authentication issues

This article presents the most frequent authentication issues when using <xref:System.Net.Security.SslStream> cryptography- and security-related functionalities in .NET are implemented by interop with either the OS API (such as Schannel on Windows) or low-level system libraries (like OpenSSL on Linux). The behavior of .NET application, including exception messages and error codes may therefore change depending on which platform it is run.

Some issues may be easier to investigate and troubleshoot by observing the actual messages exchanged over the wire using tools such as [Wireshark](https://www.wireshark.org) or [tcpdump](https://www.tcpdump.org). These tools can be used to inspect the `ClientHello`, `ServerHello`, and other messages for advertised supported TLS versions allowed and negotiated cipher suites and the certificates exchanged for authentication.

## Intermediate certificates are not sent

During the TLS handshake, the server (and the client too, if client authentication is requested) sends its certificate to prove its identity to the client. In order to validate the authenticity of the certificate, a chain of certificates needs to be built and verified. The root of the chain must be one of the trusted root certificate authority (CA), the certificate of which is stored in the machine certificate store.

If the peer certificate hasn't been issued by one of the trusted CAs an intermediate CA certificate is necessary to build the certificate chain. However, if the intermediate certificate isn't available, it isn't possible to validate the certificate and the TLS handshake may fail.

This issue is most frequently encountered on Windows. Even though the application provided intermediate certificates via the authentication options, they will not be sent to the peer unless they are stored in the Windows certificate store. This limitation is due to the fact that the actual TLS handshake occurs outside of the application process.

For server applications, it is possible to pass an <xref:System.Net.Security.SslStreamCertificateContext> as <xref:System.Net.Security.SslServerAuthenticationOptions.ServerCertificateContext?displayProperty=nameWithType>. During construction of the <xref:System.Net.Security.SslStreamCertificateContext> instance, you can pass additional intermediate certificates and these will be temporarily added into the certificate store.

Unfortunately, for client application the only solution is to add the certificates to the certificate store manually.

## Handshake failed with ephemeral keys

On Windows, you may encounter the `(0x8009030E): No credentials are available in the security package` error message when attempting to use certificates with ephemeral keys. This behavior is due to a bug in the underlying OS API (Schannel). More relevant info and workarounds can be found on the associated [GitHub issue](https://github.com/dotnet/runtime/issues/23749).

## Handshake message exceeds the Schannel limit

On Windows, you might hit a handshake failure when a fragmented TLS handshake message exceeds the size limit that Schannel enforces. In this case, `SslStream` surfaces an <xref:System.Security.Authentication.AuthenticationException> whose inner <xref:System.ComponentModel.Win32Exception> reports error `0x80090326` (`SEC_E_ILLEGAL_MESSAGE`) and the message `The message received was unexpected or badly formatted`. You're most likely to produce large handshake messages when you use large certificate chains or when a peer sends a long list of acceptable certificate issuers during mutual TLS authentication.

Because this error isn't specific to message size, confirm the cause before you change any Schannel configuration. Use a packet-capture tool to inspect the handshake messages and their sizes.

If the capture confirms that a handshake message exceeds the limit, ask an administrator to create one of the following `DWORD` values under `HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Messaging`:

| Value | Applies to | Default |
| --- | --- | --- |
| `MessageLimitClient` | Messages that a TLS client accepts. | `0x8000` bytes |
| `MessageLimitServer` | Messages that a TLS server accepts when it doesn't use client authentication. | `0x4000` bytes |
| `MessageLimitServerClientAuth` | Messages that a TLS server accepts when it uses client authentication. | `0x8000` bytes |

Set the smallest value that accepts the expected handshake message. Schannel supports values up to `0x10000` bytes. Don't change these settings unless you've confirmed the cause, because they affect the entire machine and larger limits increase memory use for each security context. For more information and registry-editing precautions, see [Messaging - fragment parsing](/windows-server/security/tls/tls-registry-settings#messaging--fragment-parsing).

## Client and server do not possess a common algorithm

When inspecting the `ClientHello` and `ServerHello` messages, you may find out that there is no cipher suite offered by both client and server or even that some ciphers are not offered even if explicitly configured via <xref:System.Net.Security.CipherSuitesPolicy> (available on Linux only). The underlying TLS library may disable TLS versions and cipher suites which are considered insecure.

On many Linux distributions, the relevant configuration file is located at `/etc/ssl/openssl.cnf`.

On Windows, the [`Enable-TlsCipherSuite`](/powershell/module/tls/enable-tlsciphersuite) and [`Disable-TlsCipherSuite`](/powershell/module/tls/disable-tlsciphersuite) PowerShell cmdlets can be used to configure cipher suites. Individual TLS versions can be enabled/disable by configuring the `HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Protocols\TLS <version>\{Client|Server}\Enabled` registry key.
