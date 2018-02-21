---
title: "ICorDebugVariableSymbol::SetValue Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 4609418d-71fa-44bc-9618-4d529d25cabb
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugVariableSymbol::SetValue Method
Assigns the value of a byte array to a variable.  
  
## Syntax  
  
```  
HRESULT SetValue(  
   [in] ULONG32 offset,  
   [in] DWORD threadID,  
   [in] ULONG32 cbContext,  
   [in, size_is(cbContext)] BYTE context[],  
   [in] ULONG32 cbValue,  
   [in, size_is(cbValue)] BYTE pValue[]  
);  
```  
  
#### Parameters  
 `offset`  
 [in] The starting offset in the variable at which to set the value. This parameter is used when writing to member fields in an object.  
  
 `threadID`  
 [in] The thread identifier of the thread whose context must be updated to reflect the new value.  
  
 `cbContext`  
 [in] The size in bytes of the thread context.  
  
 `context`  
 [in] The thread context used to write the value.  
  
 `cbValue`  
 [in] The size in bytes of the `pValue` buffer.  
  
 `pValue`  
 [in] The buffer that contains the value to set.  
  
## Remarks  
  
> [!NOTE]
>  This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See Also  
 [ICorDebugVariableSymbol Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvariablesymbol-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
