---
title: .NET assembly file format
description: Learn about the .NET assembly file format, which is used to describe and contain .NET apps and libraries.
author: richlander
ms.date: 08/20/2019
ms.assetid: 6520323e-ff28-4c8a-ba80-e64a413199e6
---

# .NET assembly file format

.NET defines a binary file format, *assembly*, that is used to fully describe and contain .NET programs. Assemblies are used for the programs themselves as well as any dependent libraries. A .NET program can be executed as one or more assemblies, with no other required artifacts, beyond the appropriate .NET implementation. Native dependencies, including operating system APIs, are a separate concern and are not contained within the .NET assembly format, although they are sometimes described with this format (for example, WinRT).

> Each CLI component carries the metadata for declarations, implementations, and references specific to that component. Therefore, the component-specific metadata is referred to as component metadata, and the resulting component is said to be self-describing – from ECMA 335 I.9.1, Components and assemblies.

The format is fully specified and standardized as [ECMA 335](https://www.ecma-international.org/publications-and-standards/standards/ecma-335/). All .NET compilers and runtimes use this format. The presence of a documented and infrequently updated binary format has been a major benefit (arguably a requirement) for interoperability. The format was last updated in a substantive way in 2005 (.NET Framework 2.0) to accommodate generics and processor architecture.

The format is CPU- and OS-agnostic. It has been used as part of .NET implementations that target many chips and CPUs. While the format itself has Windows heritage, it is implementable on any operating system. Its arguably most significant choice for OS interoperability is that most values are stored in little-endian format. It doesn’t have a specific affinity to machine pointer size (for example, 32-bit, 64-bit).

The .NET assembly format is also very descriptive about the structure of a given program or library. It describes the internal components of an assembly, specifically assembly references and types defined and their internal structure. Tools or APIs can read and process this information for display or to make programmatic decisions.

## Format

The .NET binary format is based on the Windows [PE file](https://en.wikipedia.org/wiki/Portable_Executable) format. In fact, .NET class libraries are conformant Windows PEs, and appear on first glance to be Windows dynamic link libraries (DLLs) or application executables (EXEs). This is a very useful characteristic on Windows, where they can masquerade as native executable binaries and get some of the same treatment (for example, OS load, PE tools).

![Assembly headers](../media/assembly-format/assembly-headers.png)

Assembly Headers from ECMA 335 II.25.1, Structure of the runtime file format.

## Process the assemblies

It is possible to write tools or APIs to process assemblies. Assembly information enables making programmatic decisions at run time, re-writing assemblies, providing API IntelliSense in an editor and generating documentation. <xref:System.Reflection?displayProperty=nameWithType>, <xref:System.Reflection.MetadataLoadContext?displayProperty=nameWithType>, and [Mono.Cecil](https://www.mono-project.com/docs/tools+libraries/libraries/Mono.Cecil/) are good examples of tools that are frequently used for this purpose.
