---
title: Publish your Application
description: Publish your Application
author: jamshedd
ms.author: jamshedd
ms.date: 09/06/2019
ms.custom: 
---
# Publish your Application

## Framework-Dependent Deployment and Self-Contained Deployment


You can create various types of deployments for .NET Core applications:

- **Framework-Dependent Deployment (FDD)**  
  As the name implies, framework-dependent deployment (FDD) relies on the presence of a shared system-wide version of .NET Core on the target system. Because .NET Core is already present, your app is also portable between installations of .NET Core. Your app contains only its own code and any third-party dependencies that are outside of the .NET Core libraries. FDDs contain .dll files that can be launched by using the dotnet utility from the command line. For example, `dotnet app.dll` runs an application named app.

- **Self-contained deployment (SCD)**  
  Unlike Framework Dependent Deployment (FDD), a self-contained deployment (SCD) doesn't rely on the presence of shared components on the target system. All components, including both the .NET Core libraries and the .NET Core runtime, are included with the application and are isolated from other .NET Core applications. Additionally SCDs include an executable that will launch the application. The executable is a renamed version of the platform-specific .NET Core host.

- **Framework-Dependent Executables (FDE)**  
  Produce an executable that runs on a target platform. Similar to FDDs, framework-dependent executables (FDE) aren’t self-contained. These deployments still rely on the presence of a shared system-wide version of .NET Core to run. Unlike an SCD, your app only contains your code and any third-party dependencies that are outside of the .NET Core libraries. FDEs produce an executable that runs on the target platform.

- **Self-contained Executables (SCE)**  
  Produce an executable that runs on a target platform. Similar to SCDs, a self-contained executable (SCE) doesn't rely on the presence of shared components on the target system. All components, including both the .NET Core libraries and the .NET Core runtime, are included with the application and are isolated from other .NET Core applications.


## Framework-Dependent Deployments (FDD)

For an FDD, you deploy only your app and third-party dependencies. Your app will use the version of .NET Core that's present on the target system. FDD is the default deployment model for .NET Core and ASP.NET Core apps that target .NET Core.

### Why create a framework-dependent deployment?

Deploying an FDD has a number of advantages:

- You don't have to define the target operating systems that your .NET Core app will run on in advance. Because .NET Core uses a common PE file format for executables and libraries independent of the operating system, .NET Core can execute your app regardless of the underlying operating system. For more information on the PE file format, see .NET Assembly File Format.
- The size of your deployment package is small. You only deploy your app and its dependencies, not .NET Core itself.
- Unless overridden, FDDs will use the latest serviced runtime installed on the target system. This allows your application to run on the latest patched version of the .NET Core runtime. Multiple apps built as FDD that share a runtime can all be patched to run on the latest servicing runtime by the single action of updating that shared runtime. 
- Multiple apps use the same .NET Core installation, which reduces both disk space and memory usage on host systems.

There are also a few disadvantages:

- Your app can run only if the version of .NET Core your app targets, [or a later version](../versions/selection.md#framework-dependent-apps-roll-forward), is already installed on the host system.

- It's possible for the .NET Core runtime and libraries to change without your knowledge in future releases and in rare cases may change the behavior of your app.

Framework-dependent deployment is available for Windows Client, Windows Server, Mac, and Linux platforms through native installers – MSI on Windows Client and Server, PKG on Mac and various native package managers for Linux. 

To create a framework-dependent deployment, you would use the following command line:

```dotnetcli
dotnet publish -c Release --self-contained false
```


## Self-contained deployments (SCD)

For a self-contained deployment, you deploy your app and any required third-party dependencies along with the version of .NET Core that you used to build the app. Creating an SCD doesn't include the [native dependencies of .NET Core](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md) on various platforms, so these dependencies must be present before the app runs.

Starting with NET Core 2.1 SDK (version 2.1.300), .NET Core supports *patch version roll-forward*. When you create a self-contained deployment, .NET Core tools automatically include the latest serviced runtime of the .NET Core version that your application targets. (The latest serviced runtime includes security patches and other bug fixes.) The serviced runtime doesn't have to be present on your build system; it's downloaded automatically from NuGet.org. For more information, including instructions on how to opt out of patch version roll forward, see [Self-contained deployment runtime roll forward](runtime-patch-selection.md).

Each app package as SCD uses separate host executables, so you can sign a host executable for an SCD with your publisher signature.

### Why deploy a self-contained deployment?

Deploying a SCD has two major advantages:

- You have sole control of the version of .NET Core that is deployed with your app. .NET Core can be serviced only by you.

- You're providing the version of .NET Core that it will run on, so you can be assured that the target system can run your .NET Core app.

It also has a number of disadvantages:

- The .NET Core binaries appropriate for your target platform are included in the publish folder for your deployment, so you must select the target platforms for the deployment in advance, at publish time.

- You need to include .NET Core, your app, and its third-party dependencies, so the size of your deployment package is relatively large.

  Size can also be mitigated by [Trimming](Trimming) (see section on Trimming later in this guide).

- Deploying many self-contained .NET Core apps to a single system can consume significant amounts of disk space, since each app duplicates .NET Core files.

Self-contained deployment is available for Windows Client, Windows Server, MacOS, and Linux platforms. You can build an SCD deployment on any platform regardless of the target platform.

To create a self-contained deployment for a Windows 10 x64 operating system, you would use the following command line:

```dotnetcli
dotnet publish -c Release -r win10-x64 --self-contained true
```

***Note**: creating a self-contained deployment **requires** that you specify a Runtime Identifier (RID) via the -r switch.*

For a comprehensive list of all supported Runtime Identifiers (RIDs), refer to the [.NET Core RID Catalog](../rid-catalog.md).

***Note**: Starting with .NET Core 2.0, you can reduce the size of your deployment on Linux systems by approximately 28 MB by using .NET Core globalization invariant mode. Ordinarily, .NET Core on Linux relies on the ICU libraries for globalization support. In invariant mode, the libraries are excluded with your deployment, and all cultures behave like the invariant culture.*


## Framework-Dependent Executables (FDE) 

Starting with .NET Core 2.2, you can package up your framework-dependent deployment into a single file executable. Your app will use the version of .NET Core that's installed on the target system.

### Why deploy a framework-dependent executable?

Deploying an FDE has a number of advantages:

- The size of your deployment package is small. You only deploy your app and its dependencies, not .NET Core itself.

- Multiple apps use the same .NET Core installation, which reduces both disk space and memory usage on host systems.

- Your app can be run by calling the published executable without invoking the `dotnet` utility directly.

There are also a few disadvantages:

- Your app can run only if the version of .NET Core your app targets, [or a later version](../versions/selection.md#framework-dependent-apps-roll-forward), is already installed on the host system.

- It's possible for the .NET Core runtime and libraries to change without your knowledge in future releases, which may in rare cases change the behavior of your app.

- You need to publish your app for each target platform.

In this mode, you package up your application (without the .NET Core runtime) into a single file executable.

For example, to create a Framework-dependent, single file executable for the Windows 10 x64 operating system you would use the following command line:

```dotnetcli
dotnet publish -c Release -r win10-x64 --self-contained false /p:PublishSingleFile=true
```

<br/>

***Note**: Since FDD is the default deployment type, `--self-contained false` is implied if not specified*

***Note**: creating a single file executable **requires** that you specify a Runtime Identifier (RID) via the -r switch even if the executable will be Framework_dependent and not self-contained.*


## Self-Contained Executable (SCE)

Starting with .NET Core 3.0, you can package up your self-contained deployment (with the .NET Core runtime) into a single file executable. This option has some of the same benefits and drawbacks as self-contained deployments.

To create a Self-contained, single file executable for the Windows 10 x64 operating system you would use the following command line:

```dotnetcli
dotnet publish -c Release -r win10-x64 --self-contained true /p:PublishSingleFile=true
```

<br/>

***Note**: creating a self-contained executable **requires** that you specify a Runtime Identifier (RID) via the -r switch.*

## Summary

Both Framework-Dependent Deployment and Self-Contained Deployment have their own pros and cons. 

To summarize,

| Attribute	                                                | Framework-Dependent Deployment | Self-Contained Deployment | Framework-Dependent Executable | Self-Contained Executable |
| :--------------------------------------------------------- |:------------------------------:|:-------------------------:|:------------------------------:|:-------------------------:|
| Need machine-wide Core Runtime                            | ✔️                            | ❌                        | ✔️                            | ❌                        |    
| Small Package                                             | ✔️                            | ❌                        | ✔️                            | ❌                        |  
| Target Machine specific publish                           | ❌                             | ✔️                       | ✔️                            | ✔️                       |  
| Need target machine native dependencies installed         | ✔️                            | ✔️                       | ✔️                            | ✔️                       |  
| Share Core Runtime across multiple apps                   | ✔️                            | ❌                        | ✔️                            | ❌                        |  
| Isolated from changes to shared runtime                   | ❌                             | ✔️                       | ❌                             | ✔️                       |  
| Trimming Available                                        | ❌                             | ✔️                        | ❌                            | ✔️                       |  



## Step-by-step examples

Both Self-Contained and Framework-Dependent deployments for your app can be created using either Visual Studio or the CLI. 

For step-by-step examples of deploying .NET Core apps with CLI tools, see [Deploying .NET Core Apps with CLI Tools](deploy-with-cli.md). 

For step-by-step examples of deploying .NET Core apps with Visual Studio, see [Deploying .NET Core Apps with Visual Studio](deploy-with-vs.md). 

For more information on version binding at runtime, see the article on [version binding in .NET Core](../versions/selection.md).


## See also
- [Packages, Metapackages, and Frameworks](../packages.md)
- [.NET Core Runtime IDentifier (RID) catalog](../rid-catalog.md)
