---
title: Dependency loading - .NET Core
description: Overview of managed and unmanaged dependency loading in .NET Core
ms.date: 08/09/2019
author: sdmaclea
ms.author: stmaclea
ms.topic: overview
#customer intent: As a .NET Core developer, I want to understand assembly loading so that I can design and debug assembly loading issues.
---
# Dependency loading in .NET Core

Every .NET Core application has dependencies. Even the simple `hello world` app has dependencies on portions of the .NET Core framework.

Understanding .NET Core default assembly loading logic can help understanding and debugging typical deployment issues.

In some applications dependencies are dynamically determined at runtime. In these situations, it's critical to understand how managed assemblies and unmanaged dependencies are loaded.

## [Understanding <xref:System.Runtime.Loader.AssemblyLoadContext>](understanding-assemblyloadcontext.md)

The <xref:System.Runtime.Loader.AssemblyLoadContext> API is central to the .NET Core loading design. This article provides a conceptual overview to the design.

## Custom loading details

The loading algorithm details are covered briefly in several articles:
- [Managed assembly loading algorithm](loading-managed.md)
- [Satellite assembly loading algorithm](loading-resources.md)
- [Unmanaged (native) library loading algorithm](loading-unmanaged.md)
- [Default probing](default-probing.md)

## [Create a .NET Core application with plugins](../tutorials/creating-app-with-plugin-support.md)

The tutorial on creating a .NET Core application with plugins describes how to create a custom AssemblyLoadContext. It uses an <xref:System.Runtime.Loader.AssemblyDependencyResolver> to resolve the dependencies of the plugin. The tutorial correctly isolates the plugin's dependencies from the hosting application.
