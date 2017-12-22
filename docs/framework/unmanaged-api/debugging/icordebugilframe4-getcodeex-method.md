---
title: "ICorDebugILFrame4::GetCodeEx Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorDebugILFrame4.GetLocalVariableEx"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: aeda0e42-29ee-4ca8-9f21-ac4641677a62
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILFrame4::GetCodeEx Method
[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Gets a pointer to the code that this stack frame is executing.  
  
## Syntax  
  
```cpp
HRESULT GetCodeEx(  
   [in] ILCodeKind flags,   
   [out] ICorDebugCode **ppCode  
);  
```  
  
#### Parameters  
 `flags`  
 [in] An [ILCodeKind](../../../../docs/framework/unmanaged-api/debugging/ilcodekind-enumeration.md) enumeration member that specifies whether the intermediate language (IL) defined by the profiler's ReJIT request is included in the frame.  
  
 `ppCode`  
 [out] A pointer to the address of an "ICorDebugCode" object that represents the code that this stack frame is executing.  
  
## Remarks  
 This method is similar to the [ICorDebugFrame::GetCode](../../../../docs/framework/unmanaged-api/debugging/icordebugframe-getcode-method.md) method, except that it optionally accesses code defined by the profiler's ReJIT request. Calling this method with a `flags` value of `ILCODE_ORIGINAL_IL` is equivalent to calling [GetCode](../../../../docs/framework/unmanaged-api/debugging/icordebugframe-getcode-method.md); if the method is instrumented, its IL will not be accessible. `ILCODE_REJIT_IL` allows the debugger to access the IL defined by the profiler's ReJIT request. If the IL is not instrumented, `ppCode` is **null**, and the method returns `S_OK`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See Also  
 [ICorDebugILFrame4 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe4-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [ReJIT: A How-To Guide](http://blogs.msdn.com/b/davbr/archive/2011/10/12/rejit-a-how-to-guide.aspx)
