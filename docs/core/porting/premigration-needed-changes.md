---
title: Needed changes before porting code
description: Make the necessary changes to build targeting .NET Core.
author: stebon
ms.date: 06/10/2021
---
# Overview

Make the needed changes to build and run a .NET application before beginning the work to port your code. All of these changes can be done while still building and running a .NET Framework application.

## Upgrade to required tooling

Upgrade to a version of MSBuild/Visual Studio that supports the version of .NET you will be targeting. See [Tooling Requirements](tooling-requirements.md) for more info.

## Update .NET Framework target version

If your code isn't targeting .NET Framework 4.7.2, we recommended that you retarget to .NET Framework 4.7.2. This ensures the availability of the latest API alternatives for cases where .NET Standard doesn't support existing APIs.

For each of the projects you wish to port, do the following in Visual Studio:

01. Right-click on the project and select **Properties**.
01. In the **Target Framework** dropdown, select **.NET Framework 4.7.2**.
01. Recompile the project.

Because your projects now target .NET Framework 4.7.2, use that version of the .NET Framework as your base for porting code.

## Change to PackageReference format

Convert all references to the [PackageReference](/nuget/consume-packages/package-references-in-project-files) format.

## Convert to SDK style project format

Convert your projects to the [SDK-style format](../project-sdk/overview.md).

## Update dependencies

Update dependencies to their latest version available, and to .NET Standard version where possible.
