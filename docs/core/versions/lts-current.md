---
title: .NET Core Support
description: LTS and Current Release Train Support
keywords: .NET, .NET Core, lts, current, fts, support, support trains, support tracks, Lifecycle, release trains
author: kendrahavens
ms.date: 01/30/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: fedc7025-f320-4cba-957b-ef74885f66de
---

# .NET Core Support

This is a general description of .NET Core support. For more detail see the original [.NET Blog post introducing the lts and current tracks with the 1.0 release.](https://blogs.msdn.microsoft.com/dotnet/2016/07/26/net-support-and-versioning/)

## LTS and Current Release Trains
Long Term Support (LTS) and Current are concepts in use throughout the software world and should be familiar to many. LTS releases are maintained for stability over their lifecycle, receiving fixes for important issues and security fixes. New feature work and additional bug fixes take place in Current releases. From a support perspective, these release trains have the following support lifecycle attributes.

LTS releases are
* Supported for three years after the general availability date of a LTS release
* And one year after the general availability of a subsequent LTS release

Current releases are
* Supported within the same three-year window as the parent LTS release
* And three months after the general availability of a subsequent Current release
* And one year after the general availability of a subsequent LTS release

## Versioning
New LTS releases are marked by an increase in the Major version number. Current releases have the same Major number as the corresponding LTS train and are marked by an increase in the Minor version number. Bug fix updates to either train increment the Patch version.

### Further Reading
* [.NET Core Support Lifecycle Fact Sheet](https://www.microsoft.com/net/core/support)
* [Currently supported operating systems and versions](https://github.com/dotnet/core/blob/master/roadmap.md)