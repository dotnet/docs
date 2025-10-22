---
title: Mac OS
description: Learn how to publish .NET applications for Mac OS, including signing, notarization, and app entitlements.
author: @agocke
ms.date: [DATE]
ms.topic: how-to
---

# Publish .NET Apps for Mac OS

Publishing .NET applications for Mac OS requires several additional steps compared to other platforms, due to Apple's security requirements.

## Requirements

- **Apple Developer Account**: Needed for code signing and notarization.
- **Xcode Command Line Tools**: Provides `codesign`, `altool`, and other utilities.
- **.NET SDK**: Ensure you have the latest .NET SDK installed.

## Steps to Publish

### 1. Build and Publish Your App

Use one the methods described under Publishing to produce a application. This can either be a framework-dependent or self-contained application.

### 2. Apphost and Entry Point

.NET creates a native *apphost* executable as the entry point for your app. This apphost must be signed and, if your app uses special capabilities, it must be assigned the appropriate **entitlements**.

For CoreCLR apps, the `com.apple.security.cs.allow-jit` entitlement is required.

For Native AOT apps, no entitlements are required.

### 3. Sign and notarize

Use Apple's developer documentation to sign and notarize the binary.
---

> **Note:** Failing to sign and notarize your app may result in users seeing security warnings or being unable to launch your application.