---
title: Use the Windows Compatibility Pack to port code
description: Learn about the Windows Compatibility Pack and how can you use it to port existing .NET Framework code to .NET 5 and .NET Core 3.1.
author: terrajobst
ms.date: 05/04/2021
---
# Use the Windows Compatibility Pack to port code to .NET 5+

Some of the most common issues found when porting existing code from .NET Framework to .NET are dependencies on APIs and technologies that are only found in .NET Framework. The *Windows Compatibility Pack* provides many of these technologies, so it's much easier to build .NET applications and .NET Standard libraries.

The compatibility pack is a logical [extension of .NET Standard 2.0](../whats-new/dotnet-core-2-0.md#api-changes-and-library-support) that significantly increases the API set. Existing code compiles with almost no modifications. To keep its promise of "the set of APIs that all .NET implementations provide", .NET Standard doesn't include technologies that can't work across all platforms, such as registry, Windows Management Instrumentation (WMI), or reflection emit APIs. The Windows Compatibility Pack sits on top of .NET Standard and provides access to these Windows-only technologies. It's especially useful for customers that want to move to .NET but plan to stay on Windows, at least as a first step. In that scenario, you can use Windows-only technologies removes the migration hurdle.

## Package contents

The Windows Compatibility Pack is provided via the [Microsoft.Windows.Compatibility NuGet package](https://www.nuget.org/packages/Microsoft.Windows.Compatibility) and can be referenced from projects that target .NET or .NET Standard.

It provides about 20,000 APIs, including Windows-only and cross-platform APIs from the following technology areas:

- Code Pages
- CodeDom
- Configuration
- Directory Services
- Drawing
- ODBC
- Permissions
- Ports
- Windows Access Control Lists (ACL)
- Windows Communication Foundation (WCF)
- Windows Cryptography
- Windows EventLog
- Windows Management Instrumentation (WMI)
- Windows Performance Counters
- Windows Registry
- Windows Runtime Caching
- Windows Services

For more information, see the [specification of the compatibility pack](https://github.com/dotnet/designs/blob/main/accepted/2018/compat-pack/compat-pack.md).

## Get started

1. Before porting, make sure to take a look at the [Porting process](index.md).

2. When porting existing code to .NET or .NET Standard, install the [Microsoft.Windows.Compatibility NuGet package](https://www.nuget.org/packages/Microsoft.Windows.Compatibility).

   If you want to stay on Windows, you're all set.

3. If you want to run the .NET application or .NET Standard library on Linux or macOS, use the [Platform compatibility analyzer](../../standard/analyzers/platform-compat-analyzer.md) to find usage of APIs that won't work cross-platform.

4. Either remove the usages of those APIs, replace them with cross-platform alternatives, or guard them using a platform check, like:

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

For a demo, check out the [Channel 9 video of the Windows Compatibility Pack](/Events/Connect/2017/T123).

## See also

- [Overview of porting from .NET Framework to .NET](index.md)
- [ASP.NET to ASP.NET Core migration](/aspnet/core/migration/proper-to-2x)
- [Migrate .NET Framework WPF apps to .NET](/dotnet/desktop/wpf/migration/convert-project-from-net-framework?view=netdesktop-6.0&preserve-view=true)
- [Migrate .NET Framework Windows Forms apps to .NET](/dotnet/desktop/winforms/migration/?view=netdesktop-6.0&preserve-view=true)
