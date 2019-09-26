---
title: .NET Core Deployment Experiences
description: .NET Core Deployment Experiences
author: jamshedd
ms.author: jamshedd
ms.date: 09/06/2019
ms.custom: 
---
# .NET Core Deployment Experiences

<br/>

## Full Installers
.NET Core major and minor releases as well as servicing updates always ship as the full product installers. The installer carries the entire product even if only a subset of the files is updated.

<br/>

## Side by Side installs versus in-place updates
Before .NET Core 3.0, all .NET Core releases including servicing updates were fully side-by-side installs. If you installed a minor version, and then installed another minor release or even a patch release for the minor release, both the original and patch versions would always be installed in discrete install locations. 

For example, installing the .NET Core 2.2.14 update when you already have the .NET Core 2.2.13 update installed will result in both .NET Core 2.2.13 and .NET Core 2.2.14 being present on the computer. 

As customers installed multiple updates each of these installed side by side and accumulated on disk. We received strong feedback that the experience was undesirable. To address this feedback, changes were made to the installer in .NET Core 3.0.

In .NET Core 3.0 and later versions, new major and minor releases continue to install side by side with earlier major and minor releases. 

**_Successfully installation of a new patch version will remove any earlier patches for the same minor release._** 

For example, installing 3.0.2 when you already have 3.0.1 installed will result in 3.0.2 replacing 3.0.1.

Customers that have a strong business need to be conservative and protect against any possibility of an update delivering a breaking change can isolate their deployments by creating [Self-Contained deployments (SCD)](publish.md#self-contained-deployments-scd).

<br/>

## Roll-Forward
Starting with Core 2.1, .NET Core updates support patch roll-forward. When you create a self-contained deployment, .NET Core tools automatically download the latest servicing version of .NET Core from NuGet.org and include this runtime with your application targets.

.NET Core 3.0 introduces an opt-in feature that allows your app to roll-forward to the latest major version of .NET Core. A new setting has also been added to control how roll-forward is applied to your app. 

For more information about roll-forward in the .NET Core runtime, see [Runtime Roll Forward](https://docs.microsoft.com/dotnet/core/whats-new/dotnet-core-3-0#major-version-roll-forward).

For more information about roll-forward in self-contained deployments, see [Self-contained deployment runtime roll forward](https://docs.microsoft.com/dotnet/core/deploying/runtime-patch-selection).

For more information about runtime binding, see [Runtime Binding Behavior](https://github.com/dotnet/designs/blob/master/accepted/runtime-binding.md).


<br/>

## See Also

[Roll-forward policies for .NET Core SDK resolution](https://github.com/dotnet/designs/pull/71)

[Overview of how .NET Core is versioned](https://docs.microsoft.com/dotnet/core/versions/)

[Select the .NET Core version to use](https://docs.microsoft.com/dotnet/core/versions/selection)

