---
title: Porting to .NET Core - Libraries
description: Learn how to port library projects from the .NET Framework to .NET Core.
keywords: .NET, .NET Core
author: cartermp
ms.author: mairaw
ms.date: 07/14/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: a0fd860d-d6b6-4659-b325-8a6e6f5fa4a1
ms.workload: 
  - dotnetcore
---

# Porting to .NET Core - Libraries

This article discusses porting library code to .NET Core so that it runs cross-platform.

## Prerequisites

This article assumes that you:

- Are using Visual Studio 2017 or later.
  - .NET Core isn't supported on earlier versions of Visual Studio
- Understand the [recommended porting process](index.md).
- Have resolved any issues with [third-party dependencies](third-party-deps.md).

You should also become familiar with the content of the following topics:

[.NET Standard](~/docs/standard/net-standard.md)   
This topic describes the formal specification of .NET APIs that are intended to be available on all .NET implementations.

[Packages, Metapackages and Frameworks](~/docs/core/packages.md)   
This article discusses how .NET Core defines and uses packages and how packages support code running on multiple .NET implementations.

[Developing Libraries with Cross Platform Tools](~/docs/core/tutorials/libraries.md)   
This topic explains how to write libraries for .NET using cross-platform CLI tools.

[Additions to the *csproj* format for .NET Core](~/docs/core/tools/csproj.md)   
This article outlines the changes that were added to the project file as part of the move to *csproj* and MSBuild.

[Porting to .NET Core - Analyzing your Third-Party Party Dependencies](~/docs/core/porting/third-party-deps.md)   
This topic discusses the portability of third-party dependencies and what to do when a NuGet package dependency doesn't run on .NET Core.

## .NET Framework technologies unavailable on .NET Core

Several technologies available to .NET Framework libraries aren't available for use with .NET Core, such as AppDomains, Remoting, Code Access Security (CAS), and Security Transparency. If your libraries rely on one or more of these technologies, consider the alternative approaches outlined below. For more information on API compatibility, the CoreFX team maintains a [List of behavioral changes/compat breaks and deprecated/legacy APIs](https://github.com/dotnet/corefx/wiki/ApiCompat) at GitHub.

Just because an API or technology isn't currently implemented doesn't imply it's intentionally unsupported. File an issue in the [dotnet/corefx repository issues](https://github.com/dotnet/corefx/issues) at GitHub to ask for specific APIs and technologies. [Porting requests in the issues](https://github.com/dotnet/corefx/labels/port-to-core) are marked with the `port-to-core` label.

### AppDomains

AppDomains isolate apps from one another. AppDomains require runtime support and are generally quite expensive. They're not implemented in .NET Core. We don't plan on adding this capability in future. For code isolation, we recommend separate processes or using containers as an alternative. For the dynamic loading of assemblies, we recommend the new <xref:System.Runtime.Loader.AssemblyLoadContext> class.

To make code migration from .NET Framework easier, we've exposed some of the <xref:System.AppDomain> API surface in .NET Core. Some of the API functions normally (for example, <xref:System.AppDomain.UnhandledException?displayProperty=nameWithType>), some members do nothing (for example, <xref:System.AppDomain.SetCachePath%2A>), and some of them throw <xref:System.PlatformNotSupportedException> (for example, <xref:System.AppDomain.CreateDomain%2A>). Check the types you use against the [`System.AppDomain` reference source](https://github.com/dotnet/corefx/blob/master/src/System.Runtime.Extensions/src/System/AppDomain.cs) in the [dotnet/corefx GitHub repository](https://github.com/dotnet/corefx) making sure to select the branch that matches your implemented version.

### Remoting

.NET Remoting was identified as a problematic architecture. It's used for cross-AppDomain communication, which is no longer supported. Also, Remoting requires runtime support, which is expensive to maintain. For these reasons, .NET Remoting isn't supported on .NET Core, and we don't plan on adding support for it in the future.

For communication across processes, consider inter-process communication (IPC) mechanisms as an alternative to Remoting, such as the <xref:System.IO.Pipes> or the <xref:System.IO.MemoryMappedFiles.MemoryMappedFile> class.

