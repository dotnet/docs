---
title: "CreateALink Function"
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
  - "CreateALink"
api_location: 
  - "alink.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CreateALink"
helpviewer_keywords: 
  - "CreateALink function"
  - "Alink API, CreateALink function"
ms.assetid: fc73bcb9-6af6-44d8-bc39-2f4400325dae
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CreateALink Function
Creates an instance of the Assembly Linker and sets a pointer to the specified interface.  
  
## Syntax  
  
```  
HRESULT CreateALink (  
   REFIID riid,  
   IUnknown **ppInterface  
);  
```  
  
#### Parameters  
  
|Parameter|Description|  
|---------------|-----------------|  
|`riid`|The physical name of one of the Assembly Linker interfaces.|  
|`ppInterface`|The location that on successful completion contains a pointer to the `riid` interface.|  
  
## Requirements  
 **Library**: alink.dll  
  
## See Also  
 [Al.exe (Assembly Linker)](../../../../docs/framework/tools/al-exe-assembly-linker.md)
