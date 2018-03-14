---
title: "Security and On-the-Fly Code Generation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "code security, on-the-fly code generation"
  - "on-the-fly code generation"
  - "security [.NET Framework], on-the-fly code generation"
  - "secure coding, on-the-fly code generation"
ms.assetid: 6d221724-bb21-4d76-90c3-0ee2a2e69be2
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Security and On-the-Fly Code Generation
Some libraries operate by generating code and running it to perform some operation for the caller. The basic problem is generating code on behalf of lesser-trust code and running it at a higher trust. The problem worsens when the caller can influence code generation, so you must ensure that only code you consider safe is generated.  
  
 You need to know exactly what code you are generating at all times. This means that you must have strict controls on any values that you get from a user, be they quote-enclosed strings (which should be escaped so they cannot include unexpected code elements), identifiers (which should be checked to verify that they are valid identifiers), or anything else. Identifiers can be dangerous because a compiled assembly can be modified so that its identifiers contain strange characters, which will probably break it (although this is rarely a security vulnerability).  
  
 It is recommended that you generate code with reflection emit, which often helps you avoid many of these problems.  
  
 When you compile the code, consider whether there is some way a malicious program could modify it. Is there a small window of time during which malicious code can change source code on disk before the compiler reads it or before your code loads the .dll file? If so, you must protect the directory containing these files, using an Access Control List in the file system, as appropriate.  
  
## See Also  
 [Secure Coding Guidelines](../../../docs/standard/security/secure-coding-guidelines.md)
