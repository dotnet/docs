---
title: "Breaking change: OpenSSL cryptographic primitives aren't supported on macOS"
description: "Learn about the breaking change in .NET 10 where OpenSSL cryptographic primitives are no longer supported on macOS."
ms.date: 06/23/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/46789
---
# OpenSSL cryptographic primitives are not supported on macOS

Starting in .NET 10, OpenSSL-backed cryptographic primitives are no longer supported on macOS. <xref:System.Security.Cryptography.AesCcm?displayProperty=fullName> and classes that are specific to OpenSSL, such as <xref:System.Security.Cryptography.RSAOpenSsl?displayProperty=fullName>, now throw a <xref:System.PlatformNotSupportedException> on macOS.

## Version introduced

.NET 10 Preview 6

## Previous behavior

Previously, classes that are specific to OpenSSL, such as <xref:System.Security.Cryptography.RSAOpenSsl?displayProperty=fullName>, worked on macOS if OpenSSL was available.

<xref:System.Security.Cryptography.AesCcm?displayProperty=fullName> worked on macOS if OpenSSL was available.

## New behavior

Classes that are specific to OpenSSL, such as <xref:System.Security.Cryptography.RSAOpenSsl>, don't work on macOS even if OpenSSL is available, and a <xref:System.PlatformNotSupportedException> exception is thrown.

<xref:System.Security.Cryptography.AesCcm> throws a <xref:System.PlatformNotSupportedException> exception.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Support for the OpenSSL-backed primitives originated from .NET Core 1.0, where cryptography on macOS was implemented with OpenSSL. This wasn't ideal because a recent version of OpenSSL doesn't come on macOS, and acquiring and configuring OpenSSL on macOS was troublesome. In the .NET Core 2.0 timeframe, cryptography was moved to Apple's built-in functionality, so cryptographic functionality "just worked" without needing to acquire any additional components.

The types that are suffixed as `OpenSsl` were left as being implemented by OpenSSL, and <xref:System.Security.Cryptography.AesCcm> doesn't have an implementation in Apple's cryptographic libraries.

Supporting these OpenSSL-backed primitives on macOS has become more difficult as Apple has made it more difficult to load libraries from certain paths, and it complicates distributing software on macOS.

## Recommended action

If you're using OpenSSL-backed primitives without any specific intention of using OpenSSL, the recommendation is to use the factories that provide a macOS implementation:

* `new DSAOpenSsl(...)` -> `DSA.Create(...)`
* `new ECDiffieHellmanOpenSsl(...)` -> `ECDiffieHellman.Create(...)`
* `new ECDsaOpenSsl(...)` -> `ECDsa.Create(...)`
* `new RSAOpenSsl(...)` -> `RSA.Create(...)`

<xref:System.Security.Cryptography.AesCcm?displayProperty=fullName> has no functional equivalent on macOS. Consider using a different cryptographic primitive, such as <xref:System.Security.Cryptography.AesGcm?displayProperty=fullName>, instead.

## Affected APIs

* <xref:System.Security.Cryptography.AesCcm?displayProperty=fullName> (all constructors)
* <xref:System.Security.Cryptography.DSAOpenSsl?displayProperty=fullName> (all constructors)
* <xref:System.Security.Cryptography.ECDiffieHellmanOpenSsl?displayProperty=fullName> (all constructors)
* <xref:System.Security.Cryptography.ECDsaOpenSsl?displayProperty=fullName> (all constructors)
* <xref:System.Security.Cryptography.RSAOpenSsl?displayProperty=fullName> (all constructors)
* <xref:System.Security.Cryptography.SafeEvpPKeyHandle?displayProperty=fullName> (entire class)
