---
title: "How to: Inspect assembly contents using MetadataLoadContext"
description: "Learn how to use MetadataLoadContext, which is an API that enables you to load .NET assemblies for inspection purposes."
author: MSDN-WhiteKnight
ms.date: 03/10/2020
ms.topic: how-to
---
# How to: Inspect assembly contents using MetadataLoadContext

The reflection API in .NET by default enables developers to inspect the contents of assemblies loaded into the main execution context. However, sometimes it isn't possible to load an assembly into the execution context, for example, because it was compiled for another platform or processor architecture, or it's a [reference assembly](reference-assemblies.md). The <xref:System.Reflection.MetadataLoadContext?displayProperty=fullName> API allows you to load and inspect such assemblies. Assemblies loaded into the <xref:System.Reflection.MetadataLoadContext> are treated only as metadata, that is, you can examine types in the assembly, but you can't execute any code contained in it. Unlike the main execution context, the <xref:System.Reflection.MetadataLoadContext> doesn't automatically load dependencies from the current directory; instead it uses the custom binding logic provided by the <xref:System.Reflection.MetadataAssemblyResolver> passed to it.

## Prerequisites

To use <xref:System.Reflection.MetadataLoadContext>, install the [System.Reflection.MetadataLoadContext](https://www.nuget.org/packages/System.Reflection.MetadataLoadContext) NuGet package. It is supported on any .NET Standard 2.0-compliant target framework, for example, .NET Core 2.0 or .NET Framework 4.6.1.

## Create MetadataAssemblyResolver for MetadataLoadContext

Creating the <xref:System.Reflection.MetadataLoadContext> requires providing the instance of the <xref:System.Reflection.MetadataAssemblyResolver>. The simplest way to provide one is to use the <xref:System.Reflection.PathAssemblyResolver>, which resolves assemblies from the given collection of assembly path strings. This collection, besides assemblies you want to inspect directly, should also include all needed dependencies. For example, to read the custom attribute located in an external assembly, you should include that assembly or an exception will be thrown. In most cases, you should include at least the *core assembly*, that is, the assembly containing built-in system types, such as <xref:System.Object?displayProperty=nameWithType>. The following code shows how to create the <xref:System.Reflection.PathAssemblyResolver> using the collection consisting of the inspected assembly and the current runtime's core assembly:

[!code-csharp[](snippets/inspect-contents-using-metadataloadcontext/MetadataLoadContextSnippets.cs#CoreAssembly)]

If you need access to all BCL types, you can include all runtime assemblies in the collection. The following code shows how to create the <xref:System.Reflection.PathAssemblyResolver> using the collection consisting of the inspected assembly and all assemblies of the current runtime:

[!code-csharp[](snippets/inspect-contents-using-metadataloadcontext/MetadataLoadContextSnippets.cs#RuntimeAssemblies)]

## Create MetadataLoadContext

To create the <xref:System.Reflection.MetadataLoadContext>, invoke its constructor <xref:System.Reflection.MetadataLoadContext.%23ctor%28System.Reflection.MetadataAssemblyResolver%2CSystem.String%29>, passing the previously created <xref:System.Reflection.MetadataAssemblyResolver> as the first parameter and the core assembly name as the second parameter. You can omit the core assembly name, in which case the constructor will attempt to use default names: "mscorlib", "System.Runtime", or "netstandard".

After you've created the context, you can load assemblies into it using methods such as <xref:System.Reflection.MetadataLoadContext.LoadFromAssemblyPath%2A>. You can use all reflection APIs on loaded assemblies except ones that involve code execution. The <xref:System.Reflection.MemberInfo.GetCustomAttributes%2A> method does involve the execution of constructors, so use the <xref:System.Reflection.MemberInfo.GetCustomAttributesData%2A> method instead when you need to examine custom attributes in the <xref:System.Reflection.MetadataLoadContext>.

The following code sample creates <xref:System.Reflection.MetadataLoadContext>, loads the assembly into it, and outputs assembly attributes into the console:

[!code-csharp[](snippets/inspect-contents-using-metadataloadcontext/MetadataLoadContextSnippets.cs#CreateContext)]

## Example

For a complete code example, see the [Inspect assembly contents using MetadataLoadContext sample](/samples/dotnet/samples/inspect-assembly-contents-using-metadataloadcontext/).
