---
title: "PFN_CLRDataCreateInstance Function Pointer"
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
  - "PFN_CLRDataCreateInstance"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "PFN_CLRDataCreateInstance"
helpviewer_keywords: 
  - "PFN_CLRDataCreateInstance function pointer [.NET Framework debugging]"
ms.assetid: 5c66ac57-d751-4de5-af9f-26ceb949af8b
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# PFN_CLRDataCreateInstance Function Pointer
Points to a function that creates an interface object for the specified target item.  
  
## Syntax  
  
```  
typedef HRESULT (STDAPICALLTYPE* PFN_CLRDataCreateInstance) (  
    [in]  REFIID           iid,  
    [in]  ICLRDataTarget  *target,  
    [out] void           **iface  
);  
```  
  
#### Parameters  
 `iid`  
 [in] The identifier of the interface to be instantiated.  
  
 `target`  
 [in] A pointer to a user-implemented [ICLRDataTarget](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-interface.md) object that represents the target item for which to create the interface object.  
  
 `iface`  
 [out] A pointer to the address of the returned interface object.  
  
## Remarks  
 The `ICLRDataTarget` object is implemented by the writer of the debugging application. The implementation depends on the type of target item being represented. The target item may be a process, memory dump, remote machine, and so on.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Global Static Functions](../../../../docs/framework/unmanaged-api/debugging/debugging-global-static-functions.md)
