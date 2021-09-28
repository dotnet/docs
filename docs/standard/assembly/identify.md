---
title: "How to: Determine if a file is an assembly"
description: This article shows you how determine whether a file is a .NET assembly, both manually and programmatically.
ms.date: 07/24/2021
ms.topic: how-to
dev_langs: 
  - "csharp"
  - "vb"
---
# How to: Determine if a file is an assembly

A file is an assembly if and only if it is managed, and contains an assembly entry in its metadata. For more information on assemblies and metadata, see [Assembly manifest](manifest.md).  
  
## How to manually determine if a file is an assembly  
  
1. Start the [Ildasm.exe (IL Disassembler)](../../framework/tools/ildasm-exe-il-disassembler.md).  
  
2. Load the file you want to test.  
  
3. If **ILDASM** reports that the file is not a portable executable (PE) file, then it is not an assembly. For more information, see the topic [How to: View assembly contents](view-contents.md).  
  
## How to programmatically determine if a file is an assembly  

### Using the AssemblyName class

1. Call the <xref:System.Reflection.AssemblyName.GetAssemblyName%2A?displayProperty=nameWithType> method, passing the full file path and name of the file you are testing.  
  
2. If a <xref:System.BadImageFormatException> exception is thrown, the file is not an assembly.  

This example tests a DLL to see if it is an assembly.  

[!code-csharp[](snippets/identify/csharp/ExampleAssemblyName.cs#AssemblyName)]

[!code-vb[](snippets/identify/visual-basic/ExampleAssemblyName.vb#AssemblyName)]

The <xref:System.Reflection.AssemblyName.GetAssemblyName%2A> method loads the test file, and then releases it once the information is read.  

### Using the PEReader class

1. Install the [System.Reflection.Metadata](https://www.nuget.org/packages/System.Reflection.Metadata/) NuGet package.

2. Create a <xref:System.IO.FileStream?displayProperty=nameWithType> instance to read data from the file you're testing.

3. Create a <xref:System.Reflection.PortableExecutable.PEReader?displayProperty=nameWithType> instance, passing your file stream into the constructor.

4. Check the value of the <xref:System.Reflection.PortableExecutable.PEReader.HasMetadata> property. If the value is `false`, the file is not an assembly.

5. Call the <xref:System.Reflection.Metadata.PEReaderExtensions.GetMetadataReader%2A> method on the PE reader instance to create a metadata reader.

6. Check the value of the <xref:System.Reflection.Metadata.MetadataReader.IsAssembly> property. If the value is `true`, the file is an assembly.

Unlike the <xref:System.Reflection.AssemblyName.GetAssemblyName%2A> method, the <xref:System.Reflection.PortableExecutable.PEReader> class does not throw an exception on native Portable Executable (PE) files. This enables you to avoid the extra performance cost caused by exceptions when you need to check such files. You still need to handle exceptions in case the file does not exist or is not a PE file.

This example shows how to determine if a file is an assembly using the <xref:System.Reflection.PortableExecutable.PEReader> class.

[!code-csharp[](snippets/identify/csharp/ExamplePeReader.cs#PeReader)]

[!code-vb[](snippets/identify/visual-basic/ExamplePeReader.vb#PeReader)]

## See also

- <xref:System.Reflection.AssemblyName>
- [C# programming guide](../../csharp/programming-guide/index.md)
- [Programming concepts (Visual Basic)](../../visual-basic/programming-guide/concepts/index.md)
- [Assemblies in .NET](index.md)
