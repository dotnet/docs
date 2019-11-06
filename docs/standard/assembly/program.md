---
title: "Program with assemblies"
ms.date: "08/20/2019"
helpviewer_keywords:
  - "assemblies [.NET Framework], programming"
  - "programming assemblies"
ms.assetid: 25918b15-701d-42c7-95fc-c290d08648d6
---
# Program with assemblies

Assemblies are the building blocks of the .NET Framework. They form the fundamental unit of deployment, version control, reuse, activation scoping, and security permissions. An assembly provides the common language runtime with the information it needs to be aware of type implementations. It is a collection of types and resources that are built to work together and form a logical unit of functionality. To the runtime, a type does not exist outside the context of an assembly.

This section describes how to create modules, create assemblies from modules, create a key pair and sign an assembly with a strong name, and install an assembly into the global assembly cache. In addition, this section describes how to use the [MSIL Disassembler (Ildasm.exe)](../../framework/tools/ildasm-exe-il-disassembler.md)\ to view assembly manifest information.

> [!NOTE]
> Starting with .NET Framework version 2.0, the runtime will not load an assembly that was compiled with a version of the .NET Framework that has a higher version number than the currently loaded runtime. This applies to the combination of the major and minor components of the version number.

## In this section

[Create assemblies](create.md)\
Provides an overview of single-file and multi-file assemblies.

[Assembly names](names.md)

[How to: Determine an assembly's fully qualified name](find-fully-qualified-name.md)

[Assembly location](location.md)\
Provides an overview of where to locate assemblies.

[Set assembly attributes](set-attributes.md)\
Describes assembly attributes and how to set them.

[Create and use strong-named assemblies](create-use-strong-named.md)\
Describes how and why you sign an assembly with a strong name.

[Delay-sign an assembly](delay-sign.md)

[How to: View assembly contents](view-contents.md)\
Describes how to use the MSIL Disassembler (Ildasm.exe) to view assembly contents.

[Type forwarding in the common language runtime](type-forwarding.md)\
Describes how to use type forwarding to move a type into a different assembly without breaking existing applications.

[Friend assemblies](friend.md)

[Determine if a file is an assembly](identify.md)

[Load and unload assemblies](load-unload.md)

[Walkthrough: Embed types from managed assemblies in Visual Studio](embed-types-visual-studio.md)

## Reference

<xref:System.Reflection.Assembly>\
The .NET class that represents an assembly.

## Related sections

[How to: Obtain type and member information from an assembly](../../framework/reflection-and-codedom/get-type-member-information.md)\
Describes how to programmatically obtain type and other information from an assembly.

[How the runtime locates assemblies](../../framework/deployment/how-the-runtime-locates-assemblies.md)\
Describes how the runtime determines which assembly to use to fulfill a binding request.

[Reflection](../../framework/reflection-and-codedom/reflection.md)\
Describes how to use the **Reflection** class to obtain information about an assembly.
