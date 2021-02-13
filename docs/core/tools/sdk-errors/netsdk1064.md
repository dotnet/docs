---
title: "NETSDK1064: Package not found"
description: Learn about .NET SDK error NETSDK1064, which occurs when a package is not found.
ms.topic: error-reference
ms.date: 02/10/2021
f1_keywords:
- NETSDK1064
---
# NETSDK1064: Package not found

**This article applies to:** ✔️ .NET Core 2.1.100 SDK and later versions

This error occurs when the build tools can't find a NuGet package that's needed to build a project. This is typically due to a package restore issue. The full error message is similar to the following example:

> NETSDK1064: Package 'PackageName', version x.x.x was not found. It might have been deleted since NuGet restore. Otherwise, NuGet restore might have only partially completed, which might have been due to maximum path length restrictions.

Here are some actions you can take to resolve this error:

* Add the `/restore` option to your *MSBuild.exe* command. Don't use `/t:Restore;Build`, as that can result in subtle bugs. An alternative is to use the `dotnet build` command, since it automatically does a package restore.
* If you're running package restore by using Visual Studio 2019 or *MSBuild.exe*, the error may be caused by maximum path length restrictions. For more information, see [Long Path Support (NuGet CLI)](/nuget/reference/cli-reference/cli-ref-long-path) and [NuGet/Home issue #3324](https://github.com/NuGet/Home/issues/3324).
* If you're restoring with x86 *nuget.exe* and building with x64 *MSBuild.exe*, the mismatched bitness could cause this error. The build can't find the packages that the restore claims it acquired because the path in *project.assets.json* doesn't work in a process of different bitness. To resolve the error, use tools of the same bitness for restore and build, or configure NuGet to restore packages to a folder that doesn't virtualize between x86 and x64. For more information, see [dotnet/core issue #4332](https://github.com/dotnet/core/issues/4332).
* If you're building a Docker image, make sure the *.dockerignore* file ignores the *bin* and *obj* directories. For more information, see [NETSDK1064: Package DnsClient, 1.2.0 was not found](https://stackoverflow.com/questions/61167032/error-netsdk1064-package-dnsclient-1-2-0-was-not-found).
