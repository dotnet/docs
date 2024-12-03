---
title: Choose between .NET and .NET Framework for server apps
description: A guide to help you decide which implementation of .NET to use when building a server app.
ms.date: 11/22/2024
ms.custom: updateeachrelease
---
# .NET vs. .NET Framework for server apps

There are two supported [.NET implementations](glossary.md#implementation-of-net) for building server-side apps: .NET and .NET Framework. **The latest .NET version (currently .NET 9) is the preferred version of .NET to use for server development.** The reasons to continue using .NET Framework are specific and limited.

| Implementation | Included versions                                   |
|----------------|-----------------------------------------------------|
| .NET           | .NET Core 1.0 - 3.1 </br> .NET 5 and later versions |
| .NET Framework | .NET Framework 1.0 - 4.8                            |

## Choose .NET

.NET has the following advantages for server apps:

- **Works cross-platform.**

  .NET enables your web or service app to run on multiple platforms, for example, Windows, Linux, and macOS. You can also use any of these operating systems as your development workstation. Use the Visual Studio integrated development environment (IDE) on Windows, or use Visual Studio Code on macOS, Linux, or Windows. Visual Studio Code supports IntelliSense and debugging. Most third-party editors, such as Sublime, Emacs, and VI, work with .NET. These third-party editors get editor IntelliSense using [Omnisharp](https://www.omnisharp.net/). You can also skip the code editor and directly use the [.NET CLI](../core/tools/index.md).

- **Lets you target microservices.**

  A microservices architecture allows a mix of technologies across a service boundary. This technology mix enables a gradual embrace of .NET for new microservices that work with other microservices or services. For example, you can mix microservices or services developed with .NET Framework, Java, Ruby, or other monolithic technologies.

  There are many infrastructure platforms available. [Azure Service Fabric](https://azure.microsoft.com/services/service-fabric/) is designed for large and complex microservice systems. [Azure App Service](https://azure.microsoft.com/services/app-service/) is a good choice for stateless microservices. Microservices alternatives based on Docker fit any microservices approach, as explained in the next section (Supports Docker containers). All these platforms support .NET and make them ideal for hosting your microservices.

  For more information about microservices architecture, see [.NET Microservices: Architecture for containerized .NET apps](../architecture/microservices/index.md).

- **Supports Docker containers.**

  Containers are commonly used with a microservices architecture. Containers can also be used to containerize web apps or services that follow any architectural pattern. While .NET Framework can be used on Windows containers, the modularity and lightweight nature of .NET make it a better choice for containers. When you're creating and deploying a container, the size of its image is much smaller with .NET than with .NET Framework. Because it's cross-platform, you can deploy server apps to Linux Docker containers.

  You can host Docker containers in your own Linux or Windows infrastructure or in a cloud service such as [Azure Kubernetes Service](https://azure.microsoft.com/services/kubernetes-service/). Azure Kubernetes Service can manage, orchestrate, and scale container-based applications in the cloud.

- **Is high-performance and scalable.**

  When your system needs the best possible performance and scalability, .NET and ASP.NET Core are your best options. The high-performance server runtime for Windows Server and Linux makes ASP.NET Core a top-performing web framework on [TechEmpower benchmarks](https://www.techempower.com/benchmarks/#hw=ph&test=plaintext).

  Performance and scalability are especially relevant for microservices architectures, where hundreds of microservices might be running. With ASP.NET Core, systems run with a much lower number of servers or virtual machines (VMs), which saves costs on infrastructure and hosting.

- **Supports side-by-side .NET versions per application.**

  The .NET implementation supports side-by-side installations of different versions of the .NET runtime on the same machine. That capability allows multiple services on the same server, each on its own version of .NET. It also lowers risks and saves money in application upgrades and IT operations.

  Side-by-side installation isn't possible with .NET Framework. It's a Windows component, and only one version can exist on a machine at a time: each version of .NET Framework replaces the previous version. If you install a new app that targets a later version of .NET Framework, you might break existing apps that run on the machine because the previous version was replaced.

- **Is more secure.**

## When to choose .NET Framework

As previously mentioned, the *.NET* implementation offers significant benefits for new applications and application patterns. However, in some specific scenarios, you might need to use .NET Framework for your server apps, and .NET Framework will continue to be supported. Use .NET Framework for your server app when:

- Your app currently uses .NET Framework.

  In most cases, you don't need to migrate your existing applications to .NET. Instead, we recommend using .NET as you extend an existing app, such as writing a new web service in ASP.NET Core.

- Your app uses third-party libraries or NuGet packages that aren't available for .NET.

  .NET Standard enables sharing code across all .NET implementations, including .NET 6+. With .NET Standard 2.0, a compatibility mode allows .NET Standard and .NET projects to reference .NET Framework libraries. For more information, see [Support for .NET Framework libraries](whats-new/whats-new-in-dotnet-standard.md#support-for-net-framework-libraries).

  You should only use .NET Framework when the libraries or NuGet packages use technologies that aren't available in .NET Standard or .NET.

- Your app uses .NET Framework technologies that aren't available for .NET.

  Some .NET Framework technologies aren't available in .NET. The following list shows the most common technologies not found in .NET:

  - **ASP.NET Web Forms applications**: ASP.NET Web Forms are only available in .NET Framework. ASP.NET Core can't be used for ASP.NET Web Forms.
  - **ASP.NET Web Pages applications**: ASP.NET Web Pages aren't included in ASP.NET Core.
  - **Workflow-related services**: Windows Workflow Foundation (WF), Workflow Services (WCF + WF in a single service), and WCF Data Services (formerly known as "ADO.NET Data Services") are only available in .NET Framework.
  - **Language support**: Visual Basic and F# are supported in .NET but *not for all project types*. For a list of supported project templates, see [Template options for dotnet new](../core/tools/dotnet-new.md#arguments).

  For more information, see [.NET Framework technologies unavailable in .NET](../core/porting/net-framework-tech-unavailable.md).

- Your app uses a platform that doesn't support .NET.

  Some Microsoft or third-party platforms don't support .NET. Some Azure services provide an SDK not yet available for consumption on .NET. In such cases, you can use the equivalent REST API instead of the client SDK.

## See also

- [Choose between ASP.NET and ASP.NET Core](/aspnet/core/choose-aspnet-framework)
- [ASP.NET Core targeting .NET Framework](/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-2.2&preserve-view=true#aspnet-core-targeting-net-framework)
- [Target frameworks](frameworks.md)
- [.NET introduction](../core/introduction.md)
- [Porting from .NET Framework to .NET 5](../core/porting/index.md)
- [Introduction to .NET and Docker](../core/docker/introduction.md)
- [.NET implementations](../fundamentals/implementations.md)
- [.NET Microservices. Architecture for Containerized .NET Applications](../architecture/microservices/index.md)
