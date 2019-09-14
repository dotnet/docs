---
title: .NET Core Deployment Experiences
description: .NET Core Deployment Experiences
author: jamshedd
ms.author: jamshedd
ms.date: 09/06/2019
ms.custom: 
---
# .NET Core Deployment Experiences

## Full Installers
.NET Core major and minor releases as well as servicing updates always ship as the full product installers, that is the installer carries the entire product even if only a subset of the files is updated.

## Side by Side installs versus in-place updates
Before .NET Core 3.0, all .NET Core releases including servicing updates were fully side-by-side installs. If you had installed a minor version, and then installed another minor release or even a patch release for the minor release, both the original and patch versions would always be installed in discrete install locations. 

For example, installing the .NET Core 2.2.14 update when you already have the .NET Core 2.2.13 update installed will result in both .NET Core 2.2.13 and .NET Core 2.2.14 being present on the computer. 

As customers installed multiple updates and the updates accumulated on disk, we received strong feedback that the experience was not desirable. Therefore, changes were made to the installer in .NET Core 3.0.

In .NET Core 3.0 and later versions, new major and minor releases continue to install side by side with earlier major and minor releases. **_Patch versions for a previously released minor version will upon successful installation remove any earlier patches for the same minor release._** 

For example, installing 3.0.2 when you already have 3.0.1 installed will result in 3.0.2 replacing 3.0.1.


## Roll-Forward
Starting with Core 2.1, .NET Core updates support patch roll-forward. When you create a self-contained deployment, .NET Core tools automatically include the latest serviced runtime of the .NET Core version that your application targets. The latest version is automatically downloaded from NuGet.org.
.NET Core 3.0 introduces an opt-in feature that allows your app to roll-forward to the latest major version of .NET Core. Additionally, a new setting has been added to control how roll-forward is applied to your app. Roll-forward can be configured in the following ways:
* Project file property: RollForward
* Runtime configuration file property: rollForward
* Environment variable: DOTNET_ROLL_FORWARD
* Command-line argument: --roll-forward

One of the following values must be specified. If the setting is omitted, Minor is the default.
* LatestPatch  
Roll forward to the highest patch version. This value disables minor version roll-forward.
* Minor  
Roll forward to the lowest higher minor version, if requested minor version is missing. If the requested minor version is present, then the LatestPatch policy is used.
* Major  
Roll forward to lowest higher major version, and lowest minor version, if requested major version is missing. If the requested major version is present, then the Minor policy is used.
* LatestMinor  
Roll forward to highest minor version, even if requested minor version is present. Intended for component hosting scenarios.
* LatestMajor  
Roll forward to highest major and highest minor version, even if requested major is present. Intended for component hosting scenarios.
* Disable  
Don't roll forward. Only bind to specified version. This policy isn't recommended for general use because it disables the ability to roll forward to the latest patches. This value is only recommended for testing.

Besides the Disable setting, all settings will use the highest available patch version.

For more information about roll-forward at run time, see [Self-contained deployment runtime roll-forward](https://docs.microsoft.com/dotnet/core/deploying/runtime-patch-selection).
