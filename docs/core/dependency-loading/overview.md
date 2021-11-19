---
title: Dependency loading - .NET
description: Overview of managed and unmanaged dependency loading in .NET 5+ and .NET Core
ms.date: 08/09/2019
author: sdmaclea
ms.topic: overview
---
# Dependency loading in .NET

Every .NET application has dependencies. Even the simple `hello world` app has dependencies on portions of the .NET class libraries.

Understanding .NET default assembly loading logic can help you troubleshoot typical deployment issues.

In some applications, dependencies are dynamically determined at run time. In these situations, it's critical to understand how managed assemblies and unmanaged dependencies are loaded.

## AssemblyLoadContext

The <xref:System.Runtime.Loader.AssemblyLoadContext> API is central to the .NET loading design. The [Understanding AssemblyLoadContext](understanding-assemblyloadcontext.md) article provides a conceptual overview of the design.

## Loading details

The loading algorithm details are covered briefly in several articles:

- [Managed assembly loading algorithm](loading-managed.md)
- [Satellite assembly loading algorithm](loading-resources.md)
- [Unmanaged (native) library loading algorithm](loading-unmanaged.md)
- [Default probing](default-probing.md)

## Create an app with plugins

The tutorial [Create a .NET Core application with plugins](../tutorials/creating-app-with-plugin-support.md) describes how to create a custom AssemblyLoadContext. It uses an <xref:System.Runtime.Loader.AssemblyDependencyResolver> to resolve the dependencies of the plugin. The tutorial correctly isolates the plugin's dependencies from the hosting application.

## Assembly unloadability

The [How to use and debug assembly unloadability in .NET Core](../../standard/assembly/unloadability.md) article is a step-by-step tutorial. It shows how to load a .NET Core application, execute it, and then unload it. The article also provides debugging tips.

## Collect detailed assembly loading information

The [Collect detailed assembly loading information](collect-details.md) article describes how to collect detailed information about managed assembly loading in the runtime. It uses the [dotnet-trace](../diagnostics/dotnet-trace.md) tool to capture assembly loader events in a trace of a running process.
