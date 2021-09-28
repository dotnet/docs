---
description: "Learn more about: ICorDebugSymbolProvider::GetObjectSize Method"
title: "ICorDebugSymbolProvider::GetObjectSize Method"
ms.date: "03/30/2017"
ms.assetid: 3c564396-ac64-4ef3-b4f6-df96f1d46fc7
---
# ICorDebugSymbolProvider::GetObjectSize Method

Returns the object size for an object based on its typespec signature.  
  
## Syntax  
  
```cpp  
HRESULT GetObjectSize(  
   [in] ULONG32 cbSignature,  
   [in, size_is(cbSignature)]  BYTE typeSig[],  
   [out] ULONG32 *pObjectSize  
);  
```  
  
## Parameters  

 `cbSignature`  
 [in] The number of bytes in the typespec signature.  
  
 typeSig  
 [in] The typespec signature.  
  
 `pObjectSize`  
 [out] A pointer to the size of the object.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugSymbolProvider Interface](icordebugsymbolprovider-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
