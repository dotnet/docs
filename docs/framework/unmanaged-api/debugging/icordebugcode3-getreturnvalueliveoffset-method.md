---
title: "ICorDebugCode3::GetReturnValueLiveOffset Method"
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
  - "ICorDebugCode3.GetReturnValueLiveOffset"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCode3::GetReturnValueLiveOffset"
helpviewer_keywords: 
  - "ICorDebugCode3::GetReturnValueLiveOffset method [.NET Framework debugging]"
  - "GetReturnValueLiveOffset method [.NET Framework debugging]"
ms.assetid: 8c2ff5d8-8c04-4423-b1e1-e1c8764b36d3
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugCode3::GetReturnValueLiveOffset Method
For a specified IL offset, gets the native offsets where a breakpoint should be placed so that the debugger can obtain the return value from a function.  
  
## Syntax  
  
```cpp
HRESULT GetReturnValueLiveOffset(  
    [in] ULONG32 ILoffset,  
    [in] ULONG32 bufferSize,   
    [out] ULONG32 *pFetched,   
    [out, size_is(buffersize), length_is(*pFetched)] ULong32 pOffsets[]  
);  
```  
  
#### Parameters  
 `ILoffset`  
 The IL offset. It must be a function call site or the function call will fail.  
  
 `bufferSize`  
 The number of bytes available to store `pOffsets`.  
  
 `pFetched`  
 A pointer to the number of offsets actually returned. Usually, its value is 1, but a single IL instruction can map to multiple `CALL` assembly instructions.  
  
 `pOffsets`  
 An array of native offsets. Typically, `pOffsets` contains a single offset, although a single IL instruction can map to multiple map to multiple `CALL` assembly instructions.  
  
## Remarks  
 This method is used along with the [ICorDebugILFrame3::GetReturnValueForILOffset](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe3-getreturnvalueforiloffset-method.md) method to get the return value of a method that returns a reference type. Passing an IL offset to a function call site to this method returns one or more native offsets. The debugger can then set breakpoints on these native offsets in the function. When the debugger hits one of the breakpoints, you can then pass the same IL offset that you passed to this method to the [ICorDebugILFrame3::GetReturnValueForILOffset](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe3-getreturnvalueforiloffset-method.md) method to get the return value. The debugger should then clear all the breakpoints that it set.  
  
> [!WARNING]
>  The `ICorDebugCode3::GetReturnValueLiveOffset` and [ICorDebugILFrame3::GetReturnValueForILOffset](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe3-getreturnvalueforiloffset-method.md) methods allow you to get return value information for reference types only. Retrieving return value information from value types (that is, all types that derive from <xref:System.ValueType>) is not supported.  
  
 The function returns the `HRESULT` values shown in the following table.  
  
|`HRESULT` value|Description|  
|---------------------|-----------------|  
|`S_OK`|Success.|  
|`CORDBG_E_INVALID_OPCODE`|The given IL offset site is not a call instruction, or the function returns `void`.|  
|`CORDBG_E_UNSUPPORTED`|The given IL offset is a proper call, but the return type is unsupported for getting a return value.|  
  
 The `ICorDebugCode3::GetReturnValueLiveOffset` method is available only on x86-based and AMD64 systems.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v451plus](../../../../includes/net-current-v451plus-md.md)]  
  
## See Also  
 [GetReturnValueForILOffset Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe3-getreturnvalueforiloffset-method.md)  
 [ICorDebugCode3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugcode3-interface.md)
