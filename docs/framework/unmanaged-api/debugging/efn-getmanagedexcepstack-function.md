---
title: "_EFN_GetManagedExcepStack Function"
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
  - "_EFN_GetManagedExcepStack"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "_EFN_GetManagedExcepStack"
helpviewer_keywords: 
  - "_EFN_GetManagedExcepStack function [.NET Framework debugging]"
ms.assetid: 21ceed9e-62b2-4024-b027-6d095109955a
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# _EFN_GetManagedExcepStack Function
Given a managed exception object address, returns a string version of the stack trace contained inside.  
  
## Syntax  
  
```  
HRESULT _EFN_GetManagedExcepStack(  
    [in]  PDEBUG_CLIENT Client,  
    [in]  ULONG64       StackObjAddr,  
    [out] __out_ecount(cbString) PSTR szStackString,  
    [out] ULONG         cbString  
);  
```  
  
#### Parameters  
 `Client`  
 [in] The client being debugged.  
  
 `StackObjAddr`  
 [in] A managed object pointer, derived from <xref:System.Exception>.  
  
 szStackString  
 [out] The returned string.  
  
 `cbString`  
 [out] The number of characters available in the string buffer.  
  
## Remarks  
 If there is no managed code on the thread currently in context, the function returns HRESULT SOS_E_NOMANAGEDCODE with a facility value of 0xa0 and an error code of 0x1000.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** SOS_Stacktrace.h  
  
 **.NET Framework Version:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Global Static Functions](../../../../docs/framework/unmanaged-api/debugging/debugging-global-static-functions.md)
