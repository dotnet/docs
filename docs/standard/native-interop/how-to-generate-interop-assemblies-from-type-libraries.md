---
title: "Generate interop assemblies from type libraries"
description: Generate interop assemblies from type libraries. Use Type Library Importer (Tlbimp.exe) to convert coclasses and interfaces from a COM type library to metadata.
ms.date: 07/08/2026
ai-usage: ai-assisted
helpviewer_keywords:
  - "importing type library"
  - "interop assemblies, generating"
  - "Type Library Importer"
  - "type libraries"
  - "COM interop, importing type library"
ms.assetid: 4afd40c3-68f2-41c5-8ec1-4951bc148b9c
---
# Generate interop assemblies from type libraries

> [!NOTE]
> This article describes .NET Framework COM interop guidance that uses the legacy Type Library Importer (Tlbimp.exe). For modern .NET, use [COM source generation](comwrappers-source-generation.md) or the <xref:System.Runtime.InteropServices.ComWrappers> API. For more information, see [COM interop](cominterop.md).

The [Type Library Importer (Tlbimp.exe)](../../framework/tools/tlbimp-exe-type-library-importer.md) is a command-line tool that converts the coclasses and interfaces contained in a COM type library to metadata. This tool creates an interop assembly and namespace for the type information automatically. After the metadata of a class is available, managed clients can create instances of the COM type and call its methods, just as if it were a .NET instance. Tlbimp.exe converts an entire type library to metadata at once and cannot generate type information for a subset of the types defined in a type library.

## Generate an interop assembly from a type library

To generate an interop assembly from a type library, use the following command:

`tlbimp <type-library-file>`

Adding the `/out:` switch produces an interop assembly with an altered name, such as LOANLib.dll. Altering the interop assembly name can help distinguish it from the original COM DLL and prevent problems that can occur from having duplicate names.

## Example

 The following command produces the Loanlib.dll assembly in the `Loanlib` namespace.

```console
tlbimp Loanlib.tlb
```

 The following command produces an interop assembly with an altered name (LOANLib.dll).

```console
tlbimp LoanLib.tlb /out: LOANLib.dll
```

## See also

- [Import a type library as an assembly](importing-a-type-library-as-an-assembly.md)
- [Expose COM components to .NET](exposing-com-components.md)
