---
title: "Breaking change: .NET 10 requires OpenSSL 1.1.1 or later on Unix"
description: "Learn about the breaking change in .NET 10 where OpenSSL 1.1.1 or later is required on Unix platforms."
ms.date: 11/04/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47072
---
# .NET 10 requires OpenSSL 1.1.1 or later on Unix

Starting in .NET 10, OpenSSL 1.1.1 or later is required on Unix platforms where .NET uses OpenSSL for cryptography, such as Linux. If OpenSSL 1.1.1 is not available on a platform that requires it, the application will fail to start. .NET 10 on macOS does not use OpenSSL and is not impacted by this change.

## Version introduced

.NET 10 GA

## Previous behavior

.NET applications supported OpenSSL prior to 1.1.1, such as 1.0.2 or 1.1.0.

## New behavior

.NET applications require OpenSSL 1.1.1 or later. If OpenSSL 1.1.1 is not available on a platform that requires it, the application will fail to start.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

OpenSSL prior to OpenSSL 1.1.1 is outdated and not supported by mainstream Linux or Unix distributions. Supporting these out-of-date OpenSSL versions increases complexity of maintenance where that effort is better made on supporting modern versions of OpenSSL.

## Recommended action

Use a distribution of Unix or Linux that includes OpenSSL 1.1.1 or later.

## Affected APIs

None.
