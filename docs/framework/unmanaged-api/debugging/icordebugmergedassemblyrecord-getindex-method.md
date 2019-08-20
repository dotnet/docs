---
title: "ICorDebugMergedAssemblyRecord::GetIndex Method"
ms.date: "03/30/2017"
ms.assetid: 98701444-b9bc-4978-9548-89ac3394147d
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugMergedAssemblyRecord::GetIndex Method
Gets the assembly's prefix index.  
  
## Syntax  
  
```cpp  
HRESULT GetIndex(  
   [out] ULONG32 *pIndex  
);  
```  
  
## Parameters  
 `pIndex`  
 [out] A pointer to the prefix index.  
  
## Remarks  
 The prefix index is used to prevent name collisions in the merged metadata type names.  
  
> [!NOTE]
>  This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugMergedAssemblyRecord Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmergedassemblyrecord-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
