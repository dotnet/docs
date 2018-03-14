---
title: "Securing State Data"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "security [.NET Framework], state data"
  - "code security, state data"
  - "secure coding, state data"
  - "state data security"
ms.assetid: 12671309-2877-43fe-a3df-6863507e712d
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Securing State Data
Applications that handle sensitive data or make any kind of security decisions need to keep that data under their own control and cannot allow other potentially malicious code to access the data directly. The best way to protect data in memory is to declare the data as private or internal (with scope limited to the same assembly) variables. However, even this data is subject to access you should be aware of:  
  
-   Using reflection mechanisms, highly trusted code that can reference your object can get and set private members.  
  
-   Using serialization, highly trusted code can effectively get and set private members if it can access the corresponding data in the serialized form of the object.  
  
-   Under debugging, this data can be read.  
  
 Make sure none of your own methods or properties exposes these values unintentionally.  
  
## See Also  
 [Secure Coding Guidelines](../../../docs/standard/security/secure-coding-guidelines.md)
