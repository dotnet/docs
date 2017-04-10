---
title: Building .NET Core from source
description: Building .NET Core from source
keywords: .NET, .NET Core, source, build
author: beleroy
ms.author: mairaw
ms.date: 03/29/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
---

# Building .NET Core from source

The ability for anyone to build .NET Core from its source code is important in multiple ways: it makes it easier to port .NET Core to new platforms, it enables contributions and fixes to the product, and it enables the creation of custom versions of .NET.
This section of the documentation demonstrates the process of building .NET Core from source, and gives guidance to developers who want to build and distribute their own versions of .NET Core.

## How to build from source

1. Clone [the repository](https://github.com/dotnet), then `cd` into it.
2. `git pull --recurse-submodules`
3. On Linux or macOS, `./build.sh`, and on Windows, `build`.

The results of the build, if successful, will be in `./...`.

## Related topics

* [.NET Core distribution packaging](./distribution-packaging.md)