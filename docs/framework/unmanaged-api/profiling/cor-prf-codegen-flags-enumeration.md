---
description: "Learn more about: COR_PRF_CODEGEN_FLAGS Enumeration"
title: "COR_PRF_CODEGEN_FLAGS Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "COR_PRF_CODEGEN_FLAGS"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_CODEGEN_FLAGS"
helpviewer_keywords: 
  - "COR_PRF_CODEGEN_FLAGS enumeration [.NET Framework profiling]"
ms.assetid: 3e184022-0247-4824-a23d-6b29593d8d01
topic_type: 
  - "apiref"
---
# COR_PRF_CODEGEN_FLAGS Enumeration

Defines the code generation flags that can be set with the [ICorProfilerFunctionControl::SetCodegenFlags](icorprofilerfunctioncontrol-setcodegenflags-method.md) method.  
  
## Syntax  
  
```cpp  
typedef enum {  
    COR_PRF_CODEGEN_DISABLE_INLINING =          0x0001,  
    COR_PRF_CODEGEN_DISABLE_ALL_OPTIMIZATIONS = 0x0002,  
} COR_PRF_CODEGEN_FLAGS;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_CODEGEN_DISABLE_INLINING`|No functions will be inlined into this function’s body. However, the function itself may be inlined into its callers.|  
|`COR_PRF_CODEGEN_DISABLE_ALL_OPTIMIZATIONS`|All optimizations will be disabled for this function’s body. However, the function itself may still be inlined into its callers.|  
  
## Remarks  

 The `COR_PRF_CODEGEN_FLAGS` enumeration is used by the [ICorProfilerFunctionControl::SetCodegenFlags](icorprofilerfunctioncontrol-setcodegenflags-method.md) method to enable the profiler to control the code generation for the JIT-recompiled function.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Profiling Enumerations](profiling-enumerations.md)
