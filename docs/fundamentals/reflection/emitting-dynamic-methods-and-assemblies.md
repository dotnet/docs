---
title: "Emitting Dynamic Methods and Assemblies"
description: Emit dynamic methods and assemblies using the System.Reflection.Emit namespace, which allows a compiler or tool to emit metadata and CIL code at run time.
ms.date: 03/27/2024
helpviewer_keywords:
  - "reflection emit"
  - "dynamic assemblies"
  - "metadata, emit interfaces"
  - "reflection emit, overview"
  - "assemblies [.NET], emitting dynamic assemblies"
---
# Emit dynamic methods and assemblies

This section describes a set of managed types in the <xref:System.Reflection.Emit> namespace that allow a compiler or tool to emit metadata and common intermediate language (CIL) at run time and optionally generate a portable executable (PE) file on disk. Script engines and compilers are the primary users of this namespace. In this section, the functionality provided by the <xref:System.Reflection.Emit> namespace is referred to as *reflection emit*.

Reflection emit provides the following capabilities:

- Define lightweight global methods at run time, using the <xref:System.Reflection.Emit.DynamicMethod> class, and execute them using delegates.
- Define assemblies at run time and then run them and/or save them to disk.
- Define assemblies at run time, run them, and then unload them and allow garbage collection to reclaim their resources.
- Define modules in new assemblies at run time and then run and/or save them to disk.
- Define types in modules at run time, create instances of these types, and invoke their methods.
- Define symbolic information for defined modules that can be used by tools such as debuggers and code profilers.

In addition to the managed types in the <xref:System.Reflection.Emit> namespace, there are unmanaged metadata interfaces that are described in the [Metadata Interfaces](../../framework/unmanaged-api/metadata/metadata-interfaces.md) reference documentation. Managed reflection emit provides stronger semantic error checking and a higher level of abstraction of the metadata than the unmanaged metadata interfaces.

Another useful resource for working with metadata and CIL is the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata Definition and Semantics" and "Partition III: CIL Instruction Set". The documentation is available online at the [Ecma Web site](https://www.ecma-international.org/publications-and-standards/standards/ecma-335/).

## Reference

<xref:System.Reflection.Emit.OpCodes>\
Catalogs the CIL instruction codes you can use to build method bodies.

<xref:System.Reflection.Emit>\
Contains managed classes used to emit dynamic methods, assemblies, and types.

<xref:System.Type>\
Describes the <xref:System.Type> class, which represents types in managed reflection and reflection emit, and which is key to the use of these technologies.

<xref:System.Reflection>\
Contains managed classes used to explore metadata and managed code.
