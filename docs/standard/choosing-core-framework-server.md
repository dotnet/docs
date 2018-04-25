---
title: Choose between .NET Core and .NET Framework for server apps
description: A guide on which implementation of .NET you should consider when building a server app in .NET.
author: cartermp
ms.author: mairaw
ms.date: 03/15/2018
ms.topic: article
ms.prod: .net
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Choosing between .NET Core and .NET Framework for server apps

There are two supported implementations for building server-side applications with .NET: .NET Framework and .NET Core. Both share many of the same components and you can share code across the two. However, there are fundamental differences between the two and your choice depends on what you want to accomplish.  This article provides guidance on when to use each.

Use .NET Core for your server application when:

* You have cross-platform needs.
* You are targeting microservices.
* You are using Docker containers.
* You need high-performance and scalable systems.
* You need side-by-side .NET versions per application.

Use .NET Framework for your server application when:

* Your app currently uses .NET Framework (recommendation is to extend instead of migrating).
* Your app uses third-party .NET libraries or NuGet packages not available for .NET Core.
* Your app uses .NET technologies that aren't available for .NET Core.
* Your app uses a platform that doesn’t support .NET Core.

## When to choose .NET Core

The following sections give a more detailed explanation of the previously stated reasons for picking .NET Core.

### Cross-platform needs

If your application (web/service) needs to run on multiple platforms (Windows, Linux, and macOS), use .NET Core.

