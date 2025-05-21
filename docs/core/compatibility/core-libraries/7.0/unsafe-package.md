---
title: ".NET 7 breaking change: System.Runtime.CompilerServices.Unsafe NuGet package"
description: Learn about the .NET 7 breaking change in core .NET libraries where the 'Unsafe' type implementations have been unified and the System.Runtime.CompilerServices.Unsafe NuGet package is no longer produced.
ms.date: 10/12/2022
ms.topic: article
---
# System.Runtime.CompilerServices.Unsafe NuGet package

New versions of the [System.Runtime.CompilerServices.Unsafe NuGet package](https://www.nuget.org/packages/System.Runtime.CompilerServices.Unsafe/) will no longer be produced.

## Previous behavior

New versions of the [System.Runtime.CompilerServices.Unsafe NuGet package](https://www.nuget.org/packages/System.Runtime.CompilerServices.Unsafe/) were produced with each new .NET \[Core] version.

## New behavior

Starting in .NET 7, new functionality will ship as part of the shared framework for .NET.

## Version introduced

.NET 7 Preview 3

## Reason for change

There were previously two different implementations of the `Unsafe` type: one that was referenced and used inside the core libraries, and one that shipped as a separate NuGet package. This duplicated code and was also a maintenance burden for JIT and AOT, so we unified the implementations. The NuGet package no longer needs to be produced, as the unified implementation of `Unsafe` ships as part of the shared framework for .NET.

## Recommended action

You can continue to use older versions of the packages if you're targeting .NET 6 or earlier. But starting from .NET 7, you should remove the package dependency and instead use the API that comes as part of the shared framework.

## Affected APIs

- All of the APIs under <xref:System.Runtime.CompilerServices.Unsafe?displayProperty=fullName>.
