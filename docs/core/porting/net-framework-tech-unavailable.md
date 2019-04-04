---
title: .NET Framework technologies unavailable on .NET Core
description: Learn about .NET Framework technologies that are unavailable on .NET Core
author: cartermp
ms.author: mairaw
ms.date: 12/07/2018
---

# .NET Framework technologies unavailable on .NET Core

Several technologies available to .NET Framework libraries aren't available for use with .NET Core, such as AppDomains, Remoting, Code Access Security (CAS), and Security Transparency. If your libraries rely on one or more of these technologies, consider the alternative approaches outlined below. For more information on API compatibility, the CoreFX team maintains a [List of behavioral changes/compat breaks and deprecated/legacy APIs](https://github.com/dotnet/corefx/wiki/ApiCompat) at GitHub.

Just because an API or technology isn't currently implemented doesn't imply it's intentionally unsupported. You should first search the GitHub repositories for .NET Core to see if a particular issue you encounter is by design, but if you cannot find such an indicator, please file an issue in the [dotnet/corefx repository issues](https://github.com/dotnet/corefx/issues) at GitHub to ask for specific APIs and technologies. [Porting requests in the issues](https://github.com/dotnet/corefx/labels/port-to-core) are marked with the `port-to-core` label.

## AppDomains

Application domains (AppDomains) isolate apps from one another. AppDomains require runtime support and are generally quite expensive. Creating additional app domains is not supported.. We don't plan on adding this capability in future. For code isolation, we recommend separate processes or using containers as an alternative. For the dynamic loading of assemblies, we recommend the new <xref:System.Runtime.Loader.AssemblyLoadContext> class.

To make code migration from .NET Framework easier, .NET Core exposes some of the <xref:System.AppDomain> API surface. Some of the APIs function normally (for example, <xref:System.AppDomain.UnhandledException?displayProperty=nameWithType>), some members do nothing (for example, <xref:System.AppDomain.SetCachePath%2A>), and some of them throw <xref:System.PlatformNotSupportedException> (for example, <xref:System.AppDomain.CreateDomain%2A>). Check the types you use against the [`System.AppDomain` reference source](https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/AppDomain.cs) in the [dotnet/corefx GitHub repository](https://github.com/dotnet/corefx), making sure to select the branch that matches your implemented version.

## Remoting

.NET Remoting was identified as a problematic architecture. It's used for cross-AppDomain communication, which is no longer supported. Also, Remoting requires runtime support, which is expensive to maintain. For these reasons, .NET Remoting isn't supported on .NET Core, and we don't plan on adding support for it in the future.

For communication across processes, consider inter-process communication (IPC) mechanisms as an alternative to Remoting, such as the <xref:System.IO.Pipes> or the <xref:System.IO.MemoryMappedFiles.MemoryMappedFile> class.

Across machines, use a network-based solution as an alternative. Preferably, use a low-overhead plain text protocol, such as HTTP. The [Kestrel web server](https://docs.microsoft.com/aspnet/core/fundamentals/servers/kestrel), the web server used by ASP.NET Core, is an option here. Also consider using <xref:System.Net.Sockets> for network-based, cross-machine scenarios. For more options, see [.NET Open Source Developer Projects: Messaging](https://github.com/Microsoft/dotnet/blob/master/dotnet-developer-projects.md#messaging).

## Code Access Security (CAS)

Sandboxing, which relies on the runtime or the framework to constrain which resources a managed application or library uses or runs, [isn't supported on .NET Framework](~/docs/framework/misc/code-access-security.md) and therefore is also not supported on .NET Core. There are too many cases in the .NET Framework and the runtime where an elevation of privileges occurs to continue treating CAS as a security boundary. In addition, CAS makes the implementation more complicated and often has correctness-performance implications for applications that don't intend to use it.

Use security boundaries provided by the operating system, such as virtualization, containers, or user accounts for running processes with the minimum set of privileges.

## Security Transparency

Similar to CAS, Security Transparency separates sandboxed code from security critical code in a declarative fashion but is [no longer supported as a security boundary](~/docs/framework/misc/security-transparent-code.md). This feature is heavily used by Silverlight. 

Use security boundaries provided by the operating system, such as virtualization, containers, or user accounts for running processes with the least set of privileges.

>[!div class="step-by-step"]
>[Next](third-party-deps.md)
