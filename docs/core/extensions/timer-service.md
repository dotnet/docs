---
title: Implement the IHostedService interface in .NET
description: Learn how to implement a custom IHostedService interface with .NET.
author: IEvangelist
ms.author: dapine
ms.date: 05/24/2021
ms.topic: tutorial
---

# Implement the `IHostedService` interface in .NET

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Implement the <xref:Microsoft.Extensions.Hosting.IHostedService>, and <xref:System.IAsyncDisposable> interfaces
> - Create a timer-based service
> - Register the custom implemenation with dependency injection and logging

## See also

There are several related tutorials to consider:

- <xref:Microsoft.Extensions.Hosting.BackgroundService> subclass tutorials:
  - Queue Service
  - Scoped Service
  - Windows Service
- Custom <xref:Microsoft.Extensions.Hosting.IHostedService> implementation:
  - Timer Service
