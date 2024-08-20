---
title: Port from .NET Framework to .NET 7
description: Understand the porting process and discover tools you might find helpful when porting a .NET Framework project to .NET 7.
author: adegeo
ms.date: 07/23/2024
ms.custom: devdivchpfy22, updateeachrelease
no-loc: ["package.config", PackageReference]
---
# Overview of porting from .NET Framework to .NET

This article provides an overview of what you should consider when porting your code from .NET Framework to .NET (formerly named .NET Core). Porting to .NET from .NET Framework is relatively straightforward for many projects. The complexity of your projects dictates how much work you'll need to do after the initial migration of the project files.

Projects where the app model is available in .NET, such as libraries, console apps, and desktop apps, usually require little change. Projects that require a new app model, such as moving to [ASP.NET Core from ASP.NET](/aspnet/core/migration/proper-to-2x/), require more work. Many patterns from the old app model have equivalents that can be used during the conversion.

## Windows desktop technologies

Many applications created for .NET Framework use a desktop technology such as Windows Forms or Windows Presentation Foundation (WPF). Both Windows Forms and WPF are available in .NET, but they remain Windows-only technologies.

Consider the following dependencies before you migrate a Windows Forms or WPF application:

- Project files for .NET use a different format than .NET Framework.
- Your project might use an API that isn't available in .NET.
- Third-party controls and libraries might not have been ported to .NET and remain only available to .NET Framework.
- Your project uses a [technology that is no longer available](net-framework-tech-unavailable.md) in .NET.

.NET uses the open-source versions of Windows Forms and WPF and includes enhancements over .NET Framework.

For tutorials on migrating your desktop application to .NET, see one of the following articles:

- [Migrate .NET Framework WPF apps to .NET](/dotnet/desktop/wpf/migration/convert-project-from-net-framework)
- [Migrate .NET Framework Windows Forms apps to .NET](/dotnet/desktop/winforms/migration/)

## Windows-specific APIs

Applications can still P/Invoke native libraries on platforms supported by .NET. This technology isn't limited to Windows. However, if the library you're referencing is Windows-specific, such as a _user32.dll_ or _kernel32.dll_, then the code only works on Windows. For each platform you want your app to run on, you have to either find platform-specific versions, or make your code generic enough to run on all platforms.

When you're porting an application from .NET Framework to .NET, your application probably used a library provided by .NET Framework. Many APIs that were available in .NET Framework weren't ported to .NET because they relied on Windows-specific technology, such as the Windows Registry or the GDI+ drawing model.

