---
title: "Security and Public Read-only Array Fields"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "security [.NET Framework], public read-only array fields"
ms.assetid: 3df28dee-2a9f-40ff-9852-bfdbe59c27f3
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Security and Public Read-only Array Fields
Never use read-only public array fields from managed libraries to define the boundary behavior or security of your applications because read-only public array fields can be modified.  
  
## Remarks  
 Some .NET framework classes include read-only public fields that contain platform-specific boundary parameters.  For example, the <xref:System.IO.Path.InvalidPathChars> field is an array that describes the characters that are not allowed in a file path string.  Many similar fields are present throughout the .NET Framework.  
  
 The values of public read-only fields like <xref:System.IO.Path.InvalidPathChars> can be modified by your code or code that shares your code’s application domain.  You should not use read-only public array fields like this to define the boundary behavior of your applications.  If you do, malicious code can alter the boundary definitions and use your code in unexpected ways.  
  
 In version 2.0 and later of the .NET Framework, you should use methods that return a new array instead of using public array fields.  For example, instead of using the <xref:System.IO.Path.InvalidPathChars> field, you should use the <xref:System.IO.Path.GetInvalidPathChars%2A> method.  
  
 Note that the .NET Framework types do not use the public fields to define boundary types internally.  Instead, the .NET Framework uses separate private fields.  Changing the values of these public fields does not alter the behavior of .NET Framework types.  
  
## See Also  
 [Secure Coding Guidelines](../../../docs/standard/security/secure-coding-guidelines.md)
