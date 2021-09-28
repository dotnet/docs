---
title: "Platform Invoke Examples"
description: See a platform invoke example that demonstrates how to define and call the MessageBox function in User32.dll.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "examples [.NET Framework], platform invoke"
  - "unmanaged functions"
  - "COM interop, platform invoke"
  - "platform invoke, examples"
  - "interoperation with unmanaged code, platform invoke"
  - "DLL functions"
ms.assetid: 15926806-f0b7-487e-93a6-4e9367ec689f
---
# Platform Invoke Examples

The following examples demonstrate how to define and call the **MessageBox** function in User32.dll, passing a simple string as an argument. In the examples, the <xref:System.Runtime.InteropServices.DllImportAttribute.CharSet?displayProperty=nameWithType> field is set to **Auto** to let the target platform determine the character width and string marshaling.  
  
 [!code-cpp[Conceptual.Interop.PInvoke#1](../../../samples/snippets/cpp/VS_Snippets_CLR/Conceptual.Interop.PInvoke/cpp/Example.cpp#1)]
 [!code-csharp[Conceptual.Interop.PInvoke#1](../../../samples/snippets/csharp/VS_Snippets_CLR/Conceptual.Interop.PInvoke/cs/Example1.cs#1)]
 [!code-vb[Conceptual.Interop.PInvoke#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Conceptual.Interop.PInvoke/vb/Example1.vb#1)]  
  
 For additional examples, see [Marshaling Data with Platform Invoke](marshaling-data-with-platform-invoke.md).  
  
## See also

- <xref:System.Runtime.InteropServices.DllImportAttribute>
- [Creating Prototypes in Managed Code](creating-prototypes-in-managed-code.md)
- [Specifying a Character Set](specifying-a-character-set.md)
