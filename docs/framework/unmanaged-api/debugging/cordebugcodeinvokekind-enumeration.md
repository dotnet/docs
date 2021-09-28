---
description: "Learn more about: CorDebugCodeInvokeKind Enumeration"
title: "CorDebugCodeInvokeKind Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorDebugCodeInvokeKind"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: e795e6a2-1008-4a81-af88-d777888e942e
topic_type: 
  - "apiref"
---
# CorDebugCodeInvokeKind Enumeration

Describes how an exported function invokes managed code.  
  
## Syntax  
  
```cpp  
typedef enum CorDebugCodeInvokeKind  
{  
    CODE_INVOKE_KIND_NONE,
    CODE_INVOKE_KIND_RETURN,
    CODE_INVOKE_KIND_TAILCALL,
} CorDebugCodeInvokeKind;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`CODE_INVOKE_KIND_NONE`|If any managed code is invoked by this method, it will have to be located by explicit events or breakpoints later.<br /><br /> --or--<br /><br /> We may just miss some of the managed code this method calls because there is no easy way to stop on it.<br /><br /> --or--<br /><br /> The method may never invoke managed code.|  
|`CODE_INVOKE_KIND_RETURN`|This method will invoke managed code via a return instruction. Stepping out should arrive at the next managed code.|  
|`CODE_INVOKE_KIND_TAILCALL`|This method will invoke managed code via a tail-call. Single-stepping and stepping over any call instructions should arrive at managed code.|  
  
## Remarks  

 This enumeration is used by the [ICorDebugProcess6::GetExportStepInfo](icordebugprocess6-getexportstepinfo-method.md) method to provide information about stepping through managed code.  
  
> [!NOTE]
> This enumeration is intended for use in .NET Native debugging scenarios only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [Debugging Enumerations](debugging-enumerations.md)
- [Debugging](index.md)
