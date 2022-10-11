---
title: "Breaking change: Output caching API changes"
description: Learn about the breaking change in ASP.NET Core 7.0 where changes were made to some output caching APIs.
ms.date: 10/10/2022
---
# Output caching API changes

Some APIs in the <xref:Microsoft.AspNetCore.OutputCaching?displayProperty=fullName> namespace have changed to better represent their intent.

The following APIs were removed:

- <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.%23ctor> constructor
- <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.Clear?displayProperty=nameWithType>

The following APIs were renamed:

| Previous name | New name |
| - | - |
| <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.AllowLocking(System.Boolean)?displayProperty=nameWithType> | `SetLocking()` |
| <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.VaryByRouteValue(System.String[])?displayProperty=nameWithType> | `SetVaryByRouteValue()` |
| <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.VaryByQuery(System.String[])?displayProperty=nameWithType> | `SetVaryByQuery` |
| <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.VaryByHeader(System.String[])?displayProperty=nameWithType> | `SetVaryByHeader` |

The following APIs were added:

- `CacheVaryByRules.VaryByHost`
- `OutputCacheOptions.AddPolicy(string name, Action<OutputCachePolicyBuilder> build, bool excludeDefaultPolicy)`
- `OutputCacheOptions.AddBasePolicy(Action<OutputCachePolicyBuilder> build, bool excludeDefaultPolicy)`
- `Microsoft.Extensions.DependencyInjection.OutputCacheConventionBuilderExtensions.CacheOutput<TBuilder>(this TBuilder builder, Action<OutputCachePolicyBuilder> policy, bool excludeDefaultPolicy)`

## Version introduced

ASP.NET Core 7.0 RC 2

## Previous behavior

<xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.VaryByQuery(System.String[])?displayProperty=nameWithType> was additive: every call added more query string keys.

## New behavior

The <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.VaryByQuery(System.String[])?displayProperty=nameWithType> method is now named `OutputCachePolicyBuilder.SetVaryByQuery`, and each call replaces existing query string keys.

For other changes, see the first section of this article.

## Type of breaking change

This change affects [source compatibility](../../categories.md#source-compatibility) and [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

This change was made to improve the consistency of method names and to remove ambiguity in their behavior.

## Recommended action

Recompile any projects built with an earlier SDK. If you referenced any of these method names directly, update the source to reflect the new names.

## Affected APIs

- <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.%23ctor> constructor
- <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.Clear?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.AllowLocking(System.Boolean)?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.VaryByRouteValue(System.String[])?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.VaryByQuery(System.String[])?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.OutputCaching.OutputCachePolicyBuilder.VaryByHeader(System.String[])?displayProperty=fullName>
