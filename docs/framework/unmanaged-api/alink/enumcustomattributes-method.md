---
title: "EnumCustomAttributes Method"
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
  - "EnumCustomAttributes"
  - "IALink.EnumCustomAttributes"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EnumCustomAttributes"
helpviewer_keywords: 
  - "EnumCustomAttributes method"
ms.assetid: 08dff60c-f01b-4050-8865-ea3f95361c9f
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# EnumCustomAttributes Method
Retrieves assembly-level custom attributes.  
  
## Syntax  
  
```  
HRESULT EnumCustomAttributes(  
    HALINKENUM hEnum,  
    mdToken tkType,  
    mdCustomAttribute rCustomValues[],  
    ULONG cMax,  
    ULONG* pcCustomValues  
) PURE;  
```  
  
#### Parameters  
 `hEnum`  
 Handle of enumerator.  
  
 `tkType`  
 Type of attributes to be enumerated. Use `mdTokenNill` for all attributes.  
  
 `rCustomValues`  
 Receives custom attributes tokens.  
  
 `cMax`  
 Specifies size of `rCustomValues` array.  
  
 `pcCustomValues`  
 Optionally receives count of token values.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See Also  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
