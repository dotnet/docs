---
title: "ICorDebugMergedAssemblyRecord::GetPublicKey Method"
ms.date: "03/30/2017"
ms.assetid: 6f4e78ba-082b-489d-8b58-4c35fbcc7a5b
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugMergedAssemblyRecord::GetPublicKey Method
Gets the assembly's public key.  
  
## Syntax  
  
```cpp  
HRESULT GetPublicKey(  
   [in] ULONG32 cbPublicKey,   
   [out] ULONG32 *pcbPublicKey,   
   [out, size_is(cbPublicKey), length_is(*pcbPublicKey)] BYTE pbPublicKey[]);  
```  
  
## Parameters  
 `cbPublicKey`  
 [in] The maximum number of bytes in the `pbPublicKey` array.  
  
 `pcbPublicKey`  
 [out] A pointer to the actual number of bytes written to the `pbPublicKey` array.  
  
 `pbPublicKey`  
 [out] A pointer to a byte array that contains the assembly's public key.  
  
## Remarks  
  
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
