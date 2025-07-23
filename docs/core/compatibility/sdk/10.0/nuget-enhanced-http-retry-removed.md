---
title: "Breaking change: NUGET_ENABLE_ENHANCED_HTTP_RETRY environment variable removed"
description: "Learn about the breaking change in .NET 10 where NUGET_ENABLE_ENHANCED_HTTP_RETRY environment variable no longer disables exponential retry."
ms.date: 06/24/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/46537
---
# NUGET_ENABLE_ENHANCED_HTTP_RETRY environment variable removed

The `NUGET_ENABLE_ENHANCED_HTTP_RETRY` environment variable no longer has any effect in .NET 10. Previously, this environment variable could be used to disable exponential retry back-off for failed HTTP calls in NuGet operations.

## Version introduced

.NET 10 Preview 6

## Previous behavior

When the `NUGET_ENABLE_ENHANCED_HTTP_RETRY` environment variable was set to `false`, NuGet used the old retry behavior with a fixed 200ms delay between failed HTTP calls instead of exponential back-off.

## New behavior

The `NUGET_ENABLE_ENHANCED_HTTP_RETRY` environment variable has no effect. NuGet always uses exponential retry back-off for failed HTTP calls, which has been the default behavior since .NET SDK 6.0.300.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Exponential retry back-off has been the default behavior for nearly 4 years since .NET SDK 6.0.300. The feature was introduced to help when restores overwhelmed servers that couldn't handle all package requests, and exponential retry allowed these requests to succeed. Since there has been no feedback indicating issues with this approach, the fallback option has outlived its utility.

## Recommended action

No action is required.

## Affected APIs

None.
