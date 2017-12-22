---
title: "ICorDebugILFrame4::EnumerateLocalVariablesEx Method"
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
  - "ICorDebugILFrame4.EnumerateLocalVariablesEx"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 6f60aae6-70ec-4c4c-963a-138df98c4668
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILFrame4::EnumerateLocalVariablesEx Method
[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Gets an enumerator for the local variable in the frame, and optionally includes variables added in profiler ReJIT instrumentation.  
  
## Syntax  
  
```cpp
HRESULT EnumerateLocalVariablesEx(  
   [in] ILCodeKind flags,   
   [out] ICorDebugValueEnum **ppValueEnum  
);  
```  
  
#### Parameters  
 `flags`  
 [in] An [ILCodeKind](../../../../docs/framework/unmanaged-api/debugging/ilcodekind-enumeration.md) enumeration member that specifies whether variables added in profiler ReJIT instrumentation are included in the frame.  
  
 `ppValueEnum`  
 [out] A pointer to the address of an "ICorDebugValueEnum" object that is the enumerator for the local variables in this frame.  
  
## Remarks  
 This method is similar to the [EnumerateLocalVariables](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-enumeratelocalvariables-method.md) method, except that it optionally accesses variables added in profiler ReJIT instrumentation. Setting `flags` to `ILCODE_ORIGINAL_IL` is equivalent to calling [ICorDebugILFrame::EnumerateLocalVariables](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-enumeratelocalvariables-method.md). Setting `flags` to `ILCODE_REJIT_IL` allows the debugger to access the local variables added in profiler ReJIT instrumentation. If the intermediate language (IL) is not instrumented, the enumeration is empty and the method returns `S_OK`.  
  
 The enumerator may not include all of the local variables in the running method, since some of them may not be active.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See Also  
 [ICorDebugILFrame4 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe4-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [ReJIT: A How-To Guide](http://blogs.msdn.com/b/davbr/archive/2011/10/12/rejit-a-how-to-guide.aspx)
