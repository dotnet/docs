---
title: "CreateDebuggingInterfaceFromVersion Function for Silverlight"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
f1_keywords: 
  - "CreateDebuggingInterfaceFromVersion"
helpviewer_keywords: 
  - "CreateDebuggingInterfaceFromVersion function"
  - "debugging API [Silverlight]"
  - "Silverlight, debugging"
ms.assetid: 35c7a18f-133a-4584-bd25-bb338568b0c6
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CreateDebuggingInterfaceFromVersion Function for Silverlight
Accepts a common language runtime (CLR) version string that is returned from the [CreateVersionStringFromModule function](../../../../docs/framework/unmanaged-api/debugging/createversionstringfrommodule-function.md), and returns a corresponding debugger interface (typically, [ICorDebug](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)).  
  
## Syntax  
  
```  
HRESULT CreateDebuggingInterfaceFromVersion (  
    [in]  LPCWSTR      szDebuggeeVersion,  
    [out] IUnknown**   ppCordb,  
);  
```  
  
#### Parameters  
 `szDebuggeeVersion`  
 [in] Version string of the CLR in the target debuggee, which is returned by the [CreateVersionStringFromModule function](../../../../docs/framework/unmanaged-api/debugging/createversionstringfrommodule-function.md).  
  
 `ppCordb`  
 [out] Pointer to a pointer to a COM object (`IUnknown`). This object will be cast to an [ICorDebug](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md) object before it is returned.  
  
## Return Value  
 S_OK  
 `ppCordb` references a valid object that implements the [ICorDebug interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md) interface.  
  
 E_INVALIDARG  
 Either `szDebuggeeVersion` or `ppCordb` is null.  
  
 CORDBG_E_DEBUG_COMPONENT_MISSING  
 A component that is necessary for CLR debugging cannot be located. This means that either mscordbi.dll or mscordaccore.dll was not found in the same directory as the target CoreCLR.dll.  
  
 CORDBG_E_INCOMPATIBLE_PROTOCOL  
 Either mscordbi.dll or mscordaccore.dll is not the same version as the target CoreCLR.dll.  
  
 E_FAIL (or other E_ return codes)  
 Unable to return an [ICorDebug interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md).  
  
## Remarks  
 The interface that is returned provides the facilities for attaching to a CLR in a target process and debugging the managed code that the CLR is running.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** dbgshim.h  
  
 **Library:** dbgshim.dll  
  
 **.NET Framework Versions:** 3.5 SP1
