---
title: ".NET 7 breaking change: Collectible Assembly in non-collectible AssemblyLoadContext"
description: Learn about the .NET 7 breaking change in core .NET libraries where resolving a collectible Assembly in a non-collectible AssemblyLoadContext results in a FileLoadException.
ms.date: 05/10/2022
ms.topic: article
---
# Collectible Assembly in non-collectible AssemblyLoadContext

.NET incorrectly allowed garbage-collectible assemblies to resolve into a non-collectible <xref:System.Runtime.Loader.AssemblyLoadContext>. In some cases, this lead to runtime crashes or unexpected <xref:System.NullReferenceException> exceptions. This change prevents the incorrect behavior by throwing an exception when the <xref:System.Runtime.Loader.AssemblyLoadContext.Load(System.Reflection.AssemblyName)?displayProperty=nameWithType> or <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving?displayProperty=nameWithType> event returns a collectible <xref:System.Type.Assembly> and the <xref:System.Runtime.Loader.AssemblyLoadContext> is non-collectible.

## Previous behavior

Returning a collectible <xref:System.Type.Assembly> in the <xref:System.Runtime.Loader.AssemblyLoadContext.Load(System.Reflection.AssemblyName)?displayProperty=nameWithType> override or the <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving?displayProperty=nameWithType> event of a non-collectible <xref:System.Runtime.Loader.AssemblyLoadContext> doesn't cause any exceptions to be thrown.

## New behavior

Returning a collectible <xref:System.Type.Assembly> in the <xref:System.Runtime.Loader.AssemblyLoadContext.Load(System.Reflection.AssemblyName)?displayProperty=nameWithType> override or the <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving?displayProperty=nameWithType> event of a non-collectible <xref:System.Runtime.Loader.AssemblyLoadContext> throws a <xref:System.IO.FileLoadException?displayProperty=fullName> with a <xref:System.NotSupportedException> as the inner exception.

## Version introduced

.NET 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

This change fixes a bug. The collectible <xref:System.Type.Assembly> would be garbage-collected while the <xref:System.Runtime.Loader.AssemblyLoadContext> that has a reference to it is alive for the rest of the process lifetime. If the code running in that context references anything from that `Assembly` after it's collected, it would crash the runtime or result in a <xref:System.NullReferenceException>, <xref:System.AccessViolationException>, or other kinds of bad behavior.

## Recommended action

Don't return collectible assemblies in <xref:System.Runtime.Loader.AssemblyLoadContext.Load(System.Reflection.AssemblyName)?displayProperty=nameWithType> or the <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving?displayProperty=nameWithType> event of a non-collectible <xref:System.Runtime.Loader.AssemblyLoadContext>. A possible workaround is to change the `AssemblyLoadContext` to be collectible by passing `true` for the `isCollectible` parameter in its constructor, and then keep a reference to that `AssemblyLoadContext` forever to make sure it's never collected.

## Affected APIs

- <xref:System.Runtime.Loader.AssemblyLoadContext.Load(System.Reflection.AssemblyName)?displayProperty=fullName>
- <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving?displayProperty=fullName> event

## See also

- [Use collectible AssemblyLoadContext](../../../../standard/assembly/unloadability.md#use-collectible-assemblyloadcontext)
