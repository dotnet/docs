---
title: ".NET Core and Open-Source"
description: Read an overview about .NET Core, which is a general-purpose, modular, cross-platform, and open-source implementation of the .NET Standard.
ms.date: "03/30/2017"
ms.assetid: e6bd4655-ce37-4003-8462-468a6fe2c40f
---
# .NET Core and open source

This article provides a brief overview of what .NET Core is and shows how you can find more information.

## What is .NET Core?  

.NET Core is a general purpose, modular, cross-platform, and open-source implementation of the .NET Standard. It contains many of the same APIs as the .NET Framework (but .NET Core is a smaller set) and includes runtime, framework, compiler, and tools components that support a variety of operating systems and chip targets. The .NET Core implementation was primarily driven by the ASP.NET Core workloads but also by the need and desire to have a more modern implementation. It can be used in device, cloud, and embedded/IoT scenarios.  
  
To get started with .NET Core, visit the .NET tutorial [Hello World in 10 minutes](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro).  
  
The main characteristics of .NET Core are:
  
- **Cross-platform:** .NET Core provides key functionality to implement the app features you need and reuse this code regardless of your platform target. It currently supports three main operating systems (OS): Windows, Linux, and macOS. You can write apps and libraries that run unmodified across supported operating systems. To see the list of supported operating systems, visit [.NET Core roadmap](https://github.com/dotnet/core/blob/master/roadmap.md).
  
- **Open source:** .NET Core is one of the many projects under the stewardship of the [.NET Foundation](https://www.dotnetfoundation.org/) and is available on [GitHub](https://github.com/). As an open-source project, .NET Core promotes a more transparent development process and an active and engaged community.  
  
- **Flexible deployment:** there are two main ways to deploy your app: framework-dependent deployment or self-contained deployment. With framework-dependent deployment, only your app and third-party dependencies are installed and your app depends on a system-wide version of .NET Core to be present. With self-contained deployment, the .NET Core version used to build your application is also deployed along with your app and third-party dependencies and can run side by side with other versions. For more information, see [.NET Core Application Deployment](../../core/deploying/index.md).

- **Modular:** .NET Core is modular because it's released through NuGet in smaller assembly packages. Rather than one large assembly that contains most of the core functionality, .NET Core is made available as smaller, feature-centric packages. This modularity enables a more agile development model for us and allows you to optimize your app to include just the NuGet packages you need. The benefits of a smaller app surface area include tighter security, reduced servicing, improved performance, and decreased costs in a pay-for-what-you-use model.  
  
## The .NET Core platform
  
The .NET Core platform is made up of several components, including the managed compilers, the runtime, the base class libraries, and numerous application models, such as ASP.NET Core. You can learn more about the different components and get engaged by visiting the following [GitHub](https://github.com/) repos:  
  
- [.NET Core home](https://github.com/dotnet/core)  
  
- [Runtime - .NET Core platform and runtime](https://github.com/dotnet/runtime)  
  
- [CLI - .NET Core command-line tools](https://github.com/dotnet/cli)  
  
- [Roslyn - .NET Compiler Platform](https://github.com/dotnet/roslyn)  
  
- [ASP.NET Core](https://github.com/dotnet/aspnetcore)  
  
## See also

- [.NET tutorial - Hello World in 10 minutes](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro)
- [.NET Core introduction](../../core/introduction.md)
- [ASP.NET Core docs](/aspnet/core/)
