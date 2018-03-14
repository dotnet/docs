---
title: "FreeWin32ResBlob Method"
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
  - "IALink.FreeWin32ResBlob"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FreeWin32ResBlob"
helpviewer_keywords: 
  - "FreeWin32ResBlob method"
ms.assetid: d941102b-2679-4c49-b15e-c0fc9c53e11f
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# FreeWin32ResBlob Method
Releases the Win32 resource blob and associated resources.  
  
## Syntax  
  
```  
HRESULT FreeWin32ResBlob(  
    const void** ppResBlob  
) PURE;  
```  
  
#### Parameters  
 `ppResBlob`  
 The resource blob to be released. This method assigns the blob pointer to NULL.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See Also  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
