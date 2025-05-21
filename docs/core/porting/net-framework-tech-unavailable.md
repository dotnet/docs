---
title: .NET Framework technologies unavailable on .NET 6+
titleSuffix: ""
description: Learn about .NET Framework technologies that are unavailable on .NET 6 and later versions.
ms.date: 02/28/2023
ms.topic: article
---
# .NET Framework technologies unavailable on .NET

Several technologies available to .NET Framework libraries aren't available for use with .NET 6+, such as app domains, remoting, and code access security (CAS). If your libraries rely on one or more of the technologies listed on this page, consider the alternative approaches mentioned.

For more information on API compatibility, see [Breaking changes in .NET](../compatibility/breaking-changes.md).

## Application domains

Application domains (AppDomains) isolate apps from one another. AppDomains require runtime support and are resource-expensive. Creating more app domains isn't supported, and there are no plans to add this capability in the future. For code isolation, use separate processes or containers as an alternative. To dynamically load assemblies, use the <xref:System.Runtime.Loader.AssemblyLoadContext> class.

To make code migration from .NET Framework easier, .NET 6+ exposes some of the <xref:System.AppDomain> API surface. Some of the APIs function normally (for example, <xref:System.AppDomain.UnhandledException?displayProperty=nameWithType>), some members do nothing (for example, <xref:System.AppDomain.SetCachePath%2A>), and some of them throw <xref:System.PlatformNotSupportedException> (for example, <xref:System.AppDomain.CreateDomain%2A>). Check the types you use against the [`System.AppDomain` reference source](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/AppDomain.cs) in the [dotnet/runtime GitHub repository](https://github.com/dotnet/runtime). Make sure to select the branch that matches your implemented version.

## Remoting

.NET Remoting isn't supported on .NET 6+. .NET remoting was identified as a problematic architecture. It's used for communicating across application domains, which are no longer supported. Also, remoting requires runtime support, which is expensive to maintain.

For simple communication across processes, consider inter-process communication (IPC) mechanisms as an alternative to remoting, such as the <xref:System.IO.Pipes> class or the <xref:System.IO.MemoryMappedFiles.MemoryMappedFile> class. For more complex scenarios, the open-source [StreamJsonRpc](https://github.com/microsoft/vs-streamjsonrpc) project provides a cross-platform .NET Standard remoting framework that works on top of existing stream or pipe connections.

Across machines, use a network-based solution as an alternative. Preferably, use a low-overhead plain text protocol, such as HTTP. The [Kestrel web server](/aspnet/core/fundamentals/servers/kestrel), which is the web server used by ASP.NET Core, is an option here. Also, consider using <xref:System.Net.Sockets> for network-based, cross-machine scenarios. StreamJsonRpc, mentioned earlier, can be used for JSON or binary (via MessagePack) communication over web sockets.

For more messaging options, see [.NET Open Source Developer Projects: Messaging](https://github.com/Microsoft/dotnet/blob/main/dotnet-developer-projects.md#messaging).

Because remoting is not supported, calls to `BeginInvoke()` and `EndInvoke()` on delegate objects will throw `PlatformNotSupportedException`. For more information, see [Migrating Delegate BeginInvoke Calls For .NET Core](https://devblogs.microsoft.com/dotnet/migrating-delegate-begininvoke-calls-for-net-core/).

## Code access security (CAS)

Sandboxing, which relies on the runtime or the framework to constrain which resources a managed application or library uses or runs, [isn't supported on .NET Framework](/previous-versions/dotnet/framework/code-access-security/code-access-security) and therefore is also not supported on .NET 6+. CAS is no longer treated as a security boundary, because there are too many cases in .NET Framework and the runtime where an elevation of privileges occurs. Also, CAS makes the implementation more complicated and often has correctness-performance implications for applications that don't intend to use it.

Use security boundaries provided by the operating system, such as virtualization, containers, or user accounts, for running processes with the minimum set of privileges.

## Security transparency

Similar to CAS, security transparency separates sandboxed code from security critical code in a declarative fashion but is [no longer supported as a security boundary](/previous-versions/dotnet/framework/code-access-security/security-transparent-code). This feature is heavily used by Silverlight.

To run processes with the least set of privileges, use security boundaries provided by the operating system, such as virtualization, containers, or user accounts.

## System.EnterpriseServices

<xref:System.EnterpriseServices?displayProperty=fullName> (COM+) isn't supported by .NET 6+.

## Workflow Foundation

Windows Workflow Foundation (WF) is not supported in .NET 6+. For an alternative, see [CoreWF](https://github.com/UiPath/corewf).

> [!TIP]
> Windows Communication Foundation (WCF) server can be used in .NET 6+ by using the [CoreWCF NuGet packages](https://www.nuget.org/profiles/corewcf). For more information, see [CoreWCF 1.0 has been Released](https://devblogs.microsoft.com/dotnet/corewcf-v1-released/).

## Some reflection emit APIs are not supported

.NET 8 and earlier versions of .NET (Core) don't support saving assemblies that are generated by the <xref:System.Reflection.Emit?displayProperty=fullName> APIs, and the <xref:System.Reflection.Emit.AssemblyBuilder.Save%2A?displayProperty=nameWithType> method isn't available. In addition, the following fields of the <xref:System.Reflection.Emit.AssemblyBuilderAccess> enumeration aren't available:

- <xref:System.Reflection.Emit.AssemblyBuilderAccess.ReflectionOnly>
- <xref:System.Reflection.Emit.AssemblyBuilderAccess.RunAndSave>
- <xref:System.Reflection.Emit.AssemblyBuilderAccess.Save>

In .NET 9, a `PersistedAssemblyBuilder` was implemented and the <xref:System.Reflection.Emit.AssemblyBuilder.Save%2A?displayProperty=nameWithType> method was added back to the reflection emit library. To learn more about how to use this API, see [System.Reflection.Emit.PersistedAssemblyBuilder class](../../fundamentals/runtime-libraries/system-reflection-emit-persistedassemblybuilder.md).

For more information about the different AssemblyBuilder implementations in .NET, see [System.Reflection.Emit.AssemblyBuilder class](../../fundamentals/runtime-libraries/system-reflection-emit-assemblybuilder.md).

## Loading multi-module assemblies

Assemblies that consist of multiple modules (`OutputType=Module` in MSBuild) are not supported in .NET 6+.

As an alternative, consider merging the individual modules into a single assembly file.

## XSLT script blocks

XSLT [script blocks](../../standard/data/xml/script-blocks-using-msxsl-script.md) are supported only in .NET Framework. They are not supported on .NET 6 or later.

## See also

- [Overview of porting from .NET Framework to .NET](index.md)
