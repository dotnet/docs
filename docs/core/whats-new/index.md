---
title: What's new in .NET Core 2.1
description: Learn about the new features found in .NET Core.
author: rpetrusha
ms.author: ronpet
ms.date: 05/07/2018
---
# What's new in [!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)]

The most recent release of .NET Core is [!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)]. It includes enhancements and new features in the following areas:

- [Tooling](#tooling)
- [Roll forward](#roll-forward)
- [Deployment](#deployment)
- [Windows Compatibility Pack](#windows-compatibility-pack)
- [API changes](#api-changes) 

For information on new features and enhancements in earlier releases of .NET Core, see the following topics:

- [What's new in .NET Core 2.0](whats-new-in-core-20.md)

## Tooling

The tooling included with [!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)] includes the following changes and enhancements:

### Build performance improvements

A major focus of [!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)] is improving build-time performance, particularly for incremental builds. These performance improvements apply to both command-line builds using `dotnet build` and to builds in Visual Studio. Some individual areas of improvement include:

- For package asset resolution, resolving only assets used by a build rather than all assets. Improvements in package asset resolution in regular and incremental builds. Previously, all items in a package were resolved. With [!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)], only items that are used by the build are resolved.

- Caching of assembly references.

- Use of long-running SDK build servers, which are processes that span individual `dotnet build` invocations. They eliminate the need to JIT-compile large blocks of code every time `dotnet build` is run. Build server processes can be automatically terminated with the following command:

   ```console
   dotnet buildserver shutdown
   ```

### New CLI commands

A number of tools that were available only on a per project basis using [`DotnetCliToolReference`](../tools/extensibility.md) are now available as part of the .NET Core SDK. These include:

- `dotnet watch` provides a file system watcher that waits for a file to change before executing a designated set of commands. For example, the following command automatically rebuilds the current project and generates verbose output whenever a file in it changes:

   ```console
   dotnet watch -- --verbose build
   ```

- `dotnet dev-certs` generates and manages certificates used during development in ASP.NET Core applications.

- `dotnet user-secrets` manages the secrets in a user secret store in ASP.NET Core applications.

- `dotnet sql-cache` creates a table and indexes in a Microsoft SQL Server database to be used for distributed caching.

- `dotnet ef` is a tool for managing databases, <xref:Microsoft.EntityFrameworkCore.DbContext> objects, and migrations in Entity Framework Core applications.

### Global tools

[!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)] supports *global tools* -- that is, custom tools that are available globally from the command line. The extensibility model in previous versions of .NET Core made custom tools available on a per project basis only by using [`DotnetCliToolReference`](../tools/extensibility.md).

To install a global tool, you use the `dotnet tool install -g <tool-name>` command. For example:

```console
dotnet tool install -g dotnetsay
```

Once installed, the tool can be run from the command line by specifying the tool name.

### Single-source tool management with the `dotnet tool` command

In [!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)], all tools operations use the `dotnet tool` command. The following options are available:

- `dotnet tool install` to install a tool.

- `dotnet tool update` to uninstall and reinstall a tool, which effectively updates it.

- `dotnet tool list` to list currently installed tools.

## Roll forward

All .NET Core applications starting with the .NET Core 2.0 automatically roll forward to the latest *minor version* installed on a system. That is, if the .NET Core version that an application was built with is not present, the application runs against the latest installed minor version. In other words, if an application is built with .NET Core 2.0 and .NET Core 2.0 itself is not present on the host system but [!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)] is, the application runs with [!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)].

> [!IMPORTANT] 
> This roll-forward behavior does not apply to preview releases. Nor does it apply to major releases. For example, a .NET Core 1.0 application would not roll forward to .NET Core 2.0 or [!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)].

You can also disable minor vesion roll forward in any of three ways:

- Set the `DOTNET_ROLL_FORWARD_ON_NO_CANDIDATE_FX` environment variable equal to 0,

- Add the following line to the runtimeconfig.json file:

   ```
   rollForwardOnNoCandidateFx=0
   ```

- When using [.NET Core CLI tools](../tools/index.md), include the following option with a .NET Core command such as `run`:

```console
dotnet core run --rollForwardOnNoCandidateFx=0
```

## Deployment

### Self-contained application servicing

