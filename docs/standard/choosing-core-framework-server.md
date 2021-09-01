---
title: Choose between .NET and .NET Framework for server apps
description: A guide to help you decide which implementation of .NET to use when building a server app.
author: cartermp
ms.date: 04/20/2021
---
# .NET vs. .NET Framework for server apps

There are two supported [.NET implementations](glossary.md#implementation-of-net) for building server-side apps.

| Implementation | Included versions |
| - | - |
| .NET | .NET Core 1.0 - 3.1, .NET 5, and later versions of .NET. |
| .NET Framework | .NET Framework 1.0 - 4.8 |

Both share many of the same components, and you can share code across the two. However, there are fundamental differences between the two and your choice depends on what you want to accomplish. This article provides guidance on when to use each.

Use .NET for your server application when:

- You have cross-platform needs.
- You're targeting microservices.
- You're using Docker containers.
- You need high-performance and scalable systems.
- You need side-by-side .NET versions per application.

Use .NET Framework for your server application when:

- Your app currently uses .NET Framework (recommendation is to extend instead of migrating).
- Your app uses third-party libraries or NuGet packages not available for .NET.
- Your app uses .NET Framework technologies that aren't available for .NET.
- Your app uses a platform that doesn't support .NET.

## When to choose .NET

The following sections give a more detailed explanation of the previously stated reasons for picking .NET over .NET Framework.

### Cross-platform needs

If your web or service application needs to run on multiple platforms, for example, Windows, Linux, and macOS, use .NET.

.NET supports the previously mentioned operating systems as your development workstation. Visual Studio provides an Integrated Development Environment (IDE) for Windows and macOS. You can also use Visual Studio Code, which runs on macOS, Linux, and Windows. Visual Studio Code supports .NET, including IntelliSense and debugging. Most third-party editors, such as Sublime, Emacs, and VI, work with .NET. These third-party editors get editor IntelliSense using [Omnisharp](https://www.omnisharp.net/). You can also avoid any code editor and directly use the [.NET CLI](../core/tools/index.md), available for all supported platforms.

### Microservices architecture

A microservices architecture allows a mix of technologies across a service boundary. This technology mix enables a gradual embrace of .NET for new microservices that work with other microservices or services. For example, you can mix microservices or services developed with .NET Framework, Java, Ruby, or other monolithic technologies.

There are many infrastructure platforms available. [Azure Service Fabric](https://azure.microsoft.com/services/service-fabric/) is designed for large and complex microservice systems. [Azure App Service](https://azure.microsoft.com/services/app-service/) is a good choice for stateless microservices. Microservices alternatives based on Docker fit any kind of microservices approach, as explained in the [Containers](#containers) section. All these platforms support .NET and make them ideal for hosting your microservices.

For more information about microservices architecture, see [.NET Microservices. Architecture for Containerized .NET Applications](../architecture/microservices/index.md).

### Containers

Containers are commonly used in conjunction with a microservices architecture. Containers can also be used to containerize web apps or services that follow any architectural pattern. .NET Framework can be used on Windows containers, but the modularity and lightweight nature of .NET makes it a better choice for containers. When creating and deploying a container, the size of its image is much smaller with .NET than with .NET Framework. Because it's cross-platform, you can deploy server apps to Linux Docker containers, for example.

Docker containers can be hosted in your own Linux or Windows infrastructure, or in a cloud service such as [Azure Kubernetes Service](https://azure.microsoft.com/services/kubernetes-service/). Azure Kubernetes Service can manage, orchestrate, and scale container-based applications in the cloud.

### High-performance and scalable systems

When your system needs the best possible performance and scalability, .NET and ASP.NET Core are your best options. The high-performance server runtime for Windows Server and Linux makes ASP.NET Core a top performing web framework on [TechEmpower benchmarks](https://www.techempower.com/benchmarks/#hw=ph&test=plaintext).

Performance and scalability are especially relevant for microservices architectures, where hundreds of microservices may be running. With ASP.NET Core, systems run with a much lower number of servers/Virtual Machines (VM). The reduced servers/VMs save costs in infrastructure and hosting.

### Side by side .NET versions per application level

To install applications with dependencies on different versions of .NET, we recommend .NET. This implementation supports side-by-side installation of different versions of the .NET runtime on the same machine. This side-by-side installation allows multiple services on the same server, each of them on its own version of .NET. It also lowers risks and saves money in application upgrades and IT operations.

Side-by-side installation isn't possible with .NET Framework. It's a Windows component, and only one version can exist on a machine at a time. Each version of .NET Framework replaces the previous version. If you install a new app that targets a later version of .NET Framework, you might break existing apps that run on the machine, because the previous version was replaced.

## When to choose .NET Framework

.NET offers significant benefits for new applications and application patterns. However, .NET Framework continues to be the natural choice for many existing scenarios, and as such, .NET Framework isn't replaced by .NET for all server applications.

### Current .NET Framework applications

In most cases, you don't need to migrate your existing applications to .NET. Instead, a recommended approach is to use .NET as you extend an existing application, such as writing a new web service in ASP.NET Core.

### Third-party libraries or NuGet packages not available for .NET

.NET Standard enables sharing code across all .NET implementations, including .NET Core/5+. With .NET Standard 2.0, a compatibility mode allows .NET Standard and .NET projects to reference .NET Framework libraries. For more information, see [Support for .NET Framework libraries](whats-new/whats-new-in-dotnet-standard.md#support-for-net-framework-libraries).

You need to use .NET Framework only in cases where the libraries or NuGet packages use technologies that aren't available in .NET Standard or .NET.

### .NET Framework technologies not available for .NET

Some .NET Framework technologies aren't available in .NET. The following list shows the most common technologies not found in .NET:

- ASP.NET Web Forms applications: ASP.NET Web Forms are only available in .NET Framework. ASP.NET Core cannot be used for ASP.NET Web Forms.

- ASP.NET Web Pages applications: ASP.NET Web Pages aren't included in ASP.NET Core.

- WCF services implementation. Even when there's a [WCF client library](https://github.com/dotnet/wcf) to consume WCF services from .NET, WCF server implementation is currently only available in .NET Framework.

- Workflow-related services: Windows Workflow Foundation (WF), Workflow Services (WCF + WF in a single service), and WCF Data Services (formerly known as "ADO.NET Data Services") are only available in .NET Framework.

- Language support: Visual Basic and F# are currently supported in .NET, but not for all project types. For a list of supported project templates, see [Template options for dotnet new](../core/tools/dotnet-new.md#arguments).

For more information, see [.NET Framework technologies unavailable in .NET](../core/porting/net-framework-tech-unavailable.md).

### Platform doesn't support .NET

Some Microsoft or third-party platforms don't support .NET. Some Azure services provide an SDK not yet available for consumption on .NET. In such cases, you can use the equivalent REST API instead of the client SDK.

## See also

- [Choose between ASP.NET and ASP.NET Core](/aspnet/core/choose-aspnet-framework)
- [ASP.NET Core targeting .NET Framework](/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-2.2&preserve-view=true#aspnet-core-targeting-net-framework)
- [Target frameworks](frameworks.md)
- [.NET introduction](../core/introduction.md)
- [Porting from .NET Framework to .NET 5](../core/porting/index.md)
- [Introduction to .NET and Docker](../core/docker/introduction.md)
- [.NET Components Overview](components.md)
- [.NET Microservices. Architecture for Containerized .NET Applications](../architecture/microservices/index.md)
