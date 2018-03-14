---
title: "ICLRDataTarget::GetCurrentThreadID Method"
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
  - "ICLRDataTarget.GetCurrentThreadID"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget::GetCurrentThreadID"
helpviewer_keywords: 
  - "GetCurrentThreadID method, ICLRDataTarget interface [.NET Framework debugging]"
  - "ICLRDataTarget::GetCurrentThreadID method [.NET Framework debugging]"
ms.assetid: dc9a0a6c-d592-4fb7-86ed-62684da3b0e1
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDataTarget::GetCurrentThreadID Method
Gets the operating system identifier for the current thread.  
  
## Syntax  
  
```  
HRESULT GetCurrentThreadID (  
    [out] ULONG32    *threadID  
);  
```  
  
#### Parameters  
 `threadID`  
 [out] A pointer to the operating system identifier of the current thread for the target process.  
  
## Remarks  
 If there is no current thread for the target process, the `GetCurrentThreadID` method may fail.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-interface.md)
