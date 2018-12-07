---
title: How versioning the .NET Core SDK changed
description: This article describes how versioning of the .NET Core SDK and Runtime changed in the v2.1 timeframe.
ms.date: 07/26/2018
ms.custom: "seodec18"
---

# NET Core version changes between 1.0 and 2.1

Version numbers for .NET Core are challenging because .NET Core SDK and .NET Core Runtime release on different cadences. The different cadences mean the team was forced to do only two of the following three things:

1. Release independently, specifically allowing tools, C# and VB to advance faster than the .NET Core Runtime.
2. Maintain alignment in version numbers between .NET Core SDK and .NET Core Runtime.
3. Use semantic versioning for both the .NET Core SDK and .NET Core Runtime.

2.0.0 forced version alignment and proceeded smoothly for one release. In December 2017 .NET Core SDK had a feature release, with no corresponding release in the .NET Core Runtime. The team chose goals 1 and 3, losing alignment between the .NET Core Runtime and SDK. Several .NET Core SDK 2.1.x versions were released before .NET Core Runtime 2.1. Since the SDK is not forwards compatible, these 2.1.x SDK versions could not target .NET Core Runtime 2.1. The team responded to the considerable confusion by switching to goals 1 and 2, abandoning semantic versioning as described in [.NET Core versioning](index.md#versioning-details).

Because of the timing of the decision to abandon semantic versioning, there were transitional releases in the 2.1.10x and 2.1.20x version number ranges that also can't target .NET Core Runtime 2.1.

The first two digits of the version numbers realign with the 2.1.0 version of the .NET Core Runtime and the 2.1.300 version of the .NET Core SDK.

Detailed information about the versions of individual components, including framework and language compiler versions, can be found on the [.NET Core downloads page](https://www.microsoft.com/net/download/dotnet-core/current). For detailed information about previous versions, select the requested version from the [.NET Core download archives page](https://www.microsoft.com/net/download/archives). Detailed support information can be found in the article describing the official [.NET Support Policy](https://www.microsoft.com/net/Support/Policy).