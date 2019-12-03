---
title: "ICorDebugVariableSymbol::GetSlotIndex Method"
ms.date: "03/30/2017"
ms.assetid: 09c19f5f-afc4-4e0c-bffe-cd7147bc7a43
---
# ICorDebugVariableSymbol::GetSlotIndex Method
Gets the managed slot index of a local variable.  
  
## Syntax  
  
```cpp  
HRESULT GetSlotIndex(  
   [out] ULONG32 *pSlotIndex  
);  
```  
  
## Parameters  
 `pSlotIndex`  
 [out] A pointer to the local variable's slot index.  
  
## Return Value  
 `S_OK` if successful. `E_FAIL` if the variable is a function argument.  
  
## Remarks  
 The managed slot index of a local variable can be used to retrieve the variable's metadata information  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugVariableSymbol Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvariablesymbol-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
