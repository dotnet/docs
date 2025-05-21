---
title: Native AOT support for iOS-like platforms overview
description: Learn how Native AOT supports iOS-like platforms
author: ivanpovazan
ms.author: ivanpovazan
ms.date: 11/21/2024
ms.topic: article
---

# Native AOT support for iOS-like platforms

Starting from .NET 9, Native AOT supports targeting iOS-like platforms. The term *iOS-like platforms* refers to Apple platforms that use similar APIs such as: iOS, MacCatalyst and tvOS.

Based on the use case, the support can be divided into:

- support for applications and libraries referencing OS-specific APIs
- support for applications and libraries without OS-specific API dependencies

## Support for applications and libraries referencing OS-specific APIs

This refers to .NET MAUI projects targeting OS-specific target frameworks (like: `net9.0-ios`).
How Native AOT can be enabled for .NET MAUI apps, see [Native AOT deployment on iOS and Mac Catalyst](/dotnet/maui/deployment/nativeaot).

## Support for applications and libraries without OS-specific API dependencies

This refers to .NET projects targeting the general or non-OS-specific target framework (like: `net9.0`), for which Native AOT can be enabled in the following way:

1. Include the following properties in your project file:

    ```xml
    <PublishAot>true</PublishAot>
    <PublishAotUsingRuntimePack>true</PublishAotUsingRuntimePack>
    ```

2. Publish the project for the desired iOS-like target platform by specifying adequate runtime identifier (later referred to as `<rid>`):

    - `ios-arm64`, for iOS physical devices
    - `iossimulator-arm64` or `iossimulator-x64`, for iOS simulators
    - `maccatalyst-arm64` or `maccatalyst-x64`, for Mac Catalyst
    - `tvos-arm64`, for tvOS physical devices
    - `tvossimulator-arm64` or `tvossimulator-x64`, for tvOS simulators

    and execute the following command:

    ```
    dotnet publish -r <rid>
    ```

For specifics of building and consuming native libraries on iOS-like platforms, see [How to create and consume custom frameworks with Native AOT for iOS-like platforms](./creating-and-consuming-custom-frameworks.md).
