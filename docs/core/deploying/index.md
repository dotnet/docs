---
title: .NET Core Application Deployment
description: Learn about the ways to deploy a .NET Core application.
author: rpetrusha
ms.author: ronpet
ms.date: 12/03/2018
ms.custom: seodec18
---
# .NET Core application deployment

You can create three types of deployments for .NET Core applications:

- Framework-dependent deployment. As the name implies, framework-dependent deployment (FDD) relies on the presence of a shared system-wide version of .NET Core on the target system. Because .NET Core is already present, your app is also portable between installations of .NET Core. Your app contains only its own code and any third-party dependencies that are outside of the .NET Core libraries. FDDs contain *.dll* files that can be launched by using the [dotnet utility](../tools/dotnet.md) from the command line. For example, `dotnet app.dll` runs an application named `app`.

- Self-contained deployment. Unlike FDD, a self-contained deployment (SCD) doesn't rely on the presence of shared components on the target system. All components, including both the .NET Core libraries and the .NET Core runtime, are included with the application and are isolated from other .NET Core applications. SCDs include an executable (such as *app.exe* on Windows platforms for an application named `app`), which is a renamed version of the platform-specific .NET Core host, and a *.dll* file (such as *app.dll*), which is the actual application.

- Framework-dependent executables. Produces an executable that runs on a target platform. Similar to FDDs, framework-dependent executables (FDE) are platform-specific and aren't self-contained. These deployments still rely on the presence of a shared system-wide version of .NET Core to run. Unlike an SCD, your app only contains your code and any third-party dependencies that are outside of the .NET Core libraries. FDEs produce an executable that runs on the target platform.

## Framework-dependent deployments (FDD)

For an FDD, you deploy only your app and third-party dependencies. Your app will use the version of .NET Core that's present on the target system. This is the default deployment model for .NET Core and ASP.NET Core apps that target .NET Core.

### Why create a framework-dependent deployment?

Deploying an FDD has a number of advantages:

- You don't have to define the target operating systems that your .NET Core app will run on in advance. Because .NET Core uses a common PE file format for executables and libraries regardless of operating system, .NET Core can execute your app regardless of the underlying operating system. For more information on the PE file format, see [.NET Assembly File Format](../../standard/assembly-format.md).

- The size of your deployment package is small. You only deploy your app and its dependencies, not .NET Core itself.

- Unless overridden, FDDs will use the latest serviced runtime installed on the target system. This allows your application to use the latest patched version of the .NET Core runtime. 

- Multiple apps use the same .NET Core installation, which reduces both disk space and memory usage on host systems.

There are also a few disadvantages:

- Your app can run only if the version of .NET Core your app targets, [or a later version](../versions/selection.md#framework-dependent-apps-roll-forward), is already installed on the host system.

- It's possible for the .NET Core runtime and libraries to change without your knowledge in future releases. In rare cases, this may change the behavior of your app.

## Self-contained deployments (SCD)

For a self-contained deployment, you deploy your app and any required third-party dependencies along with the version of .NET Core that you used to build the app. Creating an SCD doesn't include the [native dependencies of .NET Core](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md) on various platforms, so these must be present before the app runs. For more information on version binding at runtime, see the article on [version binding in .NET Core](../versions/selection.md).

Starting with NET Core 2.1 SDK (version 2.1.300), .NET Core supports *patch version roll forward*. When you create a self-contained deployment, .NET Core tools automatically include the latest serviced runtime of the .NET Core version that your application targets. (The latest serviced runtime includes security patches and other bug fixes.) The serviced runtime does not have to be present on your build system; it is downloaded automatically from NuGet.org. For more information, including instructions on how to opt out of patch version roll forward, see [Self-contained deployment runtime roll forward](runtime-patch-selection.md).

FDD and SCD deployments use separate host executables, so you can sign a host executable for an SCD with your publisher signature.

### Why deploy a self-contained deployment?

Deploying a Self-contained deployment has two major advantages:

- You have sole control of the version of .NET Core that is deployed with your app. .NET Core can be serviced only by you.

- You can be assured that the target system can run your .NET Core app, since you're providing the version of .NET Core that it will run on.

It also has a number of disadvantages:

- Because .NET Core is included in your deployment package, you must select the target platforms for which you build deployment packages in advance.

- The size of your deployment package is relatively large, since you have to include .NET Core as well as your app and its third-party dependencies.

  Starting with .NET Core 2.0, you can reduce the size of your deployment on Linux systems by approximately 28 MB by using .NET Core [*globalization invariant mode*](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/globalization-invariant-mode.md). Ordinarily, .NET Core on Linux relies on the [ICU libraries](http://icu-project.org) for globalization support. In invariant mode, the libraries are not included with your deployment, and all cultures behave like the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType).

- Deploying numerous self-contained .NET Core apps to a system can consume significant amounts of disk space, since each app duplicates .NET Core files.

## Framework-dependent executables (FDE)

Starting with .NET Core 2.2, you can deploy your app as an FDE, along with any required third-party dependencies. Your app will use the version of .NET Core that's installed on the target system.

### Why deploy a framework-dependent executable?

Deploying an FDE has a number of advantages:

- The size of your deployment package is small. You only deploy your app and its dependencies, not .NET Core itself.

- Multiple apps use the same .NET Core installation, which reduces both disk space and memory usage on host systems.

- Your app can be run by calling the published executable without invoking the `dotnet` utility directly.

There are also a few disadvantages:

- Your app can run only if the version of .NET Core your app targets, [or a later version](../versions/selection.md#framework-dependent-apps-roll-forward), is already installed on the host system.

- It's possible for the .NET Core runtime and libraries to change without your knowledge in future releases. In rare cases, this may change the behavior of your app.

- You must publish your app for each target platform.

## Step-by-step examples

For step-by-step examples of deploying .NET Core apps with CLI tools, see [Deploying .NET Core Apps with CLI Tools](deploy-with-cli.md). For step-by-step examples of deploying .NET Core apps with Visual Studio, see [Deploying .NET Core Apps with Visual Studio](deploy-with-vs.md). 

## See also

- [Deploying .NET Core Apps with CLI Tools](deploy-with-cli.md)
- [Deploying .NET Core Apps with Visual Studio](deploy-with-vs.md)
- [Packages, Metapackages and Frameworks](../packages.md)
- [.NET Core Runtime IDentifier (RID) catalog](../rid-catalog.md)
