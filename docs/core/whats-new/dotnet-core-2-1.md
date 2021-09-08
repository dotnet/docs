---
title: What's new in .NET Core 2.1
description: Learn about the new features found in .NET Core 2.1.
dev_langs: 
  - "csharp"
  - "vb"
ms.date: 10/10/2018
---
# What's new in .NET Core 2.1

.NET Core 2.1 includes enhancements and new features in the following areas:

- [Tooling](#tooling)
- [Roll forward](#roll-forward)
- [Deployment](#deployment)
- [Windows Compatibility Pack](#windows-compatibility-pack)
- [JIT compilation improvements](#jit-compiler-improvements)
- [API changes](#api-changes)

## Tooling

The .NET Core 2.1 SDK (v 2.1.300), the tooling included with .NET Core 2.1, includes the following changes and enhancements:

### Build performance improvements

A major focus of .NET Core 2.1 is improving build-time performance, particularly for incremental builds. These performance improvements apply to both command-line builds using `dotnet build` and to builds in Visual Studio. Some individual areas of improvement include:

- For package asset resolution, resolving only assets used by a build rather than all assets.

- Caching of assembly references.

- Use of long-running SDK build servers, which are processes that span across individual `dotnet build` invocations. They eliminate the need to JIT-compile large blocks of code every time `dotnet build` is run. Build server processes can be automatically terminated with the following command:

   ```dotnetcli
   dotnet buildserver shutdown
   ```

### New CLI commands

A number of tools that were available only on a per project basis using `DotnetCliToolReference` are now available as part of the .NET Core SDK. These tools include:

- `dotnet watch` provides a file system watcher that waits for a file to change before executing a designated set of commands. For example, the following command automatically rebuilds the current project and generates verbose output whenever a file in it changes:

   ```dotnetcli
   dotnet watch -- --verbose build
   ```

   Note the `--` option that precedes the `--verbose` option. It delimits the options passed directly to the `dotnet watch` command from the arguments that are passed to the child `dotnet` process. Without it, the `--verbose` option applies to the `dotnet watch` command, not the `dotnet build` command.
  
   For more information, see [Develop ASP.NET Core apps using dotnet watch](/aspnet/core/tutorials/dotnet-watch).

- `dotnet dev-certs` generates and manages certificates used during development in ASP.NET Core applications.

- `dotnet user-secrets` manages the secrets in a user secret store in ASP.NET Core applications.

- `dotnet sql-cache` creates a table and indexes in a Microsoft SQL Server database to be used for distributed caching.

- `dotnet ef` is a tool for managing databases, <xref:Microsoft.EntityFrameworkCore.DbContext> objects, and migrations in Entity Framework Core applications. For more information, see [EF Core .NET Command-line Tools](/ef/core/miscellaneous/cli/dotnet).

### Global Tools

.NET Core 2.1 supports *Global Tools* -- that is, custom tools that are available globally from the command line. The extensibility model in previous versions of .NET Core made custom tools available on a per project basis only by using `DotnetCliToolReference`.

To install a Global Tool, you use the [dotnet tool install](../tools/dotnet-tool-install.md) command. For example:

```dotnetcli
dotnet tool install -g dotnetsay
```

Once installed, the tool can be run from the command line by specifying the tool name. For more information, see [.NET Core Global Tools overview](../tools/global-tools.md).

### Tool management with the `dotnet tool` command

In .NET Core 2.1 SDK, all tools operations use the `dotnet tool` command. The following options are available:

- [`dotnet tool install`](../tools/dotnet-tool-install.md) to install a tool.

- [`dotnet tool update`](../tools/dotnet-tool-update.md) to uninstall and reinstall a tool, which effectively updates it.

- [`dotnet tool list`](../tools/dotnet-tool-list.md) to list currently installed tools.

- [`dotnet tool uninstall`](../tools/dotnet-tool-uninstall.md) to uninstall currently installed tools.

## Roll forward

All .NET Core applications starting with .NET Core 2.0 automatically roll forward to the latest *minor version* installed on a system.

Starting with .NET Core 2.0, if the version of .NET Core that an application was built with is not present at run time, the application automatically runs against the latest installed *minor version* of .NET Core. In other words, if an application is built with .NET Core 2.0, and .NET Core 2.0 is not present on the host system but .NET Core 2.1 is, the application runs with .NET Core 2.1.

> [!IMPORTANT]
> This roll-forward behavior doesn't apply to preview releases. By default, it also doesn't apply to major releases, but this can be changed with the settings below.

You can modify this behavior by changing the setting for the roll-forward on no candidate shared framework. The available settings are:

- `0` - disable minor version roll-forward behavior. With this setting, an application built for .NET Core 2.0.0 will roll forward to .NET Core 2.0.1, but not to .NET Core 2.2.0 or .NET Core 3.0.0.
- `1` - enable minor version roll-forward behavior. This is the default value for the setting. With this setting, an application built for .NET Core 2.0.0 will roll forward to either .NET Core 2.0.1 or .NET Core 2.2.0, depending on which one is installed, but it will not roll forward to .NET Core 3.0.0.
- `2` - enable minor and major version roll-forward behavior. If set, even different major versions are considered, so an application built for .NET Core 2.0.0 will roll forward to .NET Core 3.0.0.

You can modify this setting in any of three ways:

- Set the `DOTNET_ROLL_FORWARD_ON_NO_CANDIDATE_FX` environment variable to the desired value.

- Add the following line with the desired value to the *.runtimeconfig.json* file:

   ```json
   "rollForwardOnNoCandidateFx" : 0
   ```

- When using the [.NET Core CLI](../tools/index.md), add the following option with the desired value to a .NET Core command such as `run`:

   ```dotnetcli
   dotnet run --rollForwardOnNoCandidateFx=0
   ```

Patch version roll forward is independent of this setting and is done after any potential minor or major version roll forward is applied.

## Deployment

### Self-contained application servicing

`dotnet publish` now publishes self-contained applications with a serviced runtime version. When you publish a self-contained application with the .NET Core 2.1 SDK (v 2.1.300), your application includes the latest serviced runtime version known by that SDK. When you upgrade to the latest SDK, you'll publish with the latest .NET Core runtime version. This applies for .NET Core 1.0 runtimes and later.

Self-contained publishing relies on runtime versions on NuGet.org. You do not need to have the serviced runtime on your machine.

Using the .NET Core 2.0 SDK, self-contained applications are published with the .NET Core 2.0.0 runtime unless a different version is specified via the `RuntimeFrameworkVersion` property. With this new behavior, you'll no longer need to set this property to select a higher runtime version for a self-contained application. The easiest approach going forward is to always publish with .NET Core 2.1 SDK (v 2.1.300).

For more information, see [Self-contained deployment runtime roll forward](../deploying/runtime-patch-selection.md).

## Windows Compatibility Pack

When you port existing code from the .NET Framework to .NET Core, you can use the [Windows Compatibility Pack](https://www.nuget.org/packages/Microsoft.Windows.Compatibility). It provides access to 20,000 more APIs than are available in .NET Core. These APIs include types in the <xref:System.Drawing?displayProperty=nameWithType> namespace, the <xref:System.Diagnostics.EventLog> class, WMI, Performance Counters, Windows Services, and the Windows registry types and members.

## JIT compiler improvements

.NET Core incorporates a new JIT compiler technology called *tiered compilation* (also known as *adaptive optimization*) that can significantly improve performance. Tiered compilation is an opt-in setting.

One of the important tasks performed by the JIT compiler is optimizing code execution. For little-used code paths, however, the compiler may spend more time optimizing code than the runtime spends running unoptimized code. Tiered compilation introduces two stages in JIT compilation:

- A **first tier**, which generates code as quickly as possible.

- A **second tier**, which generates optimized code for those methods that are executed frequently. The second tier of compilation is performed in parallel for enhanced performance.

You can opt into tiered compilation in either of two ways.

- To use tiered compilation in all projects that use the .NET Core 2.1 SDK, set the following environment variable:

  ```console
  COMPlus_TieredCompilation="1"
  ```

- To use tiered compilation on a per-project basis, add the `<TieredCompilation>` property to the `<PropertyGroup>` section of the MSBuild project file, as the following example shows:

   ```xml
   <PropertyGroup>
      <!-- other property definitions -->

      <TieredCompilation>true</TieredCompilation>
   </PropertyGroup>
   ```

## API changes

### `Span<T>` and `Memory<T>`

.NET Core 2.1 includes some new types that make working with arrays and other types of memory much more efficient. The new types include:

- <xref:System.Span%601?displayProperty=nameWithType> and <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>.

- <xref:System.Memory%601?displayProperty=nameWithType> and <xref:System.ReadOnlyMemory%601?displayProperty=nameWithType>.

Without these types, when passing such items as a portion of an array or a section of a memory buffer, you have to make a copy of some portion of the data before passing it to a method. These types provide a virtual view of that data that eliminates the need for the additional memory allocation and copy operations.

The following example uses a <xref:System.Span%601> and <xref:System.Memory%601> instance to provide a virtual view of 10 elements of an array.

[!code-csharp[Span\<T>](./snippets/dotnet-core-2-1/csharp/Program.cs)]

[!code-vb[Memory\<T>](./snippets/dotnet-core-2-1/vb/Program.vb)]

### Brotli compression

.NET Core 2.1 adds support for Brotli compression and decompression. Brotli is a general-purpose lossless compression algorithm that is defined in [RFC 7932](https://www.ietf.org/rfc/rfc7932.txt) and is supported by most web browsers and major web servers. You can use the stream-based <xref:System.IO.Compression.BrotliStream?displayProperty=nameWithType> class or the high-performance span-based <xref:System.IO.Compression.BrotliEncoder?displayProperty=nameWithType> and <xref:System.IO.Compression.BrotliDecoder?displayProperty=nameWithType> classes. The following example illustrates compression with the <xref:System.IO.Compression.BrotliStream> class:

[!code-csharp[Brotli compression](./snippets/dotnet-core-2-1/csharp/brotli.cs#1)]

[!code-vb[Brotli compression](./snippets/dotnet-core-2-1/vb/brotli.vb#1)]

The <xref:System.IO.Compression.BrotliStream> behavior is the same as <xref:System.IO.Compression.DeflateStream> and <xref:System.IO.Compression.GZipStream>, which makes it easy to convert code that calls these APIs to <xref:System.IO.Compression.BrotliStream>.

### New cryptography APIs and cryptography improvements

.NET Core 2.1 includes numerous enhancements to the cryptography APIs:

- <xref:System.Security.Cryptography.Pkcs.SignedCms?displayProperty=nameWithType> is available in the System.Security.Cryptography.Pkcs package. The implementation is the same as the <xref:System.Security.Cryptography.Pkcs.SignedCms> class in the .NET Framework.

- New overloads of the <xref:System.Security.Cryptography.X509Certificates.X509Certificate.GetCertHash%2A?displayProperty=nameWithType> and <xref:System.Security.Cryptography.X509Certificates.X509Certificate.GetCertHashString%2A?displayProperty=nameWithType> methods accept a hash algorithm identifier to enable callers to get certificate thumbprint values using algorithms other than SHA-1.

- New <xref:System.Span%601>-based cryptography APIs are available for hashing, HMAC, cryptographic random number generation, asymmetric signature generation, asymmetric signature processing, and RSA encryption.

- The performance of <xref:System.Security.Cryptography.Rfc2898DeriveBytes?displayProperty=nameWithType> has improved by about 15% by using a <xref:System.Span%601>-based implementation.

- The new <xref:System.Security.Cryptography.CryptographicOperations?displayProperty=nameWithType> class includes two new methods:

  - <xref:System.Security.Cryptography.CryptographicOperations.FixedTimeEquals%2A> takes a fixed amount of time to return for any two inputs of the same length, which makes it suitable for use in cryptographic verification to avoid contributing to timing side-channel information.

  - <xref:System.Security.Cryptography.CryptographicOperations.ZeroMemory%2A> is a memory-clearing routine that cannot be optimized.

- The static <xref:System.Security.Cryptography.RandomNumberGenerator.Fill%2A?displayProperty=nameWithType> method fills a <xref:System.Span%601> with random values.

- The <xref:System.Security.Cryptography.Pkcs.EnvelopedCms?displayProperty=nameWithType> is now supported on Linux and macOS.

- Elliptic-Curve Diffie-Hellman (ECDH) is now available in the <xref:System.Security.Cryptography.ECDiffieHellman?displayProperty=nameWithType> class family. The surface area is the same as in the .NET Framework.

- The instance returned by <xref:System.Security.Cryptography.RSA.Create%2A?displayProperty=nameWithType> can encrypt or decrypt with OAEP using a SHA-2 digest, as well as generate or validate signatures using RSA-PSS.

### Sockets improvements

.NET Core includes a new type, <xref:System.Net.Http.SocketsHttpHandler?displayProperty=nameWithType>, and a rewritten <xref:System.Net.Http.HttpMessageHandler?displayProperty=nameWithType>, that form the basis of higher-level networking APIs.  <xref:System.Net.Http.SocketsHttpHandler?displayProperty=nameWithType>, for example, is the basis of the <xref:System.Net.Http.HttpClient> implementation. In previous versions of .NET Core, higher-level APIs were based on native networking implementations.

The sockets implementation introduced in .NET Core 2.1 has a number of advantages:

- A significant performance improvement when compared with the previous implementation.

- Elimination of platform dependencies, which simplifies deployment and servicing.

- Consistent behavior across all .NET Core platforms.

<xref:System.Net.Http.SocketsHttpHandler> is the default implementation in .NET Core 2.1. However, you can configure your application to use the older <xref:System.Net.Http.HttpClientHandler> class by calling the <xref:System.AppContext.SetSwitch%2A?displayProperty=nameWithType> method:

```csharp
AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", false);
```

```vb
AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", False)
```

You can also use an environment variable to opt out of using sockets implementations based on <xref:System.Net.Http.SocketsHttpHandler>. To do this, set the `DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER` to either `false` or 0.

On Windows, you can also choose to use <xref:System.Net.Http.WinHttpHandler?displayProperty=nameWithType>, which relies on a native implementation, or the <xref:System.Net.Http.SocketsHttpHandler> class by passing an instance of the class to the <xref:System.Net.Http.HttpClient> constructor.

On Linux and macOS, you can only configure <xref:System.Net.Http.HttpClient> on a per-process basis. On Linux, you need to deploy [libcurl](https://curl.haxx.se/libcurl/) if you want to use the old <xref:System.Net.Http.HttpClient> implementation. (It is installed with .NET Core 2.0.)

### Breaking changes

For information about breaking changes, see [Breaking changes for migration from version 2.0 to 2.1](../compatibility/2.1.md).

## See also

- [What's new in .NET Core 3.1](dotnet-core-3-1.md)
- [New features in EF Core 2.1](/ef/core/what-is-new/ef-core-2.1)
- [What's new in ASP.NET Core 2.1](/aspnet/core/aspnetcore-2.1)
