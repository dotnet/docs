---
title: "ICorDebugILFrame3::GetReturnValueForILOffset Method"
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
  - "csharp"
  - "vb"
api_name: 
  - "ICorDebugILFrame3.GetReturnValueForILOffset"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 06522727-5f64-4391-9331-11386883c352
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILFrame3::GetReturnValueForILOffset Method
Gets an "ICorDebugValue" object that encapsulates the return value of a function.  
  
## Syntax  
  
```cpp
HRESULT GetReturnValueForILOffset(  
    ULONG32 ILoffset,   
    [out] ICorDebugValue **ppReturnValue  
);  
```  
  
#### Parameters  
 `ILOffset`  
 The IL offset. See the Remarks section.  
  
 `ppReturnValue`  
 A pointer to the address of an "ICorDebugValue" interface object that provides information about the return value of a function call.  
  
## Remarks  
 This method is used along with the [ICorDebugCode3::GetReturnValueLiveOffset](../../../../docs/framework/unmanaged-api/debugging/icordebugcode3-getreturnvalueliveoffset-method.md) method to get the return value of a method. It is particularly useful in the case of methods whose return values are ignored, as in the following two code examples. The first example calls the <xref:System.Int32.TryParse%2A?displayProperty=nameWithType> method, but ignores the method's return value.  
  
 [!code-csharp[Unmanaged.Debugging.MRV#1](../../../../samples/snippets/csharp/VS_Snippets_CLR/unmanaged.debugging.mrv/cs/mrv1.cs#1)]
 [!code-vb[Unmanaged.Debugging.MRV#1](../../../../samples/snippets/visualbasic/VS_Snippets_CLR/unmanaged.debugging.mrv/vb/mrv1.vb#1)]  
  
 The second example illustrates a much more common problem in debugging. Because a method is used as an argument in a method call, its return value is accessible only when the debugger steps through the called method. In many cases, particularly when the called method is defined in an external library, that is not possible.  
  
 [!code-csharp[Unmanaged.Debugging.MRV#2](../../../../samples/snippets/csharp/VS_Snippets_CLR/unmanaged.debugging.mrv/cs/mrv2.cs#2)]
 [!code-vb[Unmanaged.Debugging.MRV#2](../../../../samples/snippets/visualbasic/VS_Snippets_CLR/unmanaged.debugging.mrv/vb/mrv2.vb#2)]  
  
 If you pass the [ICorDebugCode3::GetReturnValueLiveOffset](../../../../docs/framework/unmanaged-api/debugging/icordebugcode3-getreturnvalueliveoffset-method.md) method an IL offset to a function call site, it returns one or more native offsets. The debugger can then set breakpoints on these native offsets in the function. When the debugger hits one of the breakpoints, you can then pass the same IL offset that you passed to this method to get the return value. The debugger should then clear all the breakpoints that it set.  
  
> [!WARNING]
>  The [ICorDebugCode3::GetReturnValueLiveOffset Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcode3-getreturnvalueliveoffset-method.md) and `ICorDebugILFrame3::GetReturnValueForILOffset` methods allow you to get return value information for reference types only. Retrieving return value information from value types (that is, all types that derive from <xref:System.ValueType>) is not supported.  
  
 The IL offset specified by the `ILOffset` parameter should be at a function call site, and the debuggee should be stopped at a breakpoint set at the native offset returned by the [ICorDebugCode3::GetReturnValueLiveOffset](../../../../docs/framework/unmanaged-api/debugging/icordebugcode3-getreturnvalueliveoffset-method.md) method for the same IL offset. If the debuggee is not stopped at the correct location for the specified IL offset, the API will fail.  
  
 If the function call doesn't return a value, the API will fail.  
  
 The `ICorDebugILFrame3::GetReturnValueForILOffset` method is available only on x86-based and AMD64 systems.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v451plus](../../../../includes/net-current-v451plus-md.md)]  
  
## See Also  
 [GetReturnValueLiveOffset Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcode3-getreturnvalueliveoffset-method.md)  
 [ICorDebugILFrame3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe3-interface.md)
