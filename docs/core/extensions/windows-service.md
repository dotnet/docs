---
title: Create a Windows Service using BackgroundService
description: Learn how to create a Windows Service using the BackgroundService in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 05/25/2021
ms.topic: tutorial
---

# Create a Windows Service using `BackgroundService`

.NET Framework developers are probably familiar with Windows Service apps. Before .NET Core, and .NET 5+ developers who relied on .NET Framework could create Windows Services to perform background tasks, or execute long-running processes. This functionality is still available and you can create Worker Services that run as a Windows Service.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Publish a .NET worker app as a single file executable.
> - Create a Windows Service.
> - Install the `BackgroundService` app as a Windows Service.
> - Start and stop the Windows Service.
> - Uninstall the Windows Service.
> - View event logs.

## Prerequisites

- The [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- A Windows OS
- A .NET integrated development environment (IDE)
  - Feel free to use [Visual Studio](https://visualstudio.microsoft.com)

<!-- ## Create a new project -->
[!INCLUDE [file-new-worker](includes/file-new-worker.md)]

## Install NuGet package

In order to interop with native Windows Services from .NET <xref:Microsoft.Extensions.Hosting.IHostedService> implementations, you'll need to install the [`Microsoft.Extensions.Hosting.WindowsServices` NuGet package](https://nuget.org/packages/Microsoft.Extensions.Hosting.WindowsServices).

To install this from Visual Studio, use the **Manage NuGet Packages...** dialog. Search for "Microsoft.Extensions.Hosting.WindowsServices", and install it. If you're rather use the .NET CLI, run the `dotnet add package` command:

```dotnetcli
dotnet add package Microsoft.Extensions.Hosting.WindowsServices
```

For more information on the .NET CLI add package command, see [`dotnet add package`](../tools/dotnet-add-package.md).

## Create the service

Replace the existing `Worker` from the template with the following C# code, and rename the file to *WindowsBackgroundService.cs*:

:::code source="snippets/workers/windows-service/WindowsBackgroundService.cs":::

## Publish the app

To install the .NET Worker Service app as a Windows Service, it will need to be published as a single file executable.

:::code language="xml" source="snippets/workers/windows-service/App.WindowsService.csproj" highlight="7-11":::

The preceding highlighted lines of the project file define the following behaviors:

- `<OutputType>exe</OutputType>`: Creates a console application.
- `<PublishSingleFile>true</PublishSingleFile>`: Enables single-file publishing.
- `<RuntimeIdentifier>win-x64</RuntimeIdentifier>`: Specifies the [RID](../rid-catalog.md) of `win-x64`.
- `<PlatformTarget>x64</PlatformTarget>`: Specify the target platform CPU of 64-bit.
- `<IncludeNativeLibrariesForSelfExtract>true</IncludeNativeLibrariesForSelfExtract>`: Embeds all required .dll files into the resulting .exe file.

## Install as Windows Service

## Uninstall the app

## Verify service functionality

The 

## See also

- [Worker Services in .NET](workers.md)
- [Create a Queue Service](queue-service.md)
- [Use scoped services within a `BackgroundService`](scoped-service.md)
- [Implement the `IHostedService` interface](timer-service.md)
