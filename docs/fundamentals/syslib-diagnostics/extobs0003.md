---
title: EXTOBS0003 warning
description: Learn about the obsolete HybridCacheOptions.DisableCompression property that generates compile-time warning EXTOBS0003.
ms.date: 10/29/2026
f1_keywords:
  - extobs0003
ai-usage: ai-generated
---

# EXTOBS0003: HybridCacheOptions.DisableCompression is obsolete

The <xref:Microsoft.Extensions.Caching.Hybrid.HybridCacheOptions.DisableCompression?displayProperty=nameWithType> property is obsolete. Use of this property generates warning `EXTOBS0003` at compile time.

The default `HybridCache` implementation doesn't provide built-in compression, so the property has no effect, regardless of its value.

Note that the `HybridCacheEntryFlags.DisableCompression` flag isn't obsolete. The flag belongs to the shared abstraction, and while the default `HybridCache` implementation doesn't honor it, other `HybridCache` implementations might.

## Workarounds

Remove references to `HybridCacheOptions.DisableCompression` from your code. For the default `HybridCache` implementation, you don't need a replacement setting because the property never enabled or disabled compression.

To compress cached data, configure a serializer that performs compression. For information about custom serializers, see [HybridCache serialization](../../core/extensions/caching.md#serialization).

## Suppress a warning

If you can't remove references to the obsolete property, suppress `EXTOBS0003` with a `#pragma warning` directive in your source code or a `<NoWarn>` property in your project file. For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).

## See also

- [HybridCache in .NET](../../core/extensions/caching.md#hybrid-caching)
