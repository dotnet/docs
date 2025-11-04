---
title: Publish .NET apps for macOS
description: Learn how to publish .NET applications for macOS, including signing, notarization, and app entitlements.
author: agocke
ms.author: angocke
ms.date: 10/22/2025
ms.topic: how-to
ai-usage: ai-assisted
---

# Publish .NET apps for macOS

Publishing .NET applications for macOS requires several additional steps compared to other platforms, due to Apple's security requirements.

## Prerequisites

Before you publish your .NET application for macOS, ensure you have the following:

- **Apple Developer Account**: Needed for code signing and notarization.
- **Xcode Command Line Tools**: Provides `codesign`, `altool`, and other utilities.
- **.NET SDK**: Ensure you have the latest .NET SDK installed.

## Produce your app using .NET SDK

Use one of the methods described in the [.NET application publishing overview](index.md) to produce an application. You can create either a framework-dependent or self-contained application.

## Sign and notarize your app

Use [Apple's developer documentation](https://developer.apple.com/documentation/security/notarizing_macos_software_before_distribution) to sign and notarize the app native binaries. .NET creates a native *apphost* executable as the entry point for your app. This apphost must be signed and, if your app uses special capabilities, it must be assigned the appropriate **entitlements**.

### Entitlements for apps not published as Native AOT

For apps not published as [Native AOT](native-aot/index.md), the `com.apple.security.cs.allow-jit` entitlement is required.

### Entitlements for apps published as Native AOT

For apps published as [Native AOT](native-aot/index.md), no entitlements are required.

### Optional entitlements for debugging and diagnostics

The following entitlements enable additional debugging and diagnostic capabilities:

- **`com.apple.security.get-task-allow`**: Needed for dump collection with `createdump` and `dotnet dump`.
- **`com.apple.security.cs.debugger`**: Needed to attach a debugger to the process.

> [!WARNING]
> Failing to sign and notarize your app might result in the application crashing while executing a restricted operation.
