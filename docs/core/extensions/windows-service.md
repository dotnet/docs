---
title: Create a Windows Service using BackgroundService in .NET
description: Learn how to create a Windows Service using the BackgroundService in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 05/24/2021
ms.topic: tutorial
---

# Create a Windows Service using `BackgroundService` in .NET

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
  - Feel free to use the [Visual Studio IDE](https://visualstudio.microsoft.com)

## See also

There are several related tutorials to consider:

- <xref:Microsoft.Extensions.Hosting.BackgroundService> subclass tutorials:
  - Queue Service
  - Scoped Service
  - Windows Service
- Custom <xref:Microsoft.Extensions.Hosting.IHostedService> implementation:
  - Timer Service
