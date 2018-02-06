---
title: "GetALinkMessageDll Function"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "GetALinkMessageDll"
api_location: 
  - "alink.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetALinkMessageDll"
helpviewer_keywords: 
  - "Alink API, GetALinkMessageDll function"
  - "GetALinkMessageDll function"
ms.assetid: 67985a22-88a2-4c54-8d99-4bcde9d6213e
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetALinkMessageDll Function
Finds and loads the message DLL. Returns 0 if the message DLL could not be located or loaded. The message DLL should be either in a subdirectory whose name is a language ID, or in the current directory.  
  
## Syntax  
  
```  
HINSTANCE WINAPI GetALinkMessageDll();  
```  
  
## Requirements  
 **Header:** alink.h  
  
 **Library**: alink.dll  
  
## See Also  
 [Al.exe (Assembly Linker)](../../../../docs/framework/tools/al-exe-assembly-linker.md)
