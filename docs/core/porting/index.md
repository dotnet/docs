---
title: Port from .NET Framework to .NET 5
description: Understand the porting process and discover tools you may find helpful when porting a .NET Framework project to .NET 5 (and .NET Core 3.1).
author: adegeo
ms.date: 05/04/2021
no-loc: ["package.config", PackageReference]
---
# Overview of porting from .NET Framework to .NET

This article provides an overview of what you should consider when porting your code from .NET Framework to .NET (formerly named .NET Core). Porting to .NET from .NET Framework for many projects is relatively straightforward. The complexity of your projects dictates how much work you'll do after the initial migration of the project files.

Projects where the app-model is available in .NET (such as libraries, console apps, and desktop apps) usually require little change. Projects that require a new app model, such as moving to ASP.NET Core from ASP.NET, require more work. Many patterns from the old app model have equivalents that can be used during the conversion.

## Unavailable technologies

There are a few technologies in .NET Framework that don't exist in .NET:

- [Application domains](net-framework-tech-unavailable.md#application-domains)

  Creating additional application domains isn't supported. For code isolation, use separate processes or containers as an alternative.

- [Remoting](net-framework-tech-unavailable.md#remoting)

  Remoting is used for communicating across application domains, which are no longer supported. For simple communication across processes, consider inter-process communication (IPC) mechanisms as an alternative to remoting, such as the <xref:System.IO.Pipes> class or the <xref:System.IO.MemoryMappedFiles.MemoryMappedFile> class. For more complex scenarios, consider frameworks such as [StreamJsonRpc](https://github.com/microsoft/vs-streamjsonrpc) or [ASP.NET Core](/aspnet/core) (either using [gRPC](/aspnet/core/grpc) or [RESTful Web API services](/aspnet/core/web-api)).

- [Code access security (CAS)](net-framework-tech-unavailable.md#code-access-security-cas)

  CAS was a sandboxing technique supported by .NET Framework but deprecated in .NET Framework 4.0. It was replaced by Security Transparency and it's not supported in .NET. Instead, use security boundaries provided by the operating system, such as virtualization, containers, or user accounts.

- [Security transparency](net-framework-tech-unavailable.md#security-transparency)

  Similar to CAS, this sandboxing technique is no longer recommended for .NET Framework applications and it's not supported in .NET. Instead, use security boundaries provided by the operating system, such as virtualization, containers, or user accounts.
  
- <xref:System.EnterpriseServices?displayProperty=fullName>

  <xref:System.EnterpriseServices?displayProperty=fullName> (COM+) isn't supported in .NET.

- Windows Workflow Foundation (WF) and Windows Communication Foundation (WCF)

  WF and WCF aren't supported in .NET 5+ (including .NET Core). For alternatives, see [CoreWF](https://github.com/UiPath/corewf) and [CoreWCF](https://github.com/CoreWCF/CoreWCF).

For more information about these unsupported technologies, see [.NET Framework technologies unavailable on .NET Core and .NET 5+](net-framework-tech-unavailable.md).

## Windows desktop technologies

Many applications created for .NET Framework use a desktop technology such as Windows Forms or Windows Presentation Foundation (WPF). Both Windows Forms and WPF have been ported to .NET, but these remain Windows-only technologies.

Consider the following dependencies before you migrate a Windows Forms or WPF application:

01. Project files for .NET use a different format than .NET Framework.
01. Your project may use an API that isn't available in .NET.
01. 3rd-party controls and libraries may not have been ported to .NET and remain only available to .NET Framework.
01. Your project uses a [technology that is no longer available](net-framework-tech-unavailable.md) in .NET.

.NET uses the open-source versions of Windows Forms and WPF and includes enhancements over .NET Framework.

For tutorials on migrating your desktop application to .NET 5, see one of the following articles:

- [Migrate .NET Framework WPF apps to .NET](/dotnet/desktop/wpf/migration/convert-project-from-net-framework?view=netdesktop-6.0&preserve-view=true)
- [Migrate .NET Framework Windows Forms apps to .NET](/dotnet/desktop/winforms/migration/?view=netdesktop-6.0&preserve-view=true)

## Windows-specific APIs

Applications can still P/Invoke native libraries on platforms supported by .NET. This technology isn't limited to Windows. However, if the library you're referencing is Windows-specific, such as a _user32.dll_ or _kernel32.dll_, then the code only works on Windows. For each platform you want your app to run on, you'll have to either find platform-specific versions, or make your code generic enough to run on all platforms.

When porting an application from .NET Framework to .NET, your application probably used a library provided distributed with the .NET Framework. Many APIs that were available in .NET Framework weren't ported to .NET because they relied on Windows-specific technology, such as the Windows Registry or the GDI+ drawing model.

The **Windows Compatibility Pack** provides a large portion of the .NET Framework API surface to .NET and is provided via the [Microsoft.Windows.Compatibility NuGet package](https://www.nuget.org/packages/Microsoft.Windows.Compatibility).

For more information, see [Use the Windows Compatibility Pack to port code to .NET](windows-compat-pack.md).

## .NET Framework compatibility mode

The .NET Framework compatibility mode was introduced in .NET Standard 2.0. This compatibility mode allows .NET Standard and .NET 5+ (and .NET Core 3.1) projects to reference .NET Framework libraries on Windows-only. Referencing .NET Framework libraries doesn't work for all projects, such as if the library uses Windows Presentation Foundation (WPF) APIs, but it does unblock many porting scenarios. For more information, see the [Analyze your dependencies to port code from .NET Framework to .NET](third-party-deps.md#net-framework-compatibility-mode).

## Cross-platform

.NET (formerly known as .NET Core) is designed to be cross-platform. If your code doesn't depend on Windows-specific technologies, it may run on other platforms such as macOS, Linux, and Android. This includes project types like:

- Libraries
- Console-based tools
- Automation
- ASP.NET sites

.NET Framework is a Windows-only component. When your code uses Windows-specific technologies or APIs, such as Windows Forms and Windows Presentation Foundation (WPF), the code can still run on .NET but it won't run on other operating systems.

It's possible that your library or console-based application can be used cross-platform without changing much. When porting to .NET, you may want to take this into consideration and test your application on other platforms.

## The future of .NET Standard

[.NET Standard](https://github.com/dotnet/standard) is a formal specification of .NET APIs that are available on multiple .NET implementations. The motivation behind .NET Standard was to establish greater uniformity in the .NET ecosystem. Starting with .NET 5, a different approach to establishing uniformity has been adopted, and this new approach eliminates the need for .NET Standard in many scenarios. For more information, see [.NET 5 and .NET Standard](../../standard/net-standard.md#net-5-and-net-standard).

.NET Standard 2.0 was the last version to support .NET Framework.

## Tools to assist porting

Instead of manually porting an application from .NET Framework to .NET, you can use different tools to help automate some aspects of the migration. Porting a complex project is, in itself, a complex process. These tools may help in that journey.

Even if you use a tool to help port your application, you should review the [Considerations when porting section](#considerations-when-porting) in this article.

### .NET Upgrade Assistant

The [.NET Upgrade Assistant](upgrade-assistant-overview.md) is a command-line tool that can be run on different kinds of .NET Framework apps. It's designed to assist with upgrading .NET Framework apps to .NET 5. After running the tool, **in most cases the app will require more effort to complete the migration**. The tool includes the installation of analyzers that can assist with completing the migration. This tool works on the following types of .NET Framework applications:

- Windows Forms
- WPF
- ASP.NET MVC
- Console
- Class libraries

This tool uses the other tools listed in this article and guides the migration process. For more information about the tool, see [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md).

### try-convert

The try-convert tool is a .NET global tool that can convert a project or entire solution to the .NET SDK, including moving desktop apps to .NET 5. However, this tool isn't recommended if your project has a complicated build process such as custom tasks, targets, or imports.

For more information, see the [try-convert GitHub repository](https://github.com/dotnet/try-convert).

### .NET Portability Analyzer

The .NET Portability Analyzer is a tool that analyzes assemblies and provides a detailed report on .NET APIs that are missing for the applications or libraries to be portable on your specified targeted .NET platforms.

To use the .NET Portability Analyzer in Visual Studio, install the [extension from the marketplace](https://marketplace.visualstudio.com/items?itemName=ConnieYau.NETPortabilityAnalyzer).

For more information, see [The .NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md).

### Platform compatibility analyzer

The [Platform compatibility analyzer](../../standard/analyzers/platform-compat-analyzer.md) analyzes whether or not you're using an API that will throw a <xref:System.PlatformNotSupportedException> at run time. Although this isn't common if you're moving from .NET Framework 4.7.2 or higher, it's good to check. For more information about APIs that throw exceptions on .NET, see [APIs that always throw exceptions on .NET Core](../compatibility/unsupported-apis.md).

For more information, see [Platform compatibility analyzer](../../standard/analyzers/platform-compat-analyzer.md).

## Considerations when porting

When porting your application to .NET, consider the following suggestions in order.

✔️ CONSIDER using the [.NET Upgrade Assistant](upgrade-assistant-overview.md) to migrate your projects. Even though this tool is in preview, it automates most of the manual steps detailed in this article and gives you a great starting point for continuing your migration path.

✔️ CONSIDER examining your dependencies first. Your dependencies must target .NET 5, .NET Standard, or .NET Core.

✔️ DO migrate from a NuGet _packages.config_ file to [PackageReference](/nuget/consume-packages/package-references-in-project-files) settings in the project file. Use Visual Studio to [convert the _package.config_ file](/nuget/consume-packages/migrate-packages-config-to-package-reference#migration-steps).

✔️ CONSIDER upgrading to the latest project file format even if you can't yet port your app. .NET Framework projects use an outdated project format. Even though the latest project format, known as SDK-style projects, was created for .NET Core and beyond, they work with .NET Framework. Having your project file in the latest format gives you a good basis for porting your app in the future.

✔️ DO retarget your .NET Framework project to at least .NET Framework 4.7.2. This ensures the availability of the latest API alternatives for cases where .NET Standard doesn't support existing APIs.

✔️ CONSIDER targeting .NET 5 instead of .NET Core 3.1. While .NET Core 3.1 is under long-term support (LTS), .NET 5 is the latest and .NET 6 will be LTS when released.

✔️ DO target .NET 5 for **Windows Forms and WPF** projects. .NET 5 contains many improvements for Desktop apps.

✔️ CONSIDER targeting .NET Standard 2.0 if you're migrating a library that may also be used with .NET Framework projects. You can also multitarget your library, targeting both .NET Framework and .NET Standard.

✔️ DO add reference to the [Microsoft.Windows.Compatibility NuGet package](https://www.nuget.org/packages/Microsoft.Windows.Compatibility) if, after migrating, you get errors of missing APIs. A large portion of the .NET Framework API surface is available to .NET via the NuGet package.

## See also

- [Overview of the .NET Upgrade Assistant](upgrade-assistant-overview.md)
- [ASP.NET to ASP.NET Core migration](/aspnet/core/migration/proper-to-2x)
- [Migrate .NET Framework WPF apps to .NET](/dotnet/desktop/wpf/migration/convert-project-from-net-framework?view=netdesktop-6.0&preserve-view=true)
- [Migrate .NET Framework Windows Forms apps to .NET](/dotnet/desktop/winforms/migration/?view=netdesktop-6.0&preserve-view=true)
- [.NET 5 vs. .NET Framework for server apps](../../standard/choosing-core-framework-server.md)
