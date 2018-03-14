---
title: When to choose .NET Framework for Docker containers
description: .NET Microservices Architecture for Containerized .NET Applications | When to choose .NET Framework for Docker containers
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 10/18/2017
ms.prod: .net-core
ms.technology: dotnet-docker
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# When to choose .NET Framework for Docker containers

While .NET Core offers significant benefits for new applications and application patterns, .NET Framework will continue to be a good choice for many existing scenarios.

## Migrating existing applications directly to a Windows Server container

You might want to use Docker containers just to simplify deployment, even if you are not creating microservices. For example, perhaps you want to improve your DevOps workflow with Docker—containers can give you better isolated test environments and can also eliminate deployment issues caused by missing dependencies when you move to a production environment. In cases like these, even if you are deploying a monolithic application, it makes sense to use Docker and Windows Containers for your current .NET Framework applications.

In most cases for this scenario, you will not need to migrate your existing applications to .NET Core; you can use Docker containers that include the traditional .NET Framework. However, a recommended approach is to use .NET Core as you extend an existing application, such as writing a new service in ASP.NET Core.

## Using third-party .NET libraries or NuGet packages not available for .NET Core

Third-party libraries are quickly embracing the [.NET Standard](../../net-standard.md), which enables code sharing across all .NET flavors, including .NET Core. With the .NET Standard Library 2.0 and beyond the API surface compatibility across different frameworks has become significantly larger and in .NET Core 2.0 applications can also directly reference existing .NET Framework libraries (see [compat shim](https://github.com/dotnet/standard/blob/master/docs/faq.md#how-does-net-standard-versioning-work)).

However, even with that exceptional progression since .NET Standard 2.0 and .NET Core 2.0, there might be cases where certain NuGet packages need Windows to run and might not support .NET Core. If those packages are critical for your application, then you will need to use .NET Framework on Windows Containers.

## Using .NET technologies not available for .NET Core 

Some .NET Framework technologies are not available in the current version of .NET Core (version 2.0 as of this writing). Some of them will be available in later .NET Core releases (.NET Core 2.x), but others do not apply to the new application patterns targeted by .NET Core and might never be available.

The following list shows most of the technologies that are not available in .NET Core 2.0:

-   ASP.NET Web Forms. This technology is only available on .NET Framework. Currently there are no plans to bring ASP.NET Web Forms to .NET Core.

-   WCF services. Even when a [WCF-Client library](https://github.com/dotnet/wcf) is available to consume WCF services from .NET Core. as of mid-2017, the WCF server implementation is only available on .NET Framework. This scenario might be considered for future releases of .NET Core.

-   Workflow-related services. Windows Workflow Foundation (WF), Workflow Services (WCF + WF in a single service), and WCF Data Services (formerly known as ADO.NET Data Services) are only available on .NET Framework. There are currently no plans to bring them to .NET Core.

In addition to the technologies listed in the official [.NET Core roadmap](https://github.com/aspnet/Home/wiki/Roadmap), other features might be ported to .NET Core. For a full list, look at the items tagged as [port-to-core](https://github.com/dotnet/corefx/issues?q=is%3Aopen+is%3Aissue+label%3Aport-to-core) on the CoreFX GitHub site. Note that this list does not represent a commitment from Microsoft to bring those components to .NET Core — the items simply capture requests from the community. If you care about any of the components listed above, consider participating in the discussions on GitHub so that your voice can be heard. And if you think something is missing, please [file a new issue in the CoreFX repository](https://github.com/dotnet/corefx/issues/new).

## Using a platform or API that does not support .NET Core

Some Microsoft or third-party platforms do not support .NET Core. For example, some Azure services provide an SDK that is not yet available for consumption on .NET Core. This is temporary, because all Azure services will eventually use .NET Core. For example, the [Azure DocumentDB SDK for .NET Core](https://www.nuget.org/packages/Microsoft.Azure.DocumentDB.Core/1.2.1) was released as a preview on November 16, 2016, but it is now generally available (GA) as a stable version.

In the meantime, if any platform or service in Azure still doesn’t support .NET Core with its client API, you can use the equivalent REST API from the Azure service or the client SDK on .NET Framework.

### Additional resources

-   **.NET Core Guide**
    [*https://docs.microsoft.com/dotnet/core/index*](../../../core/index.md)

-   **Porting from .NET Framework to .NET Core**
    [*https://docs.microsoft.com/dotnet/core/porting/index*](../../../core/porting/index.md)

-   **.NET Framework on Docker Guide**
    [*https://docs.microsoft.com/dotnet/framework/docker/*](../../../framework/docker/index.md)

-   **.NET Components Overview**
    [*https://docs.microsoft.com/dotnet/standard/components*](../../components.md)




>[!div class="step-by-step"]
[Previous] (net-core-container-scenarios.md)
[Next] (container-framework-choice-factors.md)
