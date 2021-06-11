---
title: Needed changes before porting code
description: Make the necessary changes to build targeting .NET Core.
author: stebon
ms.date: 06/10/2021
---
# Overview

[content needed]

## Upgrade to required tooling

[content needed]

## Update .NET Framework target version

If your code isn't targeting .NET Framework 4.7.2, we recommended that you retarget to .NET Framework 4.7.2. This ensures the availability of the latest API alternatives for cases where .NET Standard doesn't support existing APIs.

For each of the projects you wish to port, do the following in Visual Studio:

01. Right-click on the project and select **Properties**.
01. In the **Target Framework** dropdown, select **.NET Framework 4.7.2**.
01. Recompile the project.

Because your projects now target .NET Framework 4.7.2, use that version of the .NET Framework as your base for porting code.

## Change to PackageReference format

[content needed]

## Update dependencies

[content needed]

## Convert to SDK style project format

[content needed]
