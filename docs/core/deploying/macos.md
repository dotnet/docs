---
title: Publish .NET apps for macOS
description: Learn how to publish .NET applications for macOS, including signing, notarization, app entitlements, and universal binaries.
author: agocke
ms.author: angocke
ms.date: 07/31/2026
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

## Universal binaries

macOS supports *universal binaries*: a single Mach-O file that contains machine code for more than one CPU architecture. macOS selects the slice that matches the current processor, so one file runs natively on both Apple silicon (arm64) and Intel (x64) machines.

.NET doesn't produce universal binaries directly. Instead, you publish your app once per architecture and merge the two native executables with the Apple `lipo` tool. Two .NET publishing modes produce a self-contained native executable that you can merge this way:

- [Single-file apps](single-file/overview.md) (`PublishSingleFile`)
- [Native AOT deployment](native-aot/index.md) (`PublishAot`)

### Publish a single-file universal binary

Publish the app once per architecture into separate directories:

```bash
dotnet publish -c Release -r osx-arm64 --self-contained true \
    -p:PublishSingleFile=true -o out/osx-arm64

dotnet publish -c Release -r osx-x64 --self-contained true \
    -p:PublishSingleFile=true -o out/osx-x64
```

Then merge the two executables and re-sign the result:

```bash
mkdir -p out/universal
lipo -create -output out/universal/MyApp out/osx-arm64/MyApp out/osx-x64/MyApp
codesign --force --sign - out/universal/MyApp
```

A self-contained single-file publish embeds the runtime, the managed assemblies, and the native libraries in the executable itself, so the merged file is the complete app. The universal binary is roughly the sum of the two inputs.

Copy any remaining files from one of the per-architecture output directories (for example, `appsettings.json` or files excluded from the bundle) next to the merged executable.

### Publish a Native AOT universal binary

The steps are the same as for single-file, but replace the single-file properties with `PublishAot`:

```bash
dotnet publish -c Release -r osx-arm64 -p:PublishAot=true -o out/osx-arm64
dotnet publish -c Release -r osx-x64   -p:PublishAot=true -o out/osx-x64

mkdir -p out/universal
lipo -create -output out/universal/MyApp out/osx-arm64/MyApp out/osx-x64/MyApp
codesign --force --sign - out/universal/MyApp
```

Native AOT produces much smaller output than single-file publishing, so the universal binary stays small as well.

Native AOT also emits a `MyApp.dSYM` debug symbol bundle per architecture. To keep symbols for both slices, keep the per-architecture directories, or merge the `DWARF` binaries inside the bundles with `lipo`.