`dotnet publish` now publishes self-contained applications with a serviced runtime version. When you publish a self-contained application with the [!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)] SDK, your application includes the latest serviced runtime version known by that SDK. When you upgrade to the latest SDK, you’ll publish with the latest .NET Core runtime version. This applies for .NET Core 1.0 runtimes and later.

Self-contained publishing relies on runtime versions on NuGet.org. You do not need to have the serviced runtime on your machine.

Using the .NET Core 2.0 SDK, self-contained applications are published with the .NET Core 2.0.0 Runtime unless a different version is specified via the `RuntimeFrameworkVersion property`. With this new behavior, you’ll no longer need to set this property to select a higher runtime version for a self-contained application. The easiest approach going forward is to always publish with [!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)] SDK.

## Windows Compatibility Pack

When you port existing code from the .NET Framework to .NET Core, you can use the [Windows Compatibility Pack](https://www.nuget.org/packages/Microsoft.Windows.Compatibility). It provides access to 20,000 more APIs than are available in .NET Core. Theses include types in the <xref:System.Drawing?displayProperty="nameWithType"> namespace, the <xref:System.Diagnostics.EventLog> class, WMI, Performance Counters, and Windows Services, and the Windows registry types and members.

## API changes 

### `Span<T>` and `Memory<T>`

[!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)] includes some new types that make working with arrays and other types of memory much more efficient. The new types include:

- <xref:System.Span%601?displayProperty=nameWithType> and <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>.

- <xref:System.Memory%601?displayProperty=nameWithType> and <xref:System.ReadOnlyMemory%601>.

Without these types, when passing such items as a portion of an array or a section of a memory buffer, you have to make a copy of some portion of the data before passing it to a method. These types provide a virtual view of that data which eliminates the need for the additional memory allocation and copy operations.

The following example uses a <xref:System.Span%601> instance to provide a virtual view of ten elements of an array.

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = new int[100];
        for (int ctr = 0; ctr < 100; ctr++)
        {
           numbers[ctr] = (ctr + 1) * 2;  
        } 

        var part = new Span<int>(numbers, 10, 10);
        foreach (var value in part)
           Console.Write($"{value}  ");
    }
}
// The example displays the following output:
//      2  24  26  28  30  32  34  36  38  4
```

### Sockets improvements

.NET Core includes a new type, <xref:System.Net.Http.SocketsHttpHandler?displayProperty=nameWithType>, and a rewritten <xref:System.Net.Http.HttpMessageHandler?displayProperty=nameWithType>, that form the basis of higher-level networking APIs.  <xref:System.Net.Http.SocketsHttpHandler?displayProperty=nameWithType>, for example, is the basis of the <xref:System.Web.HttpClient> implmentation. In previous versions of .NET Core, higher-level APIs were based on native networking implementations.

The sockets implementation introduced in [!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)] has a number of advantages:

- A significant performance improvement when compared with the previous implementation.

- Elimination on platform dependencies, which simplifies deployment and servicing.

- Consistent behavior across all .NET Core platforms.

Sockets based on <xref:System.Net.Http.SocketsHttpHandler> is the default implementation in [!INCLUDE[.NET Core 2.1](~/includes/net-core-21.md)]. However, you can configure your application to use the older <xref:System.Net.Http.HttpClientHandler> class by calling the <xref:System.AppContext.SetSwitch%2A?displayProperty="nameWithType"> method:

```csharp
AppContext.SetSwitch("System.Net.Http>useSocketsHttpHandler", false);
```

You can also use an environment variable to opt out of using sockets implementations based on <xref:System.Net.Http.SocketsHttpHandler>. To do this, set the `DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER` to either `false` or 0.

On Windows, you can also choose to use  <xref:System.Net.Http.WinHttpHandler?displayProperty=nameWithType>, which relies on a native implementation, or the <xref:System.Net.Http.SocketsHttpHandler> class by passing an instance of the class to the <xref:System.Net.Http.HttpClient> constructor.

On Linux and macOS, you can only configure <xref:System.Net.Http.HttpClient> on a per-process basis. On Linux, you need to deploy [libcurl](https://curl.haxx.se/libcurl/) if you want to use the old <xref:System.Net.Http.HttpClient> implementation. (It is installed with .NET Core 2.0.)

## See also

[What's new in ASP.NET Core 2.0](/aspnet/core/aspnetcore-2.0)
