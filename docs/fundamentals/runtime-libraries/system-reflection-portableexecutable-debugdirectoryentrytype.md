---
title: System.Reflection.PortableExecutable.DebugDirectoryEntryType enum
description: Learn about the System.Reflection.PortableExecutable.DebugDirectoryEntryType enum.
ms.date: 12/31/2023
ms.topic: article
---
# System.Reflection.PortableExecutable.DebugDirectoryEntryType enum

[!INCLUDE [context](includes/context.md)]

The <xref:System.Reflection.PortableExecutable.DebugDirectoryEntryType> enum describes the format of the debugging information of a <xref:System.Reflection.PortableExecutable.DebugDirectoryEntry>.

See the following for the specifications related to individual enumeration members:

|Member|Specification|
|---|---|
|`CodeView`|[CodeView Debug Directory Entry (type 2)](https://github.com/dotnet/runtime/blob/main/docs/design/specs/PE-COFF.md#codeview-debug-directory-entry-type-2)|
|`EmbeddedPortablePdb`|[Embedded Portable PDB Debug Directory Entry (type 17)](https://github.com/dotnet/runtime/blob/main/docs/design/specs/PE-COFF.md#embedded-portable-pdb-debug-directory-entry-type-17)|
|`PdbChecksum`|[PDB Checksum Debug Directory Entry (type 19)](https://github.com/dotnet/runtime/blob/main/docs/design/specs/PE-COFF.md#pdb-checksum-debug-directory-entry-type-19)|
|`Reproducible`|See [Deterministic Debug Directory Entry (type 16)](https://github.com/dotnet/runtime/blob/main/docs/design/specs/PE-COFF.md#deterministic-debug-directory-entry-type-16)|

## DebugDirectoryEntryType.Reproducible

The tool that produced the deterministic PE/COFF file guarantees that the entire content of the file is based solely on documented inputs given to the tool (such as source files, resource files, compiler options, etc.) rather than ambient environment variables (such as the current time, the operating system, the bitness of the process running the tool, etc.).

The value of the `TimeDateStamp` field in the COFF File Header of a deterministic PE/COFF file does not indicate the date and time when the file was produced and should not be interpreted that way. Instead, the value of the field is derived from a hash of the file content. The algorithm to calculate this value is an implementation detail of the tool that produced the file.

The debug directory entry of type <xref:System.Reflection.PortableExecutable.DebugDirectoryEntryType.Reproducible> must have all fields except for <xref:System.Reflection.PortableExecutable.DebugDirectoryEntry.Type?displayProperty=nameWithType> zeroed.
