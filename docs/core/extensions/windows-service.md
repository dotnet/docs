---
title: Create a Windows Service using BackgroundService
description: Learn how to create a Windows Service using the BackgroundService in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 05/25/2021
ms.topic: tutorial
---

# Create a Windows Service using `BackgroundService`

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Publish a .NET app as a single file executable.
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

In order to interop with native Windows Services from .NET <xref:Microsoft.Extensions.Hosting.IHostedService> implementations, you'll need to install the [`Microsoft.Extensions.Hosting.WindowsServices` NuGet package](nuget.org/packages/Microsoft.Extensions.Hosting.WindowsServices).

To install this from Visual Studio, use the **Manage NuGet Packages...** dialog. Search for "Microsoft.Extensions.Hosting.WindowsServices", and install it. If you're rather use the .NET CLI, run the `dotnet add package` command:

```dotnetcli
dotnet add package Microsoft.Extensions.Hosting.WindowsServices
```

## See also

- [Worker Services in .NET](workers.md)
- [Create a Queue Service](queue-service.md)
- [Use scoped services within a `BackgroundService`](scoped-service.md)
- [Implement the `IHostedService` interface](timer-service.md)
