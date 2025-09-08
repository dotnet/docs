---
title: "Breaking change: NuGet logs an error for invalid package IDs"
description: "Learn about the breaking change in .NET 10 where NuGet validates package IDs when constructing URLs and throws exceptions for invalid formats."
ms.date: 09/08/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47984
---
# NuGet logs an error for invalid package IDs

NuGet now validates package IDs when they're used to create URLs in .NET 10. If a package ID isn't in the correct format, NuGet shows an error instead of continuing. This ensures only valid package IDs are used when constructing URLs.

## Version introduced

.NET 10 RC 1

## Previous behavior

Previously, NuGet resources that constructed URLs from package IDs did not validate the package ID format. Invalid or malformed package IDs could be used without triggering validation errors.

## New behavior

Starting with the .NET 10 SDK, any package ID used to construct a URL via NuGet resources is now validated. If the package ID doesn't conform to NuGet's expected format, an exception is thrown, and the URL is not constructed.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change introduces validation to ensure that only properly formatted package IDs are used when constructing URLs. The validation strengthens the code's security posture by reducing the risk of unsafe or unintended inputs being processed.

## Recommended action

To disable the package ID validation logic and restore the previous behavior, you can set the environment variable `NUGET_DISABLE_PACKAGEID_VALIDATION` to `true`.

## Affected APIs

None.