The **Windows Compatibility Pack** provides a large portion of the .NET Framework API surface to .NET and is provided via the [Microsoft.Windows.Compatibility NuGet package](https://www.nuget.org/packages/Microsoft.Windows.Compatibility).

For more information, see [Use the Windows Compatibility Pack to port code to .NET](windows-compat-pack.md).

## .NET Framework compatibility mode

The .NET Framework compatibility mode was introduced in .NET Standard 2.0. The compatibility mode allows .NET Standard and .NET projects to reference .NET Framework libraries as if they were compiled for the project's target framework. However, some .NET implementations might support a larger chunk of .NET Framework than others. For example, .NET Core 3.0 extends the .NET Framework compatibility mode to Windows Forms and WPF. Referencing .NET Framework libraries doesn't work for all projects, such as if the library uses WPF APIs, but it does unblock many porting scenarios. For more information, see the [Analyze your dependencies to port code from .NET Framework to .NET](third-party-deps.md#net-framework-compatibility-mode).

Referencing .NET Framework libraries doesn't work in all cases, as it depends on which .NET Framework APIs were used and whether or not these APIs are supported by the project's target framework. Also, some of the .NET Framework APIs will only work on Windows. The .NET Framework compatibility mode unblocks many porting scenarios but you should test your projects to ensure that they also work at runtime. For more information, see the [Analyze your dependencies to port code from .NET Framework to](third-party-deps.md#net-framework-compatibility-mode).

## Target framework changes in SDK-style projects

As previously mentioned, the project files for .NET use a different format than .NET Framework, known as the SDK-style project format. Even if you're not moving from .NET Framework to .NET, you should still upgrade the project file to the latest format. The way to specify a target framework is different in SDK-style projects. In .NET Framework, the `<TargetFrameworkVersion>` property is used with a moniker that specifies the version of .NET Framework. For example, .NET Framework 4.7.2 looks like the following snippet:

```xml
<PropertyGroup>
  <TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>
</PropertyGroup>
```

An SDK-style project uses a different property to identify the target framework, the `<TargetFramework>` property. When targeting .NET Framework, the moniker starts with `net` and ends with the version of .NET Framework without any periods. For example, the moniker to target .NET Framework 4.7.2 is `net472`:

```xml
<PropertyGroup>
  <TargetFramework>net472</TargetFramework>
</PropertyGroup>
```

For a list of all target monikers, see [Target frameworks in SDK-style projects](../../standard/frameworks.md#supported-target-frameworks).

## Unavailable technologies

There are a few technologies in .NET Framework that don't exist in .NET:

- [Application domains](net-framework-tech-unavailable.md#application-domains)

  Creating additional application domains isn't supported. For code isolation, use separate processes or containers as an alternative.

- [Remoting](net-framework-tech-unavailable.md#remoting)

  Remoting is used for communicating across application domains, which are no longer supported. For simple communication across processes, consider inter-process communication (IPC) mechanisms as an alternative to remoting, such as the <xref:System.IO.Pipes> class or the <xref:System.IO.MemoryMappedFiles.MemoryMappedFile> class. For more complex scenarios, consider frameworks such as [StreamJsonRpc](https://github.com/microsoft/vs-streamjsonrpc) or [ASP.NET Core](/aspnet/core) (either using [gRPC](/aspnet/core/grpc) or [RESTful Web API services](/aspnet/core/web-api)).

  Because remoting isn't supported, calls to `BeginInvoke()` and `EndInvoke()` on delegate objects will throw `PlatformNotSupportedException`.

- [Code access security (CAS)](net-framework-tech-unavailable.md#code-access-security-cas)

  CAS was a sandboxing technique supported by .NET Framework but deprecated in .NET Framework 4.0. It was replaced by Security Transparency and it isn't supported in .NET. Instead, use security boundaries provided by the operating system, such as virtualization, containers, or user accounts.

- [Security transparency](net-framework-tech-unavailable.md#security-transparency)

  Similar to CAS, the security transparency sandboxing technique is no longer recommended for .NET Framework applications and it isn't supported in .NET. Instead, use security boundaries provided by the operating system, such as virtualization, containers, or user accounts.

- <xref:System.EnterpriseServices?displayProperty=fullName>

  <xref:System.EnterpriseServices?displayProperty=fullName> (COM+) isn't supported in .NET.

- Windows Workflow Foundation (WF)

  WF isn't supported in .NET. For an alternative, see [CoreWF](https://github.com/UiPath/corewf).

For more information about these unsupported technologies, see [.NET Framework technologies unavailable on .NET 6+](net-framework-tech-unavailable.md).

## Cross-platform

.NET (formerly known as .NET Core) is designed to be cross-platform. If your code doesn't depend on Windows-specific technologies, it can run on other platforms such as macOS, Linux, and Android. Such code includes project types like:

- Libraries
- Console-based tools
- Automation
- ASP.NET sites

.NET Framework is a Windows-only component. When your code uses Windows-specific technologies or APIs, such as Windows Forms and WPF, the code can still run on .NET but it doesn't run on other operating systems.

It's possible that your library or console-based application can be used cross-platform without changing much. When you're porting to .NET, you might want to take this into consideration and test your application on other platforms.

## The future of .NET Standard

.NET Standard is a formal specification of .NET APIs that are available on multiple .NET implementations. The motivation behind .NET Standard was to establish greater uniformity in the .NET ecosystem. Starting with .NET 5, a different approach to establishing uniformity has been adopted, and this new approach eliminates the need for .NET Standard in many scenarios. For more information, see [.NET 5+ and .NET Standard](../../standard/net-standard.md#net-5-and-net-standard).

.NET Standard 2.0 was the last version to support .NET Framework.

## Tools to assist porting

Instead of manually porting an application from .NET Framework to .NET, you can use different tools to help automate some aspects of the migration. Porting a complex project is, in itself, a complex process. The tools might help in that journey.

Even if you use a tool to help port your application, you should review the [Considerations when porting section](#considerations-when-porting) in this article.

### .NET Upgrade Assistant

The [.NET Upgrade Assistant](upgrade-assistant-overview.md) is a command-line tool that can be run on different kinds of .NET Framework apps. It's designed to assist with upgrading .NET Framework apps to .NET. After running the tool, **in most cases the app will require more effort to complete the migration**. The tool includes the installation of analyzers that can assist with completing the migration. This tool works on the following types of .NET Framework applications:

- Windows Forms
- WPF
- ASP.NET MVC
- Console
- Class libraries

This tool uses the other tools listed in this article, such as **try-convert**, and guides the migration process. For more information about the tool, see [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md).

### `try-convert`

The `try-convert` tool is a .NET global tool that can convert a project or entire solution to the .NET SDK, including moving desktop apps to .NET. However, this tool isn't recommended if your project has a complicated build process such as custom tasks, targets, or imports.

For more information, see the [`try-convert` GitHub repository](https://github.com/dotnet/try-convert).

### Platform compatibility analyzer

The [Platform compatibility analyzer](../../standard/analyzers/platform-compat-analyzer.md) analyzes whether or not you're using an API that throws a <xref:System.PlatformNotSupportedException> at run time. Although finding one of these APIs is unlikely if you're moving from .NET Framework 4.7.2 or higher, it's good to check. For more information about APIs that throw exceptions on .NET, see [APIs that always throw exceptions on .NET Core](../compatibility/unsupported-apis.md).

For more information, see [Platform compatibility analyzer](../../standard/analyzers/platform-compat-analyzer.md).

## Considerations when porting

When porting your application to .NET, consider the following suggestions in order:

✔️ CONSIDER using the [.NET Upgrade Assistant](upgrade-assistant-overview.md) to migrate your projects. Even though this tool is in preview, it automates most of the manual steps detailed in this article and gives you a great starting point for continuing your migration path.

✔️ CONSIDER examining your dependencies first. Your dependencies must target .NET, .NET Standard, or .NET Core.

✔️ DO migrate from a NuGet _packages.config_ file to [PackageReference](/nuget/consume-packages/package-references-in-project-files) settings in the project file. Use Visual Studio to [convert the _package.config_ file](/nuget/consume-packages/migrate-packages-config-to-package-reference#migration-steps).

✔️ CONSIDER upgrading to the latest project file format even if you can't yet port your app. .NET Framework projects use an outdated project format. Even though the latest project format, known as SDK-style projects, was created for .NET Core and beyond, the format also works with .NET Framework. Having your project file in the latest format gives you a good basis for porting your app in the future.

✔️ DO retarget your .NET Framework project to at least .NET Framework 4.7.2. This ensures the availability of the latest API alternatives for cases where .NET Standard doesn't support existing APIs.

✔️ CONSIDER targeting .NET 8, which is a long-term support (LTS) release.

✔️ DO target .NET 6+ for **Windows Forms and WPF** projects. .NET 6 and later versions contain many improvements for Desktop apps.

✔️ CONSIDER targeting .NET Standard 2.0 if you're migrating a library that might also be used with .NET Framework projects. You can also multitarget your library, targeting both .NET Framework and .NET Standard.

✔️ DO add reference to the [Microsoft.Windows.Compatibility NuGet package](https://www.nuget.org/packages/Microsoft.Windows.Compatibility) if, after migrating, you get errors of missing APIs. A large portion of the .NET Framework API surface is available to .NET via the NuGet package.

## See also

- [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md)
- [ASP.NET to ASP.NET Core migration](/aspnet/core/migration/proper-to-2x)
- [Migrate .NET Framework WPF apps to .NET](/dotnet/desktop/wpf/migration/convert-project-from-net-framework)
- [Migrate .NET Framework Windows Forms apps to .NET](/dotnet/desktop/winforms/migration/)
- [.NET 5 vs. .NET Framework for server apps](../../standard/choosing-core-framework-server.md)
