---
title: "ICorDebugMergedAssemblyRecord::GetPublicKeyToken Method"
ms.date: "03/30/2017"
ms.assetid: 72020b72-9611-4bc3-b1e7-5a16b023bfa3
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugMergedAssemblyRecord::GetPublicKeyToken Method
Gets the assembly's public key token.  
  
## Syntax  
  
```cpp  
HRESULT GetPublicKeyToken(  
   [in] ULONG32 cbPublicKeyToken,   
   [out] ULONG32 *pcbPublicKeyToken,   
   [out, size_is(cbPublicKeyToken), length_is(*pcbPublicKeyToken)] BYTE pbPublicKeyToken[]  
);  
```  
  
## Parameters  
 `cbPublicKeyToken`  
 [in] The maximum number of bytes in the `pbPublicKeyToken` array.  
  
 `pcbPublicKeyToken`  
 [out] A pointer to the actual number of bytes written to the `pbPublicKeyToken` array.  
  
 `pbPublicKeyToken`  
 [out] A pointer to a byte array that contains the assembly's public key token.  
  
## Remarks  
 An assembly's public key token is the last eight bytes of a SHA1 hash of its public key.  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugMergedAssemblyRecord Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmergedassemblyrecord-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
