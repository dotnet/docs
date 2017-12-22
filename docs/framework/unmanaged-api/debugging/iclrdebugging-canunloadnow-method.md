---
title: "ICLRDebugging::CanUnloadNow Method"
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
  - "ICLRDebugging.CanUnloadNow Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDebugging::CanUnloadNow"
helpviewer_keywords: 
  - "CanUnloadNow method [.NET Framework debugging]"
  - "ICLRDebugging::CanUnloadNow method [.NET Framework debugging]"
ms.assetid: 62e0630c-8cb7-45d2-b622-5a472abfd8cf
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDebugging::CanUnloadNow Method
Determines whether a library that was provided by an [ICLRDebuggingLibraryProvider](../../../../docs/framework/unmanaged-api/debugging/iclrdebugginglibraryprovider-interface.md) interface is still in use or can be unloaded.  
  
## Syntax  
  
```  
HRESULT CanUnloadNow(HMODULE hModule);  
```  
  
#### Parameters  
 `hmodule`  
 [in] The base address of a module in the target process.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The module that is referenced by `hmodule` can be unloaded.|  
|S_FALSE|The module that is referenced by `hmodule` is still in use.|  
|COR_E_NOT_CLR|The indicated module is not a CLR module.|  
  
## Exceptions  
  
## Remarks  
 This method checks to see if all instances of `ICorDebug*` interfaces have been released and no thread is currently within a call to the [ICLRDebugging::OpenVirtualProcess](../../../../docs/framework/unmanaged-api/debugging/iclrdebugging-openvirtualprocess-method.md) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
