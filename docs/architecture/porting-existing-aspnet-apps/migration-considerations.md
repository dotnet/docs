---
title: Migration considerations
description: What does a team need to know to make the right decision about whether and how to migrate from ASP.NET MVC to .NET Core?
author: ardalis
ms.date: 12/10/2021
---

# Migration considerations

The most fundamental question teams must answer when it comes to porting their apps to .NET Core is, should they port at all? In some cases, the best path forward is to remain on .NET Framework using ASP.NET MVC and/or Web API. This chapter considers reasons why moving to .NET Core makes sense. The chapter also considers scenarios and counterpoints for staying on .NET Framework.

## Is migration to .NET Core appropriate?

Let's start with some of the reasons why you might want to move to .NET Core/.NET 6. There are quite a few, so don't consider this list exhaustive.

### Cross-platform support

Apps built on .NET Core are truly cross-platform and can run on Windows, Linux, and macOS. Not only can your developers use whatever hardware they want, but you can also host your app anywhere. Examples range from local IIS to Azure in the cloud or from Linux Docker containers to IoT devices.

### Performance and scalability

Apps built with .NET Core are running on [one of the fastest tech stacks available anywhere](https://www.techempower.com/benchmarks/#hw=ph&test=plaintext). ASP.NET MVC apps often see performance improvements on ASP.NET Core, especially if they're updated to take advantage of some new features available in .NET Core.

### Cloud-native

For the above reasons and others, .NET Core apps are well-suited to running in cloud hosting environments. Lightweight and fast, .NET Core apps can be deployed to Azure App Services or containers and scaled horizontally as needed to meet immediate system demand.

### Maintainable

For many apps, while they've continued to meet customer and business needs, technical debt has accumulated and maintaining the app has grown expensive. ASP.NET Core apps are more easily tested than ASP.NET MVC apps, making them easier to refactor and extend with confidence.

### Modular

ASP.NET Core is modular, using NuGet packages as a first-class part of the framework. Apps built for .NET Core all support dependency injection, making it easy to compose solutions from whatever implementations are needed for a given environment. Building microservices with .NET Core is easier than with ASP.NET MVC with its dependency on IIS, which opens up additional options to break up large apps into smaller modules.

### Modern

Staying on a modern, actively developed technology stack has a host of advantages. New features and C# language features will only be added to .NET Core. The .NET Framework has had its last release with version 4.8, and versions of C# beyond 8 won't target .NET Framework. While ASP.NET MVC will remain supported by Microsoft for many years, the best and brightest .NET software developers are likely looking to use the more modern .NET Core framework, with all of the advantages it offers (only some of which are summarized above). Finding developers with the skills to maintain an ASP.NET MVC app will start to become a challenge at some point, as will finding online training and troubleshooting assistance. There probably aren't that many new blog posts being written about ASP.NET MVC 5, while there are plenty being written for .NET 6, for example.

There are many compelling reasons to consider migrating to .NET Core, which presumably is why you're reading this book! But let's consider some disadvantages and reasons why it may make more sense to remain on the .NET Framework.

## When is .NET Framework appropriate?

The biggest reason to stay on .NET Framework is when an app isn't under active development and wouldn't benefit substantially from the advantages listed above. In that case, there probably isn't a good business case to incur the cost of porting the app. If your app might benefit from the advantages .NET Core offers, you may still need to stay on .NET Framework if you need certain technologies that are unavailable on .NET Core. There are some [.NET technologies that are unavailable on .NET Core](../../core/porting/net-framework-tech-unavailable.md), including AppDomains, Remoting, Code Access Security (CAS), Security Transparency, and `System.EnterpriseServices`. A brief summary of these technologies and their alternatives is included here. For more detailed guidance, see the documentation.

### Application domains

Application domains (AppDomains) isolate apps from one another. AppDomains require runtime support and can be expensive. Creating additional app domains isn't supported, and there are no plans to add this capability to .NET Core in the future. For code isolation, use separate processes or containers as an alternative. Some customers use AppDomains as a way of unloading assemblies. In .NET Core [AssemblyLoadContext](../../standard/assembly/unloadability.md) provides an alternative way to unload assemblies.

### WCF

Server-side WCF isn't supported in .NET Core. .NET Core supports WCF clients but not WCF hosts. Apps that require this functionality will need to upgrade to a different communication technology (such as gRPC or REST) as part of a migration.

There is a [WCF client port available from the .NET Foundation](../../core/whats-new/dotnet-5.md#windows-communication-foundation). It is entirely open source, cross platform, and supported by Microsoft. There is also a community-supported [CoreWCF project](https://github.com/CoreWCF/CoreWCF) that is *not* officially supported by Microsoft.

To learn more about migrating from WCF to gRPC, consult the [gRPC for WCF Developers](../grpc-for-wcf-developers/index.md) ebook.

### Remoting

.NET Remoting was identified as a problematic architecture. It's used for cross-AppDomain communication, which is no longer supported. Also, Remoting requires runtime support, which is expensive to maintain. For these reasons, .NET Remoting isn't supported on .NET Core, and the product team doesn't plan on adding support for it in the future. There are several alternative messaging strategies and implementations you can use to replace remoting in your .NET Core apps.

### Code Access Security (CAS) and Security Transparency

Neither of these technologies are supported by .NET Core. Instead, the recommendation is to use security boundaries provided by the operating system. For example, virtualization, containers, or user accounts. Run processes with the minimal set of privileges necessary.

## References

[.NET Framework Technologies Unavailable on .NET Core](../../core/porting/net-framework-tech-unavailable.md)

>[!div class="step-by-step"]
>[Previous](introduction.md)
>[Next](migrate-aspnet-core-2-1.md)
