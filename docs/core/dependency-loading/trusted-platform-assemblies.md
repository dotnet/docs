---
title: Trusted Platform Assemblies - .NET Core
description: Overview of the concept of trusted platform assemblies used in .NET Core to populate the default AssemblyLoadContext.
ms.date: 08/09/2019
author: sdmaclea
ms.author: stmaclea
---
# Trusted Platform Assemblies

The .NET Core runtime has a concept of `Trusted Platform Assemblies` and a `Trusted Platform Assembly List`(TPA List).

## What is the TPA List?

When the runtime is started, a `TPA List` is populated. This list provides the information the runtime needs to locate an application's static dependencies.

The list is used by the <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> instance when loading managed assemblies, and unmanaged libraries.

## How is the TPA List populated?

There are two main scenarios for populating the `TPA List` depending on whether the `<myapp>.deps.json` file exists.

### With `<myapp>.deps.json`

When the `*.deps.json` file is present, it's parsed.  The parsing extracts from the file all the directories that contain each class of dependencies.

Additionally the `*.deps.json files for any referenced runtime and frameworks are similarly parsed.

### Without `<myapp>.deps.json`

The application's directory is assumed to contain all the dependencies.

Additionally the `*.deps.json files for any referenced runtime and frameworks are similarly parsed.

## How do I see the TPA List

The list is visible through the <xref:System.Environment?displayProperty=nameWithType>.

## How to I debug the TPA List construction

The .NET Core runtime host will output useful trace messages when certain environment variables are enabled:

`COREHOST_TRACE=1` : Enables tracing
`COREHOST_TRACEFILE=<path>` : Traces to a file path instead of the default `stderr`.
`COREHOST_TRACE_VERBOSITY` : Sets the verbosity from 1 lowest to 4 highest.
