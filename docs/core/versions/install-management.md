---
title: Manage .NET Core installations
description: Manage multiple versions of .NET Core SDK and Runtime on your machine, working with the side-by-side installation strategies.
author: leecow
ms.author: wiwagn
ms.date: 08/22/2018
---
# Manage .NET Core installations

.NET Core allows multiple versions of the SDK and Runtime to exist side-by-side, enabling version dependency flexibility for both building and running .NET Core applications. These installation and automatic version roll-forward behaviors offer valuable benefits, but one pronounced drawback. As updates of the .NET Core SDK or .NET Core Runtime are installed, previous versions remain on-disk. Multiple installed versions increase disk usage over time. More than 50 .NET Core SDK updates have been released. There may be many versions of the SDK and Runtime installed on your system that could be removed.

## Safe to remove?

The [.NET Core version selection](selection.md) behaviors and the runtime compatibility of .NET Core across updates enables safe removal of previous versions. .NET Core runtime updates are compatible within a major version 'band' such as 1.x and 2.x. Additionally, newer releases of the .NET Core SDK generally maintain the ability to build applications that target previous versions of the runtime in a compatible manner.

In general, you only need the latest SDK and latest patch version of the runtimes required for your application. Instances where retaining older SDK or Runtime versions include maintaining project.json-based applications.  Unless your application has specific reasons for earlier SDKs or runtimes, you may safely remove older versions.

The methods for removing .NET Core vary from platform to platform and have changed somewhat across .NET Core versions. For details on removing versions of .NET Core that are no longer needed, see ['How to remove the .NET Core Runtime and SDK'](remove-runtime-sdk-versions.md) in the [.NET Core documentation](../index.md).
