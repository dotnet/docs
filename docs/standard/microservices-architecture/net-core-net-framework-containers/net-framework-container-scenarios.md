---
title: When to choose .NET Framework for Docker containers
description: .NET Microservices Architecture for Containerized .NET Applications | When to choose .NET Framework for Docker containers
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/26/2017
ms.prod: .net-core
ms.technology: dotnet-docker
---
# When to choose .NET Framework for Docker containers

While .NET Core offers significant benefits for new applications and application patterns, .NET Framework will continue to be a good choice for many existing scenarios.

## Migrating existing applications directly to a Docker container

You might want to use Docker containers just to simplify deployment, even if you are not creating microservices. For example, perhaps you want to improve your DevOps workflow with Docker—containers can give you better isolated test environments and can also eliminate deployment issues caused by missing dependencies when you move to a production environment. In cases like these, even if you are deploying a monolithic application, it makes sense to use Docker and Windows Containers for your current .NET Framework applications.

In most cases, you will not need to migrate your existing applications to .NET Core; you can use Docker containers that include the full .NET Framework. However, a recommended approach is to use .NET Core as you extend an existing application, such as writing a new service in ASP.NET Core.

## Using third-party .NET libraries or NuGet packages not available for .NET Core

Third-party libraries are quickly embracing the [.NET Standard](https://docs.microsoft.com/dotnet/standard/net-standard), which enables code sharing across all .NET flavors, including .NET Core. With the .NET Standard version 2.0, this will be even easier, because the .NET Core API surface will become significantly bigger. Your .NET Core applications will be able to directly use existing .NET Framework libraries.

Be aware that whenever you run a library or process based on the full .NET Framework, because of its dependencies on Windows, the container image used for that application or service will need to be based on a Windows Container image.

## Using.NET technologies not available for .NET Core 

Some .NET Framework technologies are not available in the current version of .NET Core (version 1.1 as of this writing). Some of them will be available in later .NET Core releases (.NET Core 2.0), but others do not apply to the new application patterns targeted by .NET Core and might never be available.

The following list shows most of the technologies that are not available in .NET Core 1.1:

-   ASP.NET Web Forms. This technology is only available on .NET Framework. Currently there are no plans to bring ASP.NET Web Forms to .NET Core.

-   ASP.NET Web Pages. This technology is slated to be included in a future .NET Core release, as explained in the [.NET Core roadmap.](https://github.com/aspnet/Home/wiki/Roadmap)

-   ASP.NET SignalR. As of the .NET Core 1.1 release (November 2016), ASP.NET SignalR is not available for ASP.NET Core (neither client nor server). There are plans to include it in a future release, as explained in the .NET Core roadmap. A preview is available at the [Server-side](https://github.com/aspnet/SignalR-Server) and [Client Library](https://github.com/aspnet/SignalR-Client-Net) GitHub repositories.

-   WCF services. Even when a [WCF-Client library](https://github.com/dotnet/wcf) is available to consume WCF services from .NET Core (as of early 2017), the WCF server implementation is only available on .NET Framework. This scenario is being considered for future releases of .NET Core.

-   Workflow-related services. Windows Workflow Foundation (WF), Workflow Services (WCF + WF in a single service), and WCF Data Services (formerly known as ADO.NET Data Services) are only available on .NET Framework. There are currently no plans to bring them to .NET Core.

-   Language support. As of the release of Visual Studio 2017, Visual Basic and F\# do not have tooling support for .NET Core, but this support is planned for updated versions of Visual Studio.

In addition to the technologies listed in the official [.NET Core roadmap](https://github.com/aspnet/Home/wiki/Roadmap), other features might be ported to .NET Core. For a full list, look at the items tagged as [port-to-core](https://github.com/dotnet/corefx/issues?q=is%3Aopen+is%3Aissue+label%3Aport-to-core) on the CoreFX GitHub site. Note that this list does not represent a commitment from Microsoft to bring those components to .NET Core—the items simply capture requests from the community. If you care about any of the components listed above, consider participating in the discussions on GitHub so that your voice can be heard. And if you think something is missing, please [file a new issue in the CoreFX repository](https://github.com/dotnet/corefx/issues/new).

## Using a platform or API that does not support .NET Core

Some Microsoft or third-party platforms do not support .NET Core. For example, some Azure services provide an SDK that is not yet available for consumption on .NET Core. This is temporary, because all Azure services will eventually use .NET Core. For example, the [Azure DocumentDB SDK for .NET Core](https://www.nuget.org/packages/Microsoft.Azure.DocumentDB.Core/1.2.1) was released as a preview on November 16, 2016, but it is now generally available (GA) as a stable version.

In the meantime, you can always use the equivalent REST API from the Azure service instead of the client SDK.

### Additional resources

-   **.NET Core Guide**
    [*https://docs.microsoft.com/dotnet/core/index*](https://docs.microsoft.com/dotnet/core/index)

-   **Porting from .NET Framework to .NET Core**
    [*https://docs.microsoft.com/dotnet/core/porting/index*](https://docs.microsoft.com/dotnet/core/porting/index)

-   **.NET Framework on Docker Guide**
    [*https://docs.microsoft.com/dotnet/framework/docker/*](https://docs.microsoft.com/dotnet/framework/docker/)

-   **.NET Components Overview**
    [*https://docs.microsoft.com/dotnet/standard/components*](https://docs.microsoft.com/dotnet/standard/components)




>[!div class="step-by-step"]
[Previous] (net-core-container-scenarios.md)
[Next] (container-framework-choice-factors.md)
