---
title: Use scoped services within a BackgroundService in .NET
description: Learn how to use scoped services within a BackgroundService in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 05/24/2021
ms.topic: tutorial
---

# Use scoped services within a `BackgroundService` in .NET

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Resolve scoped dependencies in a singleton <xref:Microsoft.Extensions.Hosting.BackgroundService>
> - Delegate work to a scoped service
> - `override` the <xref:Microsoft.Extensions.Hosting.BackgroundService.StopAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>

## See also

There are several related tutorials to consider:

- <xref:Microsoft.Extensions.Hosting.BackgroundService> subclass tutorials:
  - Queue Service
  - Scoped Service
  - Windows Service
- Custom <xref:Microsoft.Extensions.Hosting.IHostedService> implementation:
  - Timer Service
