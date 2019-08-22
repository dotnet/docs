---
title: "ICorDebugVariableSymbol::GetSize Method"
ms.date: "03/30/2017"
ms.assetid: add0cd9d-9a29-49b1-ae07-d9d3786b4ccd
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugVariableSymbol::GetSize Method
Gets the size of a variable in bytes.  
  
## Syntax  
  
```cpp  
HRESULT GetSize(  
   [out] ULONG32 *pcbValue  
);  
```  
  
## Parameters  
 `pcbValue`  
 A pointer to a 32-bit unsigned integer containing the size of the variable.  
  
## Remarks  
  
> [!NOTE]
>  This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugVariableSymbol Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvariablesymbol-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
