---
title: "EmitAssembly Method"
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
  - "IALink2.EmitAssembly"
  - "EmitAssembly"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EmitAssembly"
helpviewer_keywords: 
  - "EmitAssembly method"
ms.assetid: 605ff39e-e5cc-4bff-8196-e8d68a9715b9
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# EmitAssembly Method
Creates the assembly. Call this method after all other files are closed except for the assembly file. Do not call this method when producing unbound modules.  
  
## Syntax  
  
```  
HRESULT EmitAssembly(  
    mdAssembly AssemblyID  
) PURE;  
```  
  
#### Parameters  
 `AssemblyID`  
 ID of the assembly.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See Also  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
