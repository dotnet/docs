---
title: "Breaking change - HTTP/3 support in System.Net.Http disabled by default with PublishTrimmed"
description: "Learn about the breaking change in .NET 10 where HTTP/3 support is disabled by default when PublishTrimmed or PublishAot is set to true."
ms.date: 07/22/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47443
---

# HTTP/3 support in System.Net.Http disabled by default with PublishTrimmed

Setting `PublishTrimmed` or `PublishAot` to `true` in the project disables HTTP/3 support in <xref:System.Net.Http> by default.

## Version introduced

.NET 10 Preview 6

## Previous behavior

Previously, HTTP/3 support was allowed, but might not have actually worked by default in environments where the msquic native library wasn't available. This resulted in HTTP/3 not actually working while the app carried all the code related to it.

## New behavior

Starting in .NET 10, HTTP/3 is disabled and the code for it isn't included when `PublishTrimmed` or `PublishAot` is set to `true`.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

Since making HTTP/3 work requires extra gestures and often doesn't work by default, the runtime no longer carries the code for it in trimmed or AOT-compiled applications.

## Recommended action

To enable HTTP/3 support in applications that use `PublishTrimmed` or `PublishAot`, set the `<HTTP/3Support>` property to `true` in your project file:

```xml
<PropertyGroup>
  ...
  <PublishTrimmed>true</PublishTrimmed>
  <HTTP/3Support>true</HTTP/3Support>
</PropertyGroup>
```

## Affected APIs

None.

## See also

- [Trimming options](../../../deploying/trimming/trimming-options.md)
