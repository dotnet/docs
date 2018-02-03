---
title: "Interoperability (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "COM interop"
  - "interoperability"
  - "platform invoke, accessing APIs with C#"
  - "C# language, interoperability"
ms.assetid: 238bb95a-e962-4026-bbd5-197055bdb8ee
caps.latest.revision: 31
author: "BillWagner"
ms.author: "wiwagn"
---
# Interoperability (C# Programming Guide)
Interoperability enables you to preserve and take advantage of existing investments in unmanaged code. Code that runs under the control of the common language runtime (CLR) is called *managed code*, and code that runs outside the CLR is called *unmanaged code*. COM, COM+, C++ components, ActiveX components, and Microsoft Win32 API are examples of unmanaged code.  
  
 The [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] enables interoperability with unmanaged code through platform invoke services, the <xref:System.Runtime.InteropServices> namespace, C++ interoperability, and COM interoperability (COM interop).  
  
## In This Section  
 [Interoperability Overview](../../../csharp/programming-guide/interop/interoperability-overview.md)  
 Describes methods to interoperate between C# managed code and unmanaged code.  
  
 [How to: Access Office Interop Objects by Using Visual C# Features](../../../csharp/programming-guide/interop/how-to-access-office-onterop-objects.md)  
 Describes features that are introduced in Visual C# to facilitate Office programming.  
  
 [How to: Use Indexed Properties in COM Interop Programming](../../../csharp/programming-guide/interop/how-to-use-indexed-properties-in-com-interop-rogramming.md)  
 Describes how to use indexed properties to access COM properties that have parameters.  
  
 [How to: Use Platform Invoke to Play a Wave File](../../../csharp/programming-guide/interop/how-to-use-platform-invoke-to-play-a-wave-file.md)  
 Describes how to use platform invoke services to play a .wav sound file on the Windows operating system.  
  
 [Walkthrough: Office Programming](../../../csharp/programming-guide/interop/walkthrough-office-programming.md)  
 Shows how to create an Excel workbook and a Word document that contains a link to the workbook.  
  
 [Example COM Class](../../../csharp/programming-guide/interop/example-com-class.md)  
 Demonstrates how to expose a C# class as a COM object.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 <xref:System.Runtime.InteropServices.Marshal.ReleaseComObject%2A?displayProperty=nameWithType>  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Interoperating with Unmanaged Code](../../../../docs/framework/interop/index.md)  
 [Walkthrough: Office Programming](../../../csharp/programming-guide/interop/walkthrough-office-programming.md)
