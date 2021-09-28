---
title: "Interoperability - C# Programming Guide"
description: Interoperability supports unmanaged code beside the code that runs under the common language runtime. Use these resources to understand interop options.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "COM interop"
  - "interoperability"
  - "platform invoke, accessing APIs with C#"
  - "C# language, interoperability"
ms.assetid: 238bb95a-e962-4026-bbd5-197055bdb8ee
---
# Interoperability (C# Programming Guide)

Interoperability enables you to preserve and take advantage of existing investments in unmanaged code. Code that runs under the control of the common language runtime (CLR) is called *managed code*, and code that runs outside the CLR is called *unmanaged code*. COM, COM+, C++ components, ActiveX components, and Microsoft Windows API are examples of unmanaged code.  
  
.NET enables interoperability with unmanaged code through platform invoke services, the <xref:System.Runtime.InteropServices> namespace, C++ interoperability, and COM interoperability (COM interop).  
  
## In This Section  

 [Interoperability Overview](./interoperability-overview.md)  
 Describes methods to interoperate between C# managed code and unmanaged code.  
  
 [How to access Office interop objects by using C# features](./how-to-access-office-onterop-objects.md)  
 Describes features that are introduced in Visual C# to facilitate Office programming.  
  
 [How to use indexed properties in COM interop programming](./how-to-use-indexed-properties-in-com-interop-rogramming.md)  
 Describes how to use indexed properties to access COM properties that have parameters.  
  
 [How to use platform invoke to play a WAV file](./how-to-use-platform-invoke-to-play-a-wave-file.md)  
 Describes how to use platform invoke services to play a .wav sound file on the Windows operating system.  
  
 [Walkthrough: Office Programming](./walkthrough-office-programming.md)  
 Shows how to create an Excel workbook and a Word document that contains a link to the workbook.  
  
 [Example COM Class](./example-com-class.md)  
 Demonstrates how to expose a C# class as a COM object.  
  
## C# Language Specification  

For more information, see [Basic concepts](~/_csharplang/spec/unsafe-code.md) in the [C# Language Specification](/dotnet/csharp/language-reference/language-specification/introduction). The language specification is the definitive source for C# syntax and usage.
  
## See also

- <xref:System.Runtime.InteropServices.Marshal.ReleaseComObject%2A?displayProperty=nameWithType>
- [C# Programming Guide](../index.md)
- [Interoperating with Unmanaged Code](../../../framework/interop/index.md)
- [Walkthrough: Office Programming](./walkthrough-office-programming.md)
