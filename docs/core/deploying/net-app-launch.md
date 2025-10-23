---
title: Launch .NET apps
description: Learn about the recommended practices for launching .NET applications, including differences between self-contained and framework-dependent deployment, and advantages of using the apphost.
author: adegeo
ms.author: adegeo
ms.date: 10/23/2025
ai-usage: ai-assisted
---

# Launch .NET apps

This article covers recommendations for launching .NET applications. There are two main form factors for .NET app deployment:

- Self-contained
- Framework-dependent

Self-contained apps are the simplest. They have a platform-native entry executable and contain all files needed for their execution. They match the native platform standard for launching executables. They don't support configuration beyond the native platform convention.

Framework-dependent apps don't contain a runtime themselves and instead need a separate runtime located somewhere on the machine. This is the most complicated scenario with the most configuration options.

## Framework-dependent apps

There are two ways to run framework-dependent apps: through the apphost launcher and via `dotnet app.dll`. Whenever possible, it's recommended to use the apphost. There are a number of advantages to using the apphost:

- Executables appear like standard native platform executables.
- Executable names are preserved in the process names, meaning apps can be easily recognized based on their names.
- Because the apphost is a native binary, native assets like manifests can be attached to them.
- Apphost has available low-level security mitigations applied by default that makes it more secure. For example, Control Flow Guard is enabled on Windows, and Control-flow Enforcement Technology (CET) shadow stack is enabled by default starting with .NET 9. Mitigations applied to `dotnet` are the lowest common denominator of all supported runtimes.

The apphost generally uses a global install of the .NET runtime, where install locations vary by platform. For more information about runtime discovery and install locations, see [Troubleshoot app launch failures](../runtime-discovery/troubleshoot-app-launch.md).

The .NET runtime path can also be customized on a per-execution basis. The `DOTNET_ROOT` environment variable can be used to point to the custom location. For more information about all `DOTNET_ROOT` configuration options, see [.NET environment variables](../tools/dotnet-environment-variables.md).

In general, the best practice for using `DOTNET_ROOT` to set the runtime location for an app is to:

1. Clear `DOTNET_ROOT` environment variables first, meaning all environment variables that start with the text `DOTNET_ROOT`.
1. Set `DOTNET_ROOT`, and only `DOTNET_ROOT`, to the target path.
1. Execute the target apphost.

## See also

- [.NET application publishing overview](index.md)
- [Troubleshoot app launch failures](../runtime-discovery/troubleshoot-app-launch.md)
- [.NET environment variables](../tools/dotnet-environment-variables.md)
- [Security features of Native AOT](native-aot/security.md)
