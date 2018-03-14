---
title: .NET Core Application Deployment
description: Deploying a .NET Core application.
keywords: .NET, .NET Core, .NET Core deployment
author: rpetrusha
ms.author: ronpet
ms.date: 04/18/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: da7a31a0-8072-4f23-82aa-8a19184cb701
ms.workload: 
  - dotnetcore
---

# .NET Core application deployment

You can create two types of deployments for .NET Core applications:

- Framework-dependent deployment. As the name implies, framework-dependent deployment (FDD) relies on the presence of a shared system-wide version of .NET Core on the target system. Because .NET Core is already present, your app is also portable between installations of .NET Core. Your app contains only its own code and any third-party dependencies that are outside of the .NET Core libraries. FDDs contain *.dll* files that can be launched by using the [dotnet utility](../tools/dotnet.md) from the command line. For example, `dotnet app.dll` runs an application named `app`.

- Self-contained deployment. Unlike FDD, a self-contained deployment (SCD) doesn't rely on the presence of shared components on the target system. All components, including both the .NET Core libraries and the .NET Core runtime, are included with the application and are isolated from other .NET Core applications. SCDs include an executable (such as *app.exe* on Windows platforms for an application named `app`), which is  a renamed version of the platform-specific .NET Core host, and a *.dll* file (such as *app.dll*), which is the actual application.

## Framework-dependent deployments (FDD)

For an FDD, you deploy only your app and any third-party dependencies. You don't have to deploy .NET Core, since your app will use the version of .NET Core that's present on the target system. This is the default deployment model for .NET Core apps.

### Why create a framework-dependent deployment?

Deploying an FDD has a number of advantages:

- You don't have to define the target operating systems that your .NET Core app will run on in advance. Because .NET Core uses a common PE file format for executables and libraries regardless of operating system, .NET Core can execute your app regardless of the underlying operating system. For more information on the PE file format, see [.NET Assembly File Format](../../standard/assembly-format.md).

- The size of your deployment package is small. You only deploy your app and its dependencies, not .NET Core itself.

- Multiple apps use the same .NET Core installation, which reduces both disk space and memory usage on host systems.

There are also a few disadvantages:

- Your app can run only if the version of .NET Core that you target, or a later version, is already installed on the host system.

- It's possible for the .NET Core runtime and libraries to change without your knowledge in future releases. In rare cases, this may change the behavior of your app.

## Self-contained deployments (SCD)

For a self-contained deployment, you deploy your app and any required third-party dependencies along with the version of .NET Core that you used to build the app. Creating an SCD doesn't include the [native dependencies of .NET Core](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md) on various platforms, so these must be present before the app runs.

FDD and SCD deployments use separate host executables, so you can sign a host executable for an SCD with your publisher signature.

### Why deploy a self-contained deployment?

Deploying a Self-contained deployment has two major advantages:

- You have sole control of the version of .NET Core that is deployed with your app. .NET Core can be serviced only by you.

- You can be assured that the target system can run your .NET Core app, since you're providing the version of .NET Core that it will run on.

It also has a number of disadvantages:

- Because .NET Core is included in your deployment package, you must select the target platforms for which you build deployment packages in advance.

- The size of your deployment package is relatively large, since you have to include .NET Core as well as your app and its third-party dependencies.

- Deploying numerous self-contained .NET Core apps to a system can consume significant amounts of disk space, since each app duplicates .NET Core files.

## Step-by-step examples

For step-by-step examples of deploying .NET Core apps with CLI tools, see [Deploying .NET Core Apps with CLI Tools](deploy-with-cli.md). For step-by-step examples of deploying .NET Core apps with Visual Studio, see [Deploying .NET Core Apps with Visual Studio](deploy-with-vs.md). Each topic includes examples of the following deployments:

- Framework-dependent deployment
- Framework-dependent deployment with third-party dependencies
- Self-contained deployment
- Self-contained deployment with third-party dependencies

# See also

[Deploying .NET Core Apps with CLI Tools](deploy-with-cli.md)   
[Deploying .NET Core Apps with Visual Studio](deploy-with-vs.md)   
[Packages, Metapackages and Frameworks](../packages.md)   
[.NET Core Runtime IDentifier (RID) catalog](../rid-catalog.md)
