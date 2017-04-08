---
title: "CloseAssembly Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "IALink.CloseAssembly"
  - "CloseAssembly"
apilocation: 
  - "alink.dll"
apitype: "COM"
f1_keywords: 
  - "CloseAssembly"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "CloseAssembly method"
ms.assetid: f66a43bc-a5c5-4190-acbe-63fd27640634
caps.latest.revision: 6
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# CloseAssembly Method
Finalizes assembly operations. Call this method before beginning a new assembly or unbound module.  
  
## Syntax  
  
```  
HRESULT CloseAssembly(  
    mdAssembly AssemblyID  
) PURE;  
```  
  
#### Parameters  
 `AssemblyID`  
 ID of the assembly.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h.  
  
## See Also  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)   
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)   
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)