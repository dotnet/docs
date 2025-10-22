---
title: Publish .NET apps for Mac OS
description: Learn how to publish .NET applications for Mac OS, including signing, notarization, and app entitlements.
author: agocke
ms.author: angocke
ms.date: 10/22/2025
ms.topic: how-to
ai-usage: ai-assisted
---

# Publish .NET apps for Mac OS

Publishing .NET applications for Mac OS requires several additional steps compared to other platforms, due to Apple's security requirements.

## Prerequisites

Before you publish your .NET application for Mac OS, ensure you have the following:

- **Apple Developer Account**: Needed for code signing and notarization.
- **Xcode Command Line Tools**: Provides `codesign`, `altool`, and other utilities.
- **.NET SDK**: Ensure you have the latest .NET SDK installed.

## Publish your app

Use one of the methods described in the [.NET application publishing overview](index.md) to produce an application. You can create either a framework-dependent or self-contained application.

## Apphost and entry point

.NET creates a native *apphost* executable as the entry point for your app. This apphost must be signed and, if your app uses special capabilities, it must be assigned the appropriate **entitlements**.

### Entitlements for CoreCLR apps

For CoreCLR apps, the `com.apple.security.cs.allow-jit` entitlement is required.

### Entitlements for Native AOT apps

For Native AOT apps, no entitlements are required.

## Sign and notarize

Use Apple's developer documentation to sign and notarize the binary.

> [!WARNING]
> Failing to sign and notarize your app might result in users seeing security warnings or being unable to launch your application.