Across machines, use a network-based solution as an alternative. Preferably, use a low-overhead plain text protocol, such as HTTP. The [Kestrel web server](https://docs.microsoft.com/aspnet/core/fundamentals/servers/kestrel), the web server used by ASP.NET Core, is an option here. Also consider using <xref:System.Net.Sockets> for network-based, cross-machine scenarios. For more options, see [.NET Open Source Developer Projects: Messaging](https://github.com/Microsoft/dotnet/blob/master/dotnet-developer-projects.md#messaging).

### Code Access Security (CAS)

Sandboxing, which is relying on the runtime or the framework to constrain which resources a managed application or library uses or runs, [isn't supported on .NET Framework](~/docs/framework/misc/code-access-security.md) and therefore is also not supported on .NET Core. We believe that there are too many cases in the .NET Framework and runtime where an elevation of privileges occurs to continue treating CAS as a security boundary. In addition, CAS makes the implementation more complicated and often has correctness-performance implications for applications that don't intend to use it.

Use security boundaries provided by the operating system, such as virtualization, containers, or user accounts for running processes with the least set of privileges.

### Security Transparency

Similar to CAS, Security Transparency allows separating sandboxed code from security critical code in a declarative fashion but is [no longer supported as a security boundary](~/docs/framework/misc/security-transparent-code.md). This feature is heavily used by Silverlight. 

Use security boundaries provided by the operating system, such as virtualization, containers, or user accounts for running processes with the least set of privileges.

### global.json

The *global.json* file is an optional file that allows you to set the .NET Core tools version of a project. If you're using nightly builds of .NET Core and wish to specify a specific version of the SDK, specify the version with a *global.json* file. It typically resides in the current working directory or one of its parent directories. 

```json
{
  "sdk": {
    "version": "2.1.0-preview1-006491"
  }
}
```

## Converting a PCL project

You can convert the targets of a PCL project to .NET Standard by loading the library in Visual Studio 2017 and performing the following steps:

1. Right-click on the project file and select **Properties**.
1. Under **Library**, select **Target .NET Platform Standard**.

If your packages support NuGet 3.0, the project retargets to .NET Standard.

If your packages don't support NuGet 3.0, you receive a dialog from Visual Studio telling you to uninstall your current packages. If you receive this notice, perform the following steps:

1. Right-click the project, select **Manage NuGet Packages**.
1. Make a note of the project's packages.
1. Uninstall the packages one-by-one.
1. You might need to restart Visual Studio to complete the uninstall process. If so, a **Restart** button is presented to you in the **NuGet Package Manager** window.
1. When the project reloads, it targets .NET Standard. Add the packages you were required to uninstall.

## Retargeting your .NET Framework code to .NET Framework 4.6.2

If your code isn't targeting .NET Framework 4.6.2, we recommended that you retarget to .NET Framework 4.6.2. This ensures the availability of the latest API alternatives for cases where the .NET Standard doesn't support existing APIs.

For each of your projects in Visual Studio you wish to port, do the following:

1. Right-click on the project and select Properties.
1. In the **Target Framework** dropdown, select **.NET Framework 4.6.2**.
1. Recompile your projects.

Because your projects now target .NET Framework 4.6.2, use that version of the .NET Framework as your base for porting code.

## Determining the portability of your code

The next step is to run the API Portability Analyzer (ApiPort) to generate a portability report for analysis.

Make sure you understand the [API Portability Analyzer (ApiPort)](../../standard/analyzers/portability-analyzer.md) and how to generate portability reports for targeting .NET Core. How you do this likely varies based on your needs and personal tastes. What follows are a few different approaches. You may find yourself mixing steps of these approaches depending on how your code is structured.

### Dealing primarily with the compiler

This approach may be the best for small projects or projects which don't use many .NET Framework APIs. The approach is simple:

1. Optionally, run ApiPort on your project. If you run ApiPort, gain knowledge from the report on issues you'll need to address.
1. Copy all of your code over into a new .NET Core project.
1. While referring to the portability report (if generated), solve compiler errors until the project fully compiles.

Although this approach is unstructured, the code-focused approach often leads to resolving issues quickly and might be the best approach for smaller projects or libraries. A project that contains only data models might be an ideal candidate for this approach.

### Staying on the .NET Framework until portability issues are resolved

This approach might be the best if you prefer to have code that compiles during the entire process. The approach is as follows:

1. Run ApiPort on a project.
1. Address issues by using different APIs that are portable.
1. Take note of any areas where you're prevented from using a direct alternative.
1. Repeat the prior steps for all projects you're porting until you're confident each is ready to be copied over into a new .NET Core project.
1. Copy the code into a new .NET Core project.
1. Work out any issues where you noted that a direct alternative doesn't exist.

This careful approach is more structured than simply working out compiler errors, but it's still relatively code-focused and has the benefit of always having code that compiles. The way you resolve certain issues that couldn't be addressed by just using another API varies greatly. You may find that you need to develop a more comprehensive plan for certain projects, which is covered as the next approach.

### Developing a comprehensive plan of attack

This approach might be best for larger and more complex projects, where restructuring code or completely rewriting certain areas of code might be necessary to support .NET Core. The approach is as follows:

1. Run ApiPort on a project.
1. Understand where each non-portable type is used and how that affects overall portability.
   - Understand the nature of those types. Are they small in number but used frequently? Are they large in number but used infrequently? Is their use concentrated, or is it spread throughout your code?
   - Is it easy to isolate code that isn't portable so that you can deal with it more effectively?
   - Do you need to refactor your code?
   - For those types which aren't portable, are there alternative APIs that accomplish the same task? For example if you're using the <xref:System.Net.WebClient> class, you might be able to use the <xref:System.Net.Http.HttpClient> class instead.
   - Are there different portable APIs available to accomplish a task, even if it's not a drop-in replacement? For example if you're using <xref:System.Xml.Schema.XmlSchema> to parse XML but don't require XML schema discovery, you could use <xref:System.Xml.Linq> APIs and implement parsing yourself as opposed to relying on an API.
1. If you have assemblies that are difficult to port, is it worth leaving them on .NET Framework for now? Here are some things to consider:
   - You may have some functionality in your library that's incompatible with .NET Core because it relies too heavily on .NET Framework or Windows-specific functionality. Is it worth leaving that functionality behind for now and releasing a .NET Core version of your library with less features on a temporary basis until resources are available to port the features?
   - Would a refactor help?
1. Is it reasonable to write your own implementation of an unavailable .NET Framework API?
   You could consider copying, modifying, and using code from the [.NET Framework Reference Source](https://github.com/Microsoft/referencesource). The reference source code is licensed under the [MIT License](https://github.com/Microsoft/referencesource/blob/master/LICENSE.txt), so you have significant freedom to use the source as a basis for your own code. Just be sure to properly attribute Microsoft in your code.
1. Repeat this process as needed for different projects.
 
The analysis phase could take some time depending on the size of your codebase. Spending time in this phase to thoroughly understand the scope of changes needed and to develop a plan usually saves you time in the long run, particularly if you have a complex codebase.

Your plan could involve making significant changes to your codebase while still targeting .NET Framework 4.6.2, making this a more structured version of the previous approach. How you go about executing your plan is dependent on your codebase.

### Mixing approaches

It's likely that you'll mix the above approaches on a per-project basis. You should do what makes the most sense to you and for your codebase.

## Porting your tests

The best way to make sure everything works when you've ported your code is to test your code as you port it to .NET Core. To do this, you'll need to use a testing framework that builds and runs tests for .NET Core. Currently, you have three options:

- [xUnit](https://xunit.github.io/)
  * [Getting Started](http://xunit.github.io/docs/getting-started-dotnet-core.html)
  * [Tool to convert an MSTest project to xUnit](https://github.com/dotnet/codeformatter/tree/master/src/XUnitConverter)
- [NUnit](http://www.nunit.org/)
  * [Getting Started](https://github.com/nunit/docs/wiki/Installation)
  * [Blog post about migrating from MSTest to NUnit](http://www.florian-rappl.de/News/Page/275/convert-mstest-to-nunit)
- [MSTest](https://docs.microsoft.com/visualstudio/test/unit-test-basics)

## Recommended approach to porting

Ultimately, the porting effort depends heavily on how your .NET Framework code is structured. A good way to port your code is to begin with the *base* of your library, which are the foundational components of your code. This might be data models or some other foundational classes and methods that everything else uses directly or indirectly.

1. Port the test project that tests the layer of your library that you're currently porting.
1. Copy over the base of your library into a new .NET Core project and select the version of the .NET Standard you wish to support.
1. Make any changes needed to get the code to compile. Much of this may require adding NuGet package dependencies to your *csproj* file.
1. Run the tests and make any needed adjustments.
1. Pick the next layer of code to port over and repeat the prior steps.

If you start with the base of your library and move outward from the base and test each layer as needed, porting is a systematic process where problems are isolated to one layer of code at a time.
