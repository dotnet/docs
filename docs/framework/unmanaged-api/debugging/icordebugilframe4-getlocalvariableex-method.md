---
description: "Learn more about: ICorDebugILFrame4::GetLocalVariableEx Method"
title: "ICorDebugILFrame4::GetLocalVariableEx Method"
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorDebugILFrame4.GetCodeEx"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 0c8676f8-ca0d-4998-b64d-fefac7e38912
topic_type: 
  - "apiref"
---
# ICorDebugILFrame4::GetLocalVariableEx Method

[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Gets the value of the specified local variable in this intermediate language (IL) stack frame, and optionally accesses a variable added in profiler ReJIT instrumentation.  
  
## Syntax  
  
```cpp
HRESULT GetLocalVariableEx(  
   [in] ILCodeKind flags,
   [in] DWORD dwIndex,
   [out] ICorDebugValue **ppValue  
);  
```  
  
## Parameters  

 `flags`  
 [in] An [ILCodeKind](ilcodekind-enumeration.md) enumeration member that specifies whether a variable added in profiler ReJIT instrumentation is included in the frame.  
  
 `dwIndex`  
 [in] The index of the local variable in the IL stack frame.  
  
 `ppValue`  
 [out] A pointer to the address of an "ICorDebugValue" object that represents the retrieved value.  
  
## Remarks  

 This method is similar to the [GetLocalVariable](icordebugilframe-getlocalvariable-method.md) method, except that it optionally accesses a variable added in profiler ReJIT instrumentation. Calling this method with a `flags` value of `ILCODE_ORIGINAL_IL` is equivalent to calling [GetLocalVariable](icordebugilframe-getlocalvariable-method.md); if the method is instrumented with additional local variables, those variables cannot be accessed. `ILCODE_REJIT_IL` allows the debugger to access the local variables added in profiler ReJIT instrumentation. If the IL is not instrumented, the method returns `E_INVALIDARG`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See also

- [ICorDebugILFrame4 Interface](icordebugilframe4-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [ReJIT: A How-To Guide](/archive/blogs/davbr/rejit-a-how-to-guide)
