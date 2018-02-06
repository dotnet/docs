---
title: "EmitAssemblyCustomAttribute Method"
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
  - "IALink.EmitAssemblyCustomAttribute"
  - "EmitAssemblyCustomAttribute"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EmitAssemblyCustomAttribute"
helpviewer_keywords: 
  - "EmitAssemblyCustomAttribute method"
ms.assetid: b72f5409-79af-4fa7-90a7-7630eec170f1
topic_type: 
  - "apiref"
caps.latest.revision: 5
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# EmitAssemblyCustomAttribute Method
Call to set assembly-level custom attributes.  
  
## Syntax  
  
```  
HRESULT EmitAssemblyCustomAttribute(  
    mdAssembly   AssemblyID,  
    mdToken      FileToken,  
    mdToken      tkType,  
    void const*  pCustomValue,  
    DWORD        cbCustomValue,  
    BOOL         bSecurity,  
    BOOL         bAllowMulti  
) PURE;  
```  
  
#### Parameters  
 `AssemblyID`  
 ID of the assembly.  
  
 `FileToken`  
 File that defiles the attribute. Can be NULL if `AssemblyID` does not indicate an unbound netmodule.  
  
 `tkType`  
 Type of the custom attribute.  
  
 `pCustomValue`  
 Custom value data.  
  
 `cbCustomValue`  
 Length of custom value data.  
  
 `bSecurity`  
 TRUE if the custom attribute is related to assembly signing.  
  
 `bAllowMulti`  
 TRUE if multiple attributes are to be emitted.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See Also  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
