---
title: Optimizing AOT deployments
description: Learn about optimizing the outputs of AOT compilation for size and speed.
author: MichalStrehovsky
ms.author: michals
ms.date: 04/21/2023
ms.topic: how-to
---
# Optimize AOT deployments

The Native AOT publishing process generates a self-contained executable with a subset of the runtime libraries that are tailored specifically for your app. The compilation generally relies on static analysis of the application to generate the best possible output. However, the term "best possible" can have many meanings. Sometimes, you can improve the output of the compilation by providing hints to the publish process.

## Optimize for size or speed

During the compilation, the publishing process makes decisions and tradeoffs between generating the theoretically fastest possible executable and the size of the executable. By default, the compiler chooses a blended approach: generate fast code, but be mindful of the size of the application.

The `<OptimizationPreference>` MSBuild property can be used to communicate a general optimization goal instead of the blended default approach:

```xml
<OptimizationPreference>Size</OptimizationPreference>
```

Setting `OptimizationPreference` to `Size` instructs the publishing process to favor the size of the executable instead of other performance metrics. The size of the app is expected to be smaller, but other performance metrics might be affected.

```xml
<OptimizationPreference>Speed</OptimizationPreference>
```

Setting `OptimizationPreference` to `Speed` instructs the publishing process to favor code execution speed. The peak throughput of the app is expected to be higher, but other performance metrics might be affected.

## Further size optimization options

Since Native AOT deployments imply the use of trimming, it's possible to further improve the size of the application by specifying more [trimming options](../trimming/trimming-options.md). For example, the [Trim framework library features section](../trimming/trimming-options.md#trim-framework-library-features) discusses how to disable library features such as globalization.
