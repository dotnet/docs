---
description: "Learn more about: ICorDebugSymbolProvider::GetInstanceFieldSymbols Method"
title: "ICorDebugSymbolProvider::GetInstanceFieldSymbols Method"
ms.date: "03/30/2017"
ms.assetid: a29b9233-ee67-4b53-b8bc-c00b281e7edb
---
# ICorDebugSymbolProvider::GetInstanceFieldSymbols Method

Gets the instance field symbols that correspond to a typespec signature.  
  
## Syntax  
  
```cpp  
HRESULT GetInstanceFieldSymbols(  
   [in] ULONG32 cbSignature,  
   [in, size_is(cbSignature)]  BYTE typeSig[],  
   [in] ULONG32 cRequestedSymbols,  
   [out] ULONG32 *pcFetchedSymbols,  
   [out, size_is(cRequestedSymbols), length_is(*pcFetchedSymbols)] ICorDebugInstanceFieldSymbol *pSymbols[]  
);  
```  
  
## Parameters  

 `cbSignature`  
 [in] The number of bytes in the `typeSig` array.  
  
 `typeSig`  
 [in] A byte array that contains the `typespec` signature.  
  
 `cRequestedSymbols`  
 [in] The number of symbols requested.  
  
 `pcFetchedSymbols`  
 [out] A pointer to the number of symbols retrieved by the method.  
  
 `pSymbols`  
 [out] A pointer to an [ICorDebugStaticFieldSymbol](icordebugstaticfieldsymbol-interface.md) array that contains the requested instance field symbols.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [GetStaticFieldSymbols Method](icordebugsymbolprovider-getstaticfieldsymbols-method.md)
- [ICorDebugSymbolProvider Interface](icordebugsymbolprovider-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
