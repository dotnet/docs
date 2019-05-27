---
title: "ICorDebugStaticFieldSymbol::GetAddress Method"
ms.date: "03/30/2017"
ms.assetid: 5a6c9a5a-ec72-4c40-a9c3-cee7baa63687
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugStaticFieldSymbol::GetAddress Method
Gets the address of a static field.  
  
## Syntax  
  
```  
HRESULT GetAddress(  
   [out] CORDB_ADDRESS *pRVA  
);  
```  
  
## Parameters  
 pRVA  
 [out] A pointer to the relative virtual address (RVA) of the static field.  
  
## Remarks  
  
> [!NOTE]
>  This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugStaticFieldSymbol Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugstaticfieldsymbol-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
