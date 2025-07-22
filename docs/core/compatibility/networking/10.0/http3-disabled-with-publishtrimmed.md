---
title: "Breaking change - HTTP3 support in System.Net.Http disabled by default with PublishTrimmed"
description: "Learn about the breaking change in .NET 10 where HTTP3 support is disabled by default when PublishTrimmed or PublishAot is set to true."
ms.date: 1/20/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47443
---

# HTTP3 support in System.Net.Http disabled by default with PublishTrimmed

Setting `PublishTrimmed` or `PublishAot` to `true` in the project disables HTTP3 support in System.Net.Http by default.

## Version introduced

.NET 10 Preview 6

## Previous behavior

Previously, HTTP3 support was allowed, but might not have actually worked by default in environments where the msquic native library is not available. This resulted in HTTP3 not actually working while the app carried all the code related to it.

## New behavior

Starting in .NET 10, HTTP3 is disabled and the code for it is not included when `PublishTrimmed` or `PublishAot` is set to `true`.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

Since making HTTP3 work requires extra gestures and often doesn't work by default, the runtime no longer carries the code for it in trimmed or AOT-compiled applications to reduce application size and complexity.

## Recommended action

To enable HTTP3 support in applications that use `PublishTrimmed` or `PublishAot`, set the `<Http3Support>` property to `true` in your project file:

```xml
<PropertyGroup>
  <PublishTrimmed>true</PublishTrimmed>
  <Http3Support>true</Http3Support>
</PropertyGroup>
```

Or for AOT scenarios:

```xml
<PropertyGroup>
  <PublishAot>true</PublishAot>
  <Http3Support>true</Http3Support>
</PropertyGroup>
```

## Affected APIs

None.