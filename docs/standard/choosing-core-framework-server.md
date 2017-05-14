---
title: Choosing between .NET Core and .NET Framework for server apps
description: A guide on which flavor of .NET you should consider when building a server app in .NET.
keywords: .NET, .NET Core, .NET Framework
author: cartermp
ms.author: mairaw
ms.date: 11/16/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 155553e4-89a2-418d-be88-4e75f6c3cc69
---

# Choosing between .NET Core and .NET Framework for server apps

There are two supported choices of runtime for building server-side applications with .NET: .NET Framework and .NET Core. Both share a lot of the same .NET platform components and you can share code across the two. However, there are fundamental differences between the two and your choice will depend on what you want to accomplish.  This article provides guidance on when to use each.

You should use .NET Core for your server application when:

* You have cross-platform needs.
* You are targeting microservices.
* You are using Docker containers.
* You need high performance and scalable systems.
* You need side by side of .NET versions by application.

You should use .NET Framework for your server application when:

* Your application currently uses .NET Framework (recommendation is to extend instead of migrating)
* You need to use third-party .NET libraries or NuGet packages not available for .NET Core.
* You need to use .NET technologies that are not available for .NET Core.
* You need to use a platform that doesn’t support .NET Core.

## When to choose .NET Core

The following is a more detailed explanation of the previously-stated reasons for picking .NET Core.

### Cross-platform needs

Clearly, if your goal is to have an application (web/service) that should be able to run across platforms (Windows, Linux and macOS), the best choice is to use .NET Core.

.NET Core also supports the previously-mentioned operating systems as your development workstation. Visual Studio provides an Integrated Development Environment (IDE) for Windows.  You can also use Visual Studio Code on macOS, Linux and Windows which fully support .NET Core, including IntelliSense and debugging. You can also target .NET Core with most third-party editors like Sublime, Emacs, VI and can get editor IntelliSense using the open source [Omnisharp](http://www.omnisharp.net/) project. You can also avoid any code editor and directly use the .NET Core command-line tools, available for all supported platforms.

### Microservices architecture

.NET Core is the best candidate if you are embracing a microservices oriented system composed of multiple independent, dynamically scalable, stateful or stateless microservices. .NET Core is lightweight and its API surface can be minimized to the scope of the microservice. A microservices architecture also allows you to mix technologies across a service boundary, enabling a gradual embrace of .NET Core for new microservices that live in conjunction with other microservices or services developed with .NET Framework, Java, Ruby, or other monolithic technologies.

The infrastructure platforms you could use are many. For large and complex microservice systems, you can use [Azure Service Fabric](https://azure.microsoft.com/services/service-fabric/). For stateless microservices you can also use other products like [Azure App Service](https://azure.microsoft.com/services/app-service/). Microservices alternatives based on Docker also fit any kind of microservices approach, as explained next. All these platforms support .NET Core and make them ideal for hosting your microservices.

### Containers

Containers are commonly used in conjunction with a microservices architecture, although they can also be used to containerize web apps or services which follow any architectural pattern. You will be able to use the .NET Framework for Windows containers, but the modularity and lightweight nature of .NET Core makes it perfect for containers. When creating and deploying a container, the size of its image is far smaller with .NET Core than with .NET Framework. Because it is cross-platform, you can deploy server apps to Linux Docker containers, for example.

You can then host your Docker containers in your own Linux or Windows infrastructure, or use a cloud service such as [Azure Container Service](https://azure.microsoft.com/services/container-service/) which can manage, orchestrate and scale your container-based application in the cloud.

### A need for high performance and scalable systems

When your system needs the best possible performance and scalability, .NET Core and ASP.NET Core are your best options. ASP.NET Core outperforms ASP.NET by a factor of 10, and it leads other popular industry technologies for microservices such as Java servlets, Go and node.js.

This is especially relevant for microservices architectures, where you could have hundreds of microservices running. With ASP.NET Core you’d be able to run your system with a much lower number of servers/VMs, ultimately saving costs in infrastructure and hosting.

### A need for side by side of .NET versions per application level

If you want to be able to install applications with dependencies on different versions of frameworks in .NET, you need to use .NET Core, which provides 100% side-by-side. Easy side-by-side installation of different versions of .NET Core on the same machine allows you to have multiple services on the same server, each of them on its own version of .NET Core, eliminating risks and saving money in application upgrades and IT operations.

## When to choose .NET Framework

While .NET Core offers significant benefits for new applications and application patterns, the .NET Framework will continue to be the natural choice for many existing scenarios and as such, it won’t be replaced by .NET Core for all server applications.

### Current .NET Framework applications

In most cases, you won’t need to migrate your existing applications to .NET Core. Instead, a recommended approach is to use .NET Core as you extend an existing application, such as writing a new web service in ASP.NET Core.

### A need to use third-party .NET libraries or NuGet packages not available for .NET Core

Libraries are quickly embracing .NET Standard, which enables sharing code across all .NET flavors including .NET Core. With .NET Standard 2.0 this will be even easier, as the .NET Core API surface will become significantly bigger and .NET Core applications can directly use existing .NET Framework libraries. This transition won’t be immediate, though, so we recommend checking the specific libraries required by your application before making a decision one way or another.

### A need to use .NET technologies not available for .NET Core

Some .NET Framework technologies are not available in .NET Core. Some of them will be available in later .NET Core releases, but others don’t apply to the new application patterns targeted by .NET Core and may never be available. The following list shows the most common technologies not found in .NET Core 1.0:

* ASP.NET Web Forms applications: ASP.NET Web Forms is only available on the .NET Framework, so you cannot use ASP.NET Core / .NET Core for this scenario. Currently there are no plans to bring ASP.NET Web Forms to .NET Core.

* ASP.NET Web Pages applications: ASP.NET Web Pages are not included in ASP.NET Core 1.0, although it is planned to be included in a future release as explained in the [.NET Core roadmap](https://github.com/aspnet/Home/wiki/Roadmap).

* ASP.NET SignalR server/client implementation. At .NET Core 1.0 release timeframe (June 2016), ASP.NET SignalR is not available for ASP.NET Core (neither client or server), although it is planned to be included in a future release as explained in the [.NET Core roadmap](https://github.com/aspnet/Home/wiki/Roadmap). Preview state is available at the [Server-side](https://github.com/aspnet/SignalR-Server) and [Client Library](https://github.com/aspnet/SignalR-Client-Net) GitHub repositories.

* WCF services implementation. Even when there’s a [WCF-Client library](https://github.com/dotnet/wcf) to consume WCF services from .NET Core, as of June 2016, WCF server implementation is only available on the .NET Framework. This scenario is not part of the current plan for .NET Core but it’s being considered for the future.

* Workflow related services: Windows Workflow Foundation (WF), Workflow Services (WCF + WF in a single service) and WCF Data Services (formerly known as "ADO.NET Data Services") are only available on the .NET Framework and there are no plans to bring them to .NET Core.

* Windows Presentation Foundation (WPF) and Windows Forms: WPF and Windows Forms applications are only available on the .NET Framework. There are no plans to port them to .NET Core. 

* Language support: Visual Basic and F# don’t currently have tooling support .NET Core, but both will be supported in Visual Studio 2017 and later versions of Visual Studio.

In addition to the official roadmap, there are other frameworks to be ported to .NET Core - For a full list, take a look at CoreFX issues marked as [port-to-core](https://github.com/dotnet/corefx/issues?q=is%3Aopen+is%3Aissue+label%3Aport-to-core). Please note that this list doesn’t represent a commitment from Microsoft to bring those components to .NET Core — they are simply capturing the desire from the community to do so. That being said, if you care about any of the components listed above, consider participating in the discussions on GitHub so that your voice can be heard. And if you think something is missing, please [file a new issue in the CoreFX repository](https://github.com/dotnet/corefx/issues/new).

### A need to use a platform that doesn’t support .NET Core

Some Microsoft or third-party platforms don’t support .NET Core. For example, some Azure services such as Service Fabric Stateful Reliable Services and Service Fabric Reliable Actors require .NET Framework. Some other services provide an SDK not yet available for consumption on .NET Core. This is a transitional circumstance, as all of Azure services use .NET Core. In the meantime, you can always use the equivalent REST API instead of the client SDK.

## Further resources

* [.NET Core Guide](../core/index.md)
* [Porting from .NET Framework to .NET Core](../core/porting/index.md)
* [.NET Framework on Docker Guide](../framework/index.md)
* [.NET Components Overview](components.md)
