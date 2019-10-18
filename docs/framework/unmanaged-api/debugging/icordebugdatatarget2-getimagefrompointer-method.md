---
title: "ICorDebugDataTarget2::GetImageFromPointer Method"
ms.date: "03/30/2017"
ms.assetid: 939cabe1-b647-4090-b662-eeec23c6c58d
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugDataTarget2::GetImageFromPointer Method
Returns the module base address and size from an address in that module.  
  
## Syntax  
  
```cpp  
HRESULT GetImageFromPointer(  
   [in] CORDB_ADDRESS addr,   
   [out] CORDB_ADDRESS *pImageBase,   
   [out] ULONG32 *pSize  
);  
```  
  
## Parameters  
 `addr`  
 A [CORDB_ADDRESS](../../../../docs/framework/unmanaged-api/common-data-types-unmanaged-api-reference.md) value that represents an address in a module.  
  
 `pImageBase`  
 [out] A [CORDB_ADDRESS](../../../../docs/framework/unmanaged-api/common-data-types-unmanaged-api-reference.md) value that represents the module's base address.  
  
 `pSize`  
 A pointer to the module size.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugDataTarget2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget2-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
