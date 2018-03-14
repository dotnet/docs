---
title: "ICorDebugFunction Interface1"
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
  - "ICorDebugFunction"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunction"
helpviewer_keywords: 
  - "ICorDebugFunction interface [.NET Framework debugging]"
ms.assetid: 783faea9-8083-41c1-b04a-51a81ac4c8f3
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFunction Interface1
Represents a managed function or method.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateBreakpoint Method](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction-createbreakpoint-method.md)|Creates a breakpoint at the beginning of this function.|  
|[GetClass Method](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction-getclass-method.md)|Gets an ICorDebugClass object that represents the class this function is a member of.|  
|[GetCurrentVersionNumber Method](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction-getcurrentversionnumber-method.md)|Gets the version number of the latest edit made to this function.|  
|[GetILCode Method](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction-getilcode-method.md)|Gets the Microsoft intermediate language (MSIL) code for this function.|  
|[GetLocalVarSigToken Method](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction-getlocalvarsigtoken-method.md)|Gets the metadata token for the local variable signature of the function that is represented by this `ICorDebugFunction` instance.|  
|[GetModule Method](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction-getmodule-method.md)|Gets the module in which this function is defined.|  
|[GetNativeCode Method](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction-getnativecode-method.md)|Gets the native code for this function.|  
|[GetToken Method](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction-gettoken-method.md)|Gets the metadata token for this function.|  
  
## Remarks  
 The `ICorDebugFunction` interface does not represent a function with generic type parameters. For example, an `ICorDebugFunction` instance would represent `Func<T>` but not `Func<string>`. Call [ICorDebugILFrame2::EnumerateTypeParameters](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe2-enumeratetypeparameters-method.md) to get the generic type parameters.  
  
 The relationship between a method's metadata token, `mdMethodDef`, and a method's `ICorDebugFunction` object is dependent upon whether Edit and Continue is allowed on the function:  
  
-   If Edit and Continue is not allowed on the function, a one-to-one relationship exists between the `ICorDebugFunction` object and the `mdMethodDef` token. That is, the function has one `ICorDebugFunction` object and one `mdMethodDef` token.  
  
-   If Edit and Continue is allowed on the function, a many-to-one relationship exists between the `ICorDebugFunction` object and the `mdMethodDef` token. That is, the function may have many instances of `ICorDebugFunction`, one for each version of the function, but only one `mdMethodDef` token.  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:**  CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
