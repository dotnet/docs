---
title: Frameworks and Targets
description: Explains the concepts of framework targets when writing .NET code.
keywords: .NET, .NET Core
author: richlander
ms.author: mairaw
ms.date: 09/19/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 6ef56a2e-593d-497b-925a-1e25bb6df2e6
---

# Frameworks and Targets

The .NET ecosystem has a concept of frameworks. Frameworks define the API that you can use to target a particular platform. The .NET Framework 4.6 is one of those platforms. Frameworks are used in Visual Studio and other IDEs and editors to provide you with the correct set of APIs. They are also used by NuGet, for both production and consumption of NuGet packages, to ensure that you produce and use appropriate packages (and underlying assets) for the framework you are targeting. One can think of frameworks as one of the key currencies in the .NET ecosystem. The concept is there for correctness, to help you and your customers avoid seeing @System.MissingMethodException and friends at runtime.

## Framework Versions

The table below defines the set of frameworks that you can use, how they are referred to and which version of the [.NET Standard Library](library.md) that they implement.

| Framework | Latest Version | Target Framework Moniker (TFM) | Compact Target Framework Moniker (TFM) | .NET Standard Version | Metapackage |
|:--------: | :--: | :--: | :--: | :--: | :--: | :--: |
| .NET Standard | 1.6 | .NETStandard,Version=1.6 | netstandard1.6 | N/A | [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library)|
| .NET Core Application | 1.0.1 | .NETCoreApp,Version=1.0 | netcoreapp1.0 | 1.6 | [Microsoft.NETCore.App](https://www.nuget.org/packages/Microsoft.NETCore.App)|
| .NET Framework | 4.6.2 | .NETFramework,Version=4.6.2 | net462 | 1.5 | N/A |

> [!NOTE]
> These framework versions are the latest stable versions. There may be pre-released versions as well that are not described by this table.

## Writing about Frameworks

There are multiple ways to refer to frameworks in written form, most of which are used in this documentation. They are described below, both as a legend for interpreting the documentation but also to guide use in other documents.

Using .NET Framework 4.6.1 as an example, the following forms can be used:

**Referring to a product**

You can refer to a .NET platform or runtime.

- ".NET Framework 4.6.1"

**Referring to a Framework**

You can refer to a framework or targeting of a framework using long- or short-forms of the TFM. Both are equally valid in the general case.

- `.NETFramework,Version=4.6.1`
- `net461`

**Referring to a family of Frameworks**

You can refer to a family of frameworks using long- or short-forms of the framework ID. Both are equally valid in the general case.

- `.NETFramework`
- `net`
