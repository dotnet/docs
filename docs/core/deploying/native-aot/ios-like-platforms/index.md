---
title: Native AOT support for iOS-like platforms overview
description: Learn how Native AOT supports iOS-like platforms
author: ivanpovazan
ms.author: ivanpovazan
ms.date: 11/21/2024
---

# Native AOT support for iOS-like platforms

Starting from .NET 8, Native AOT supports targeting iOS-like platforms. The term **iOS-like platforms** refers to Apple platforms that use similar APIs such as: iOS, MacCatalyst and tvOS.

In the first release, the support was experimental, while in .NET 9 these platforms received full support with Native AOT.

Based on the use case, the support can be divided into:

- support for assemblies referencing OS-specific APIs through .NET mobile workloads (like: .NET MAUI apps)
- support for assemblies without OS-specific API dependencies

The former is a more common scenario and is described in detail in [How MAUI supports Native AOT](/dotnet/maui/deployment/nativeaot).
For the latter use case Native AOT deployment can be achieved by:

1. Enable Native AOT deployment by including the following properties in the project file:

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
