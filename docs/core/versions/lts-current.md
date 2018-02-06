---
title: .NET Core Support
description: Learn about the different release train supports (LTS and Current) for .NET Core
keywords: .NET, .NET Core, lts, current, fts, support, support trains, support tracks, Lifecycle, release trains
author: kendrahavens
ms.author: mairaw
ms.date: 01/30/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: fedc7025-f320-4cba-957b-ef74885f66de
ms.workload: 
  - dotnetcore
---

# .NET Core Support

This is a general description of .NET Core support.

## LTS and Current Release Trains

Having two support release trains is a common concept in use throughout the software world, specially for open-source projects like .NET Core. .NET Core has the following support release trains: [Long Term Support (LTS)](https://en.wikipedia.org/wiki/Long-term_support) and Current. LTS releases are maintained for stability over their lifecycle, receiving fixes for important issues and security fixes. New feature work and additional bug fixes take place in Current releases. From a support perspective, these release trains have the following support lifecycle attributes.

LTS releases are
* Supported for three years after the general availability date of a LTS release
* Or one year after the general availability of a subsequent LTS release

Current releases are
* Supported within the same three-year window as the parent LTS release
* Supported for three months after the general availability of a subsequent Current release
* And one year after the general availability of a subsequent LTS release

## Versioning
New LTS releases are marked by an increase in the Major version number. Current releases have the same Major number as the corresponding LTS train and are marked by an increase in the Minor version number. For example, 1.0.3 would be LTS and 1.1.0 would be Current. Bug fix updates to either train increment the Patch version. For more information on the versioning scheme, see [.NET Core Versioning](index.md).

## What causes updates in LTS and Current trains?
To understand what specific changes, such as bug fixes or the addition of APIs, cause updates to the version numbers review the Decision Tree section in the [Versioning Documentation](index.md). There is not a golden set of rules that decide what changes are pulled into the LTS branch from Current. Typically, necessary security updates and patches that fix expected behaviour are reasons to update the LTS branch. We also intend to support recent desktop developer operating systems on the LTS branch, though this may not always be possible. A good way to catch up on what APIs, fixes, and operating systems are supported in a certain release is to browse its [release notes](https://github.com/dotnet/core/tree/master/release-notes) on GitHub.

### Further Reading
* [.NET Core Support Lifecycle Fact Sheet](https://www.microsoft.com/net/core/support)
* [Currently supported operating systems and versions](https://github.com/dotnet/core/blob/master/roadmap.md)
