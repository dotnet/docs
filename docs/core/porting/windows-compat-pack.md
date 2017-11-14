---
title: Porting to .NET Core - Using the Windows Compatibility Pack
description: Porting to .NET Core - Using the Windows Compatibility Pack
keywords: .NET, .NET Core, Windows, Compatibility
author: immol
ms.author: mairaw
ms.date: 11/13/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: ffa28aed-45dd-4b02-965f-768c467829c3
---

# Using the Windows Compatibility Pack

Many customers have reported that the primary reason why they have trouble
porting to .NET Core is that they depend on APIs and technologies that only
exist in .NET Framework. The *Windows Compatibility Pack* is about providing a
good chunk of these technologies so that building .NET Core applications as well
as .NET Standard libraries becomes much more viable for existing code.

This is a logical [extension of .NET Standard 2.0][API Expansion] which
significantly increased the API set to ensure code largely already compiles
as-is. But in order to keep .NET Standard understandable, this didn't include
technologies that can't work across all platforms, such as registry, WMI, or
reflection emit APIs.

The *Windows Compatibility Pack* sits above .NET Standard and is thus free to
provide access to technologies that are Windows only. It is especially useful
for customers that want to move to .NET Core but plan to stay on Windows as a
first step. In that scenario, not being able to use Windows-only technologies is
only a migration hurdle with zero architectural benefits.

## Contents

The *Windows Compatibility Pack* is provided via the NuGet Package
[Microsoft.Windows.Compatibility] and can be referenced from .NET Core as well
as .NET Standard.

It provides about 20,000 APIs, including Windows-only as well as cross-platform
APIs:

* ACLs
* Code Pages
* CodeDom
* Configuration
* Crypto
* DirectoryServices
* Drawing
* EventLog
* MEF
* Odbc
* Perf Counters
* Permissions
* Ports
* Registry
* Runtime Caching
* WCF
* Windows Services

For more details, take a look at the [spec of the compatibility pack][proposal].

## Getting Started

1. When porting existing code to .NET Core or .NET Standard, install the NuGet
   package [Microsoft.Windows.Compatibility].
2. If you want to stay on Windows, you're all set.
3. If you want to run the .NET Core application or .NET Standard library on
   Linux or macOS, use the [API Analyzer] to find usage of APIs that won't
   work cross-platform.
4. Either remove the usages of those APIs, replace them with cross-platform
   alternatives, or guard them using a platform check, like:
    ```CSharp
    private static string GetLoggingPath()
    {
        // If we're on Windows and the desktop app has configured a logging path, we'll use that.
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Fabrikam\AssetManagement"))
            {
                if (key?.GetValue("LoggingDirectoryPath") is string configuredPath)
                    return configuredPath;
            }
        }

        // We're either not on Windows or no logging path was configured, so we'll use the location
        // for non-roaming user-specific data files.
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return Path.Combine(appDataPath, "Fabrikam", "AssetManagement", "Logging");
    }
    ```

For a demo, check out the [Channel 9 video of the Windows Compatibility Pack][Video].

[Proposal]: https://github.com/dotnet/designs/blob/master/accepted/compat-pack/compat-pack.md
[Microsoft.Windows.Compatibility]: https://www.nuget.org/packages/Microsoft.Windows.Compatibility
[API Expansion]: ../whats-new/index.md#api-changes-and-library-support
[API Analyzer]: https://blogs.msdn.microsoft.com/dotnet/2017/10/31/introducing-api-analyzer/
[Video]: https://channel9.msdn.com
