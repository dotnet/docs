---
title: "_EFN_GetManagedObjectName Function"
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
  - "_EFN_GetManagedObjectName"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "_EFN_GetManagedObjectName"
helpviewer_keywords: 
  - "_EFN_GetManagedObjectName function [.NET Framework debugging]"
ms.assetid: 6e7c6bee-7ced-495f-bf6c-2a5f0c716f7e
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# _EFN_GetManagedObjectName Function
Gets the name of a type using the provided managed object pointer.  
  
## Syntax  
  
```  
HRESULT _EFN_GetManagedObjectName(  
    [in]  PDEBUG_CLIENT  Client,  
    [in]  ULONG64        objAddr,  
    [out] __out_ecount(cbName) PSTR szName,  
    [out] ULONG          cbName  
);  
```  
  
#### Parameters  
 `Client`  
 [in] A pointer to the debug client.  
  
 `objAddr`  
 [in] A managed object pointer.  
  
 szName  
 [out] The name of the type.  
  
 `cbName`  
 [out] The number of characters available in the string buffer.  
  
## Remarks  
 If there is no managed code on the thread currently in context, the function returns HRESULT SOS_E_NOMANAGEDCODE with a facility value of 0xa0 and an error code of 0x1000.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** SOS_Stacktrace.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Global Static Functions](../../../../docs/framework/unmanaged-api/debugging/debugging-global-static-functions.md)
