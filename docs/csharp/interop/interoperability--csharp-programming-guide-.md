---
title: "Interoperability (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "COM interop"
  - "interoperability"
  - "platform invoke, accessing APIs with C#"
  - "C# language, interoperability"
ms.assetid: 238bb95a-e962-4026-bbd5-197055bdb8ee
caps.latest.revision: 31
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Interoperability (C# Programming Guide)
Interoperability enables you to preserve and take advantage of existing investments in unmanaged code. Code that runs under the control of the common language runtime (CLR) is called *managed code*, and code that runs outside the CLR is called *unmanaged code*. COM, COM+, C++ components, ActiveX components, and Microsoft Win32 API are examples of unmanaged code.  
  
 The [!INCLUDE[dnprdnshort](../classes-and-structs/includes/dnprdnshort_md.md)] enables interoperability with unmanaged code through platform invoke services, the <xref:System.Runtime.InteropServices> namespace, C++ interoperability, and COM interoperability (COM interop).  
  
## In This Section  
 [Interoperability Overview](../interop/interoperability-overview--csharp-programming-guide-.md)  
 Describes methods to interoperate between C# managed code and unmanaged code.  
  
 [How to: Access Office Interop Objects by Using Visual C# Features](../interop/041b25c2-3512-4e0f-a4ea-ceb2999e4d5e.md)  
 Describes features that are introduced in Visual C# 2010 to facilitate Office programming.  
  
 [How to: Use Indexed Properties in COM Interop Programming](../interop/756bfc1e-7c28-4d4d-b114-ac9288c73882.md)  
 Describes how to use indexed properties to access COM properties that have parameters.  
  
 [How to: Use Platform Invoke to Play a Wave File](../interop/how-to--use-platform-invoke-to-play-a-wave-file--csharp-programming-guide-.md)  
 Describes how to use platform invoke services to play a .wav sound file on the Windows operating system.  
  
 [Walkthrough: Office Programming](../interop/walkthrough--office-programming--csharp-and-visual-basic-.md)  
 Shows how to create an Excel workbook and a Word document that contains a link to the workbook.  
  
 [Example COM Class](../interop/example-com-class--csharp-programming-guide-.md)  
 Demonstrates how to expose a C# class as a COM object.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 <xref:System.Runtime.InteropServices.Marshal.ReleaseComObject*?displayProperty=fullName>   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Interoperating with Unmanaged Code](../Topic/Interoperating%20with%20Unmanaged%20Code.md)   
 [Walkthrough: Office Programming](../interop/walkthrough--office-programming--csharp-and-visual-basic-.md)