---
author: IEvangelist
ms.topic: include
ms.date: 04/07/2021
ms.author: dapine
ms.custom: include
---

> [!TIP]
> With regard to dependency injection, when registering services in an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>, the [service lifetime](../../../core/extensions/dependency-injection.md#service-lifetimes) is managed implicitly on your behalf. The <xref:System.IServiceProvider> and corresponding <xref:Microsoft.Extensions.Hosting.IHost> orchestrate resource cleanup. Specifically, implementations of <xref:System.IDisposable> and <xref:System.IAsyncDisposable> are properly disposed at the end of their specified lifetime.
>
> For more information, see [Dependency injection in .NET](../../../core/extensions/dependency-injection.md).
