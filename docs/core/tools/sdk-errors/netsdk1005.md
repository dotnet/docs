---
title: "NETSDK1005 and NETSDK1047: Asset file is missing target"
description: How to resolve the issue of an asset file missing a target.
author: sfoslund
ms.topic: error-reference
ms.date: 12/17/2020
f1_keywords:
- NETSDK1005
- NETSDK1047
---
# NETSDK1005 and NETSDK1047: Asset file is missing target

**This article applies to:** ✔️ .NET Core 2.1.100 SDK and later versions

When the .NET SDK issues error NETSDK1005 or NETSDK1047, the project's assets file is missing information on one of your target frameworks. NuGet writes a file named *project.assets.json* in the *obj* folder, and the .NET SDK uses it to get information about packages to pass into the compiler. In .NET 5, NuGet added a new field named `TargetFrameworkAlias`, so earlier versions of MSBuild or NuGet generate an assets file without the new field. For more information, see [error NETSDK1005](https://developercommunity.visualstudio.com/content/problem/1248649/error-netsdk1005-assets-file-projectassetsjson-doe.html).

Here are some actions you can take that may resolve the error:

* Make sure that you're using MSBuild version 16.8 or later and NuGet version 5.8 or later, and restore the project after updating your tools. When you're using NuGet version 5.8 or later, you should be using Visual Studio 2019 version 16.8 or later, MSBuild version 16.8 or later, and .NET 5 SDK or later.

* If you get the error while building a project in Visual Studio 2019 for the first time after installing version 16.8 or after changing the project's target framework, build the project a second time.

* Delete the *obj* folder before building the project.

* Make sure that the missing target value is included in the `TargetFrameworks` property of your project.
