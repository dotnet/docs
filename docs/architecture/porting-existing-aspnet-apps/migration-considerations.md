---
title: Migration considerations
description: What does a team need to know in order to make the right decision about whether and how to migrate from ASP.NET MVC to .NET Core?
author: ardalis
ms.date: 11/13/2020
---

# Migration considerations

The most fundamental question teams must answer when it comes to porting their apps to .NET Core is, should they port at all? In some cases, the best path forward may be to remain on the .NET Framework using ASP.NET MVC and/or Web API. In this chapter, we'll consider reasons why moving to .NET Core may make sense, and consider some scenarios and counterpoints for staying on .NET.

## Is migration to .NET Core appropriate?

Let's start with some of the reasons why you might want to move to .NET Core. There are quite a few, so don't consider this an exhaustive list.

### Cross-platform support.

Apps built on .NET Core are truly cross-platform and can run on Windows as well as Linux and MacOS. This means not only can your developers use whatever hardware they want, but you'll also be able to host your application anywhere from local IIS to Azure in the cloud; from Linux Docker containers to IoT devices.

### Performance and scalability

Apps built with .NET Core are running on one of the fastest tech stacks available anywhere. If performance is a key concern for your app, you're almost certain to see a performance improvement by moving to .NET Core from ASP.NET MVC.

### Cloud native

For the above reasons as well as others, .NET Core apps are very well-suited to running in cloud hosting environments. Lightweight and fast, apps running in Core can easily be deployed to Azure Web Apps or containers and scaled horizontally as needed to meet immediate system demand.

### Maintainable

For many apps, while they've continued to meet customer and business needs, technical debt has accumulated and maintaining the app has grown expensive. ASP.NET Core apps are more easily tested than ASP.NET MVC apps, making them easier to refactor and extend with confidence.

### Modular

ASP.NET Core is very modular, leveraging Nuget packages as a first-class part of the framework. Apps built for .NET Core all support dependency injection, making it easy to compose solutions from whatever implementations are needed for a given environment. Building microservices with .NET Core is far easier than with ASP.NET MVC with its dependency on IIS, which opens up additional options to break up large applications into smaller modules.

### Modern

Staying on a modern, actively developed technology stack has a host of advantages. While ASP.NET MVC will remain supported by Microsoft for many years, the best and brightest .NET software developers are likely looking to use the more modern .NET Core framework, with all of the advantages is has to offer (only some of which are summarized above). Finding employees and/or contractors with the skills to maintain an ASP.NET MVC application will start to become a challenge at some point, as will finding online training and troubleshooting assistance. There probably aren't that many new blog posts being written about ASP.NET MVC 5, while there are plenty being written for .NET 5, for example.

There are certainly many compelling reasons to consider migrating to .NET Core, which presumably is why you're reading this book! But let's consider some disadvantages and reasons why it may make more sense to remain on the .NET Framework.

## When is .NET Framework appropriate?

The biggest reason why you would want to stay on .NET Framework, aside from simply to avoid the effort of migrating, would be if you need certain technologies that are unavailable on .NET Core. There are a number of [.NET technologies that are unavailable on .NET Core](https://docs.microsoft.com/dotnet/core/porting/net-framework-tech-unavailable), including AppDomains, Remoting, Code Access Security (CAS), Security Transparency, and System.EnterpriseServices. A brief summary of these technologies and their alternatives is included here; see the documentation for more detailed guidance.

### AppDomains

Application domains (AppDomains) isolate apps from one another. AppDomains require runtime support and are generally expensive. Creating additional app domains is not supported, and there are no plans to add this capability to .NET Core in the future. For code isolation, use separate processes or containers as an alternative.

### Remoting

.NET Remoting was identified as a problematic architecture. It's used for cross-AppDomain communication, which is no longer supported. Also, Remoting requires runtime support, which is expensive to maintain. For these reasons, .NET Remoting isn't supported on .NET Core, and the product team doesn't plan on adding support for it in the future. There are a number of alternative messaging strategies and implementations you can use to replace remoting in your .NET Core apps.

### Code Access Security (CAS) and Security Transparency

Neither of these technologies are support by .NET Core. Instead, the recommendation is to use security boundaries provided by the operating system, such as virtualization, containers, or user accounts. Run processes with the minimal set of privileges necessary.

## References

[.NET Framework Technologies Unavailable on .NET Core](https://docs.microsoft.com/dotnet/core/porting/net-framework-tech-unavailable)

>[!div class="step-by-step"]
>[Previous](introduction.md)
>[Next](migrate-aspnet-core-2-1.md)
