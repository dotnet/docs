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
.NET Core major/minor releases as well as servicing updates always ship as the full product installers i.e. the installer carries the entire product even if only a subset of the files are updated.

## Side by Side installs versus in-place updates
Prior to .NET Core 3.0, all .NET Core releases including servicing updates were fully side by side installs i.e. if you have a major/minor version installed and then install another major/minor release or even a patch release for the major/minor both the first and patch versions would always be installed in discrete install locations. 
For example, installing 2.2.14 when you already have 2.2.13 installed will result in both 2.2.13 and 2.2.14 being present on the computer. 
As multiple updates shipped and were installed customer feedback strongly suggested that the older experience was not desirable, so changes have been made to the installer in .NET Core 3.0.
Starting with .NET Core 3.0, new major/minor releases will continue to install side by side with earlier major/minor versions, but patch versions for a previously released major/minor version will upon successful installation remove any earlier patches for the same major minor. 
For example installing 3.0.2 when you already have 3.0.1 installed will result in 3.0.2 replacing 3.0.1.

## Roll Forward
Starting with Core 2.1, .NET Core updates support patch roll forward. When you create a self-contained deployment, .NET Core tools automatically include the latest serviced runtime of the .NET Core version that your application targets (this is downloaded automatically from NuGet.org).
.NET Core 3.0 introduces an opt-in feature that allows your app to roll forward to the latest major version of .NET Core. Additionally, a new setting has been added to control how roll forward is applied to your app. This can be configured in the following ways:
* Project file property: RollForward
* Runtime configuration file property: rollForward
* Environment variable: DOTNET_ROLL_FORWARD
* Command-line argument: --roll-forward

One of the following values must be specified. If the setting is omitted, Minor is the default.
* LatestPatch  
Roll forward to the highest patch version. This disables minor version roll forward.
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
For more information about roll forward at run time refer to the document Self-contained deployment runtime roll forward.
