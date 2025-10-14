---
title: "Breaking change: TrustedCertificatesDirectory and StartNewTlsSessionContext are not available on .NET Standard / .NET Framework"
description: Learn about the .NET 8 breaking change in core .NET libraries where TrustedCertificatesDirectory and StartNewTlsSessionContext are not available when targeting .NET Standard 2.0.
ms.date: 10/14/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/48879
---
# TrustedCertificatesDirectory and StartNewTlsSessionContext are not available on .NET Standard / .NET Framework

The following APIs were accidentally exposed in the `netstandard2.0` version of the System.DirectoryServices.Protocols NuGet package version 8.0.1:

- <xref:System.DirectoryServices.Protocols.LdapSessionOptions.TrustedCertificatesDirectory?displayProperty=nameWithType>
- <xref:System.DirectoryServices.Protocols.LdapSessionOptions.StartNewTlsSessionContext?displayProperty=nameWithType>

These APIs aren't implemented on .NET Framework and weren't intended to be exposed when targeting `netstandard2.0`. Starting with version 8.0.2 of the System.DirectoryServices.Protocols NuGet package, these APIs are unavailable when targeting `netstandard2.0`.

## Previous behavior

In System.DirectoryServices.Protocols NuGet package version 8.0.1, the <xref:System.DirectoryServices.Protocols.LdapSessionOptions.TrustedCertificatesDirectory?displayProperty=nameWithType> property and <xref:System.DirectoryServices.Protocols.LdapSessionOptions.StartNewTlsSessionContext?displayProperty=nameWithType> method could be used from a `netstandard2.0` library.

## New behavior

Starting with System.DirectoryServices.Protocols NuGet package version 8.0.2, attempting to use these APIs from a `netstandard2.0` library results in a compilation error.

## Version introduced

System.DirectoryServices.Protocols NuGet package version 8.0.2

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-incompatible).

## Reason for change

The APIs didn't work on all compatible frameworks.

## Recommended action

If you need to use these APIs, target .NET instead of `netstandard2.0`.

## Affected APIs

- <xref:System.DirectoryServices.Protocols.LdapSessionOptions.TrustedCertificatesDirectory?displayProperty=fullName>
- <xref:System.DirectoryServices.Protocols.LdapSessionOptions.StartNewTlsSessionContext?displayProperty=fullName>
