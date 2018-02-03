---
title: Porting to .NET Core - Using the Windows Compatibility Pack
description: Learn about the Windows Compatibility Pack and how can you use it to port existing .NET Framework code to .NET Core
keywords: .NET, .NET Core, Windows, Compatibility
author: terrajobst
ms.author: mairaw
ms.date: 11/13/2017
ms.topic: article
ms.prod: .net-core
ms.workload: 
  - dotnetcore
---

# Using the Windows Compatibility Pack

One of the most common issues that developers face when porting their existing
code to .NET Core is that they depend on APIs and technologies that only exist
in the .NET Framework. The *Windows Compatibility Pack* is about providing many
of these technologies so that building .NET Core applications as well as .NET
Standard libraries becomes much more viable for existing code.

This package is a logical [extension of .NET Standard 2.0](../whats-new/index.md#api-changes-and-library-support)
that significantly increases API set and existing code compiles with almost no
modifications. But in order to keep the promise of .NET Standard ("it is the set
of APIs that all .NET implementations provide"), this didn't include
technologies that can't work across all platforms, such as registry, Windows
Management Instrumentation (WMI), or reflection emit APIs.

The *Windows Compatibility Pack* sits on top of .NET Standard and provides
access to technologies that are Windows only. It's especially useful for
customers that want to move to .NET Core but plan to stay on Windows as a first
step. In that scenario, not being able to use Windows-only technologies is only
a migration hurdle with zero architectural benefits.

## Package contents

The *Windows Compatibility Pack* is provided via the NuGet Package
[Microsoft.Windows.Compatibility](https://www.nuget.org/packages/Microsoft.Windows.Compatibility)
and can be referenced from projects targeting .NET Core or .NET Standard.

It provides about 20,000 APIs, including Windows-only as well as cross-platform
APIs from the following technology areas:

* Code Pages
* CodeDom
* Configuration
* Directory Services
* Drawing
* ODBC
* Permissions
* Ports
* Windows Access Control Lists (ACL)
* Windows Communication Foundation (WCF)
* Windows Cryptography
* Windows EventLog
* Windows Management Instrumentation (WMI)
* Windows Performance Counters
* Windows Registry
* Windows Runtime Caching
* Windows Services

For more information, see the [spec of the compatibility pack](https://github.com/dotnet/designs/blob/master/accepted/compat-pack/compat-pack.md).

## Get started

1. Before porting, make sure to take a look at the [Porting Process](index.md).

2. When porting existing code to .NET Core or .NET Standard, install the NuGet
   package [Microsoft.Windows.Compatibility](https://www.nuget.org/packages/Microsoft.Windows.Compatibility).

3. If you want to stay on Windows, you're all set.

4. If you want to run the .NET Core application or .NET Standard library on
   Linux or macOS, use the [API Analyzer](https://blogs.msdn.microsoft.com/dotnet/2017/10/31/introducing-api-analyzer/)
   to find usage of APIs that won't work cross-platform.

5. Either remove the usages of those APIs, replace them with cross-platform
   alternatives, or guard them using a platform check, like:

    ```csharp
    private static string GetLoggingPath()
    {
        // Verify the code is running on Windows.
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Fabrikam\AssetManagement"))
            {
                if (key?.GetValue("LoggingDirectoryPath") is string configuredPath)
                    return configuredPath;
            }
        }

        // This is either not running on Windows or no logging path was configured,
        // so just use the path for non-roaming user-specific data files.
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return Path.Combine(appDataPath, "Fabrikam", "AssetManagement", "Logging");
    }
    ```

For a demo, check out the [Channel 9 video of the Windows Compatibility Pack](https://channel9.msdn.com/Events/Connect/2017/T123).

