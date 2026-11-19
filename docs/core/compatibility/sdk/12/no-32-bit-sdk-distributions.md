---
title: "Breaking change: Native Linux ARM32 and Windows x86 SDK distributions are no longer produced"
description: "Learn about the breaking change in .NET 12 where the SDK no longer produces native Linux ARM32 or Windows x86 distributions."
ms.date: 11/19/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/56945
---

# Native Linux ARM32 and Windows x86 SDK distributions are no longer produced

.NET 12 no longer produces native SDK distributions for Linux ARM32 or Windows x86. Runtime support and the ability to target and publish apps for these architectures remain unchanged.

## Version introduced

.NET 12 Preview 1

## Previous behavior

Previously, the .NET SDK provided native Linux ARM32 distributions for `linux-arm` and `linux-musl-arm`, and a native Windows x86 distribution. You could run the SDK process directly on those architectures.

## New behavior

Starting in .NET 12, the .NET SDK no longer produces or publishes native Linux ARM32 (`linux-arm` and `linux-musl-arm`) or Windows x86 distributions. Runtime support and app targeting and publishing for these architectures remain unchanged. Previously released SDK distributions continue their existing servicing lifecycle.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

To focus SDK engineering and servicing resources on architectures with greater usage, the SDK team ended these distributions. The [Linux ARM32 SDK proposal](https://github.com/dotnet/sdk/issues/56306) and [Windows x86 SDK proposal](https://github.com/dotnet/sdk/issues/56300) describe usage that did not justify the cost to build, test, sign, publish, and service the native SDKs. The [implementation PR](https://github.com/dotnet/dotnet/pull/10083) stops these SDK builds while preserving runtime and app-target support.

## Recommended action

To build or cross-publish apps for Linux ARM32 or Windows x86, use a supported x64 or Arm64 SDK. You can still target `linux-arm`, `linux-musl-arm`, and `win-x86` from those SDKs; you don't need to run the SDK process on the target architecture. In .NET 12, a native SDK process is no longer available for Linux ARM32 or Windows x86.

## Affected APIs

None.