.NET Core supports the previously mentioned operating systems as your development workstation. Visual Studio provides an Integrated Development Environment (IDE) for Windows and macOS. You can also use Visual Studio Code, which runs on macOS, Linux, and Windows. Visual Studio Code supports .NET Core, including IntelliSense and debugging. Most third-party editors, such as Sublime, Emacs, and VI, work with .NET Core. These third-party editors get editor IntelliSense using [Omnisharp](https://www.omnisharp.net/). You can also avoid any code editor and directly use the [.NET Core CLI tools](../core/tools/index.md), available for all supported platforms.

### Microservices architecture

A microservices architecture allows a mix of technologies across a service boundary. This technology mix enables a gradual embrace of .NET Core for new microservices that work with other microservices or services. For example, you can mix microservices or services developed with .NET Framework, Java, Ruby, or other monolithic technologies.

There are many infrastructure platforms available. [Azure Service Fabric](https://azure.microsoft.com/services/service-fabric/) is designed for large and complex microservice systems. [Azure App Service](https://azure.microsoft.com/services/app-service/) is a good choice for stateless microservices. Microservices alternatives based on Docker fit any kind of microservices approach, as explained in the [Containers](#containers) section. All these platforms support .NET Core and make them ideal for hosting your microservices.

For more information about microservices architecture, see [.NET Microservices. Architecture for Containerized .NET Applications](microservices-architecture/index.md).

### Containers

Containers are commonly used in conjunction with a microservices architecture. Containers can also be used to containerize web apps or services that follow any architectural pattern. .NET Framework can be used on Windows containers, but the modularity and lightweight nature of .NET Core makes it a better choice for containers. When creating and deploying a container, the size of its image is much smaller with .NET Core than with .NET Framework. Because it's cross-platform, you can deploy server apps to Linux Docker containers, for example.

Docker containers can be hosted in your own Linux or Windows infrastructure, or in a cloud service such as [Azure Container Service](https://azure.microsoft.com/services/container-service/). Azure Container Service can manage, orchestrate, and scale container-based applications in the cloud.

### A need for high-performance and scalable systems

When your system needs the best possible performance and scalability, .NET Core and ASP.NET Core are your best options. High-performance server runtime for Windows Server and Linux makes .NET a top performing web framework on [TechEmpower benchmarks](https://www.techempower.com/benchmarks/#hw=ph&test=plaintext).

Performance and scalability are especially relevant for microservices architectures, where hundreds of microservices may be running. With ASP.NET Core, systems run with a much lower number of servers/Virtual Machines (VM). The reduced servers/VMs save costs in infrastructure and hosting.

### A need for side by side of .NET versions per application level

To install applications with dependencies on different versions of .NET, we recommend .NET Core. .NET Core offers side-by-side installation of different versions of the .NET Core runtime on the same machine. This side-by-side installation allows multiple services on the same server, each of them on its own version of .NET Core. It also lowers risks and saves money in application upgrades and IT operations.

## When to choose .NET Framework

.NET Core offers significant benefits for new applications and application patterns. However, the .NET Framework continues to be the natural choice for many existing scenarios and as such. The .NET Framework isn't replaced by .NET Core for all server applications.

### Current .NET Framework applications

In most cases, you don’t need to migrate your existing applications to .NET Core. Instead, a recommended approach is to use .NET Core as you extend an existing application, such as writing a new web service in ASP.NET Core.

### A need to use third-party .NET libraries or NuGet packages not available for .NET Core

Libraries are quickly embracing .NET Standard. .NET Standard enables sharing code across all .NET implementations including .NET Core. With .NET Standard 2.0, this is even easier:

- The API surface became much larger. 
- Introduced a .NET Framework compatibility mode. This compatibility mode allows .NET Standard/.NET Core projects to reference .NET Framework libraries. To learn more about the compatibility mode, see [Announcing .NET Standard 2.0](https://blogs.msdn.microsoft.com/dotnet/2017/08/14/announcing-net-standard-2-0/).

So only in cases where the libraries or NuGet packages use technologies that aren't available in .NET Standard/.NET Core, you need to use the .NET Framework.

### A need to use .NET technologies not available for .NET Core

Some .NET Framework technologies aren't available in .NET Core. Some of them might be available in later .NET Core releases. Others don’t apply to the new application patterns targeted by .NET Core and may never be available. The following list shows the most common technologies not found in .NET Core:

* ASP.NET Web Forms applications: ASP.NET Web Forms are only available in the .NET Framework. ASP.NET Core cannot be used for ASP.NET Web Forms. There are no plans to bring ASP.NET Web Forms to .NET Core.

* ASP.NET Web Pages applications: ASP.NET Web Pages aren't included in ASP.NET Core. ASP.NET Core [Razor Pages](/aspnet/core/mvc/razor-pages/) have many similarities with Web Pages.

* ASP.NET SignalR server/client implementation. Currently, [ASP.NET SignalR](https://github.com/aspnet/SignalR) is available in preview mode with ASP.NET Core 2.1.

* WCF services implementation. Even when there’s a [WCF-Client library](https://github.com/dotnet/wcf) to consume WCF services from .NET Core, WCF server implementation is currently only available in the .NET Framework. This scenario is not part of the current plan for .NET Core but it’s being considered for the future.

* Workflow-related services: Windows Workflow Foundation (WF), Workflow Services (WCF + WF in a single service) and WCF Data Services (formerly known as "ADO.NET Data Services") are only available in the .NET Framework.  There are no plans to bring WF/WCF+WF/WCF Data Services to .NET Core.

* Windows Presentation Foundation (WPF) and Windows Forms: WPF and Windows Forms applications are only available in the .NET Framework. There are no plans to port them to .NET Core.

* Language support: Visual Basic and F# are currently supported in .NET Core, but not for all project types. For a list of supported project templates, see [Template options for dotnet new](../core/tools/dotnet-new.md#arguments).

In addition to the official roadmap, there are other frameworks to be ported to .NET Core. For a full list, see the CoreFX issues marked as [port-to-core](https://github.com/dotnet/corefx/issues?q=is%3Aopen+is%3Aissue+label%3Aport-to-core). This list doesn’t represent a commitment from Microsoft to bring those components to .NET Core. They're simply capturing the desire from the community to do so. If you care about any of the components marked as `port-to-core`, participate in the discussions on GitHub. And if you think something is missing, file a new issue in the [CoreFX repository](https://github.com/dotnet/corefx/issues/new).

### A need to use a platform that doesn’t support .NET Core

Some Microsoft or third-party platforms don’t support .NET Core. For example, some Azure services such as Service Fabric Stateful Reliable Services and Service Fabric Reliable Actors require .NET Framework. Some other services provide an SDK not yet available for consumption on .NET Core. This is a transitional circumstance, as all of Azure services use .NET Core. In the meantime, you can always use the equivalent REST API instead of the client SDK.

## See also
 [Choose between ASP.NET and ASP.NET Core](/aspnet/core/choose-aspnet-framework)  
 [.NET Core Guide](../core/index.md)  
 [Porting from .NET Framework to .NET Core](../core/porting/index.md)  
 [.NET Framework on Docker Guide](../framework/docker/index.md)  
 [.NET Components Overview](components.md)  
 [.NET Microservices. Architecture for Containerized .NET Applications](microservices-architecture/index.md)
