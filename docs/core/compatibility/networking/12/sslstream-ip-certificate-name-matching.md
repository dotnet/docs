---
title: "Breaking change - Linux TLS certificate name checks for IP addresses follow Windows rules"
description: "Learn about the breaking change in .NET 12 where Linux TLS certificate name checks for IP address targets follow Windows SAN and CN rules."
ms.date: 11/08/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/runtime/issues/131734
---

# Linux TLS certificate name checks for IP addresses follow Windows rules

Starting in .NET 12, <xref:System.Net.Security.SslStream> on Linux checks server certificate names for IP address targets with the same SAN and CN rules as Windows. Some certificates that previously passed the Linux name check now fail, and some that previously failed now pass.

The change applies when you supply an IPv4 or IPv6 address through <xref:System.Net.Security.SslClientAuthenticationOptions.TargetHost> or a `targetHost` argument to a client authentication method. Windows behavior and certificate name checks for DNS hostname targets don't change.

## Version introduced

.NET 12 Preview 1

## Previous behavior

On Linux, `SslStream` first looked for an `iPAddress` entry in the certificate's Subject Alternative Name (SAN) extension that matched the target address bytes. If no IP SAN matched, it compared the target IP text with the subject Common Name (CN), even if the certificate contained DNS SAN entries. It didn't match an IP address target against a `dNSName` SAN entry.

For a target of `192.0.2.1`, Linux produced the following results. `DNS:` denotes a `dNSName` SAN entry, and `IP:` denotes an `iPAddress` SAN entry.

| Subject CN | SAN entries | Previous Linux result |
|------------|-------------|-----------------------|
| `192.0.2.1` | `DNS:example.test` | Match |
| `192.0.2.1` | `DNS:example.test`, `IP:192.0.2.2` | Match |
| `192.0.2.1` | `DNS:192.0.2.2` | Match |
| `192.0.2.1` | `DNS:*.0.2.1` | Match |
| `other.test` | `DNS:192.0.2.1` | Mismatch |

The wildcard DNS SAN in the fourth row didn't match the IP target. The matching CN caused the previous name check to succeed.

## New behavior

On Linux, `SslStream` still checks IP SAN entries by address bytes first. If no IP SAN matches, it compares the target IP as text with DNS SAN entries, without wildcard expansion. DNS SAN entries take precedence over the CN: the check falls back to the CN only when no DNS SAN entries exist.

For the same target of `192.0.2.1`, Linux now produces the following results, consistent with Windows.

| Subject CN | SAN entries | New Linux result |
|------------|-------------|------------------|
| `192.0.2.1` | `DNS:example.test` | Mismatch |
| `192.0.2.1` | `DNS:example.test`, `IP:192.0.2.2` | Mismatch |
| `192.0.2.1` | `DNS:192.0.2.2` | Mismatch |
| `192.0.2.1` | `DNS:*.0.2.1` | Mismatch |
| `other.test` | `DNS:192.0.2.1` | Match |

A name mismatch produces <xref:System.Net.Security.SslPolicyErrors.RemoteCertificateNameMismatch>. Unless a custom certificate-validation callback accepts that error, client authentication fails with an <xref:System.Security.Authentication.AuthenticationException>. The table describes only name checks; a match doesn't bypass certificate-chain validation.

The following behaviors remain unchanged:

- A matching IP SAN succeeds even if a DNS SAN or the CN doesn't match.
- Without DNS SAN entries, a matching CN can still succeed, including when the SAN extension contains only nonmatching IP addresses.
- CN comparisons don't expand wildcards or normalize different textual representations of an IP address.

The new DNS SAN comparison also doesn't normalize IP address text. For example, DNS SAN `2001:0db8:0:0:0:0:0:1` doesn't match target `2001:db8::1`, despite the equivalent address bytes. An IP SAN for that address matches either representation.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous Linux behavior differed from Windows when a certificate contained DNS SAN entries and the target was an IP address. The change aligns Linux with Windows for those cases and prevents an unrelated DNS SAN from being ignored in favor of a matching CN.

The change preserves Windows-compatible legacy behavior rather than enforcing the strict IP-ID rules in [RFC 9525](https://www.rfc-editor.org/rfc/rfc9525.html#section-6.4). In particular, the name check can still accept IP text in a DNS SAN or fall back to the CN when no DNS SAN entries exist.

For the motivation and implementation, see [dotnet/runtime#131734](https://github.com/dotnet/runtime/issues/131734) and [dotnet/runtime#135573](https://github.com/dotnet/runtime/pull/135573).

## Recommended action

To identify an IP address endpoint reliably, issue or replace the server certificate with an `iPAddress` SAN for each IP address that clients use. Encode the address as an IP SAN, not as a DNS SAN containing IP text. A matching IP SAN also avoids differences between compressed and expanded IPv6 text.

If the certificate identifies a DNS hostname instead, connect and authenticate with a DNS hostname that matches the certificate's DNS SAN. Ensure the hostname identifies the intended server.

Review custom certificate-validation callbacks and tests that depend on the old Linux name-check results. Don't restore the previous behavior by accepting all certificate errors or ignoring `RemoteCertificateNameMismatch`.

For the current rules, see [TLS certificate names for IP address targets](../../../../standard/security/cross-platform-cryptography.md#tls-certificate-names-for-ip-address-targets).

## Affected APIs

The following client authentication APIs are affected when the target host is an IP address:

- <xref:System.Net.Security.SslStream.AuthenticateAsClient*?displayProperty=fullName> (all overloads).
- <xref:System.Net.Security.SslStream.AuthenticateAsClientAsync*?displayProperty=fullName> (all overloads).
- <xref:System.Net.Security.SslStream.BeginAuthenticateAsClient*?displayProperty=fullName> (all overloads; authentication failures are observed through <xref:System.Net.Security.SslStream.EndAuthenticateAsClient?displayProperty=fullName>).

For overloads that accept authentication options, the target comes from <xref:System.Net.Security.SslClientAuthenticationOptions.TargetHost?displayProperty=fullName>.
