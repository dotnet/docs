---
description: "Learn more about: ICorDebugSymbolProvider::GetStaticFieldSymbols Method"
title: "ICorDebugSymbolProvider::GetStaticFieldSymbols Method"
ms.date: "03/30/2017"
ms.assetid: b178367f-a6e4-413c-b06f-daf3804b456b
---
# ICorDebugSymbolProvider::GetStaticFieldSymbols Method

Gets the static field symbols that correspond to a typespec signature.  
  
## Syntax  
  
```cpp  
HRESULT GetStaticFieldSymbols(  
   [in] ULONG32 cbSignature,  
   [in, size_is(cbSignature)]  BYTE typeSig[],  
   [in] ULONG32 cRequestedSymbols,  
   [out] ULONG32 *pcFetchedSymbols,  
   [out, size_is(cRequestedSymbols), length_is(*pcFetchedSymbols)] ICorDebugStaticFieldSymbol *pSymbols[]  
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
 [out] A pointer to an [ICorDebugStaticFieldSymbol](icordebugstaticfieldsymbol-interface.md) array that contains the requested static field symbols.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [GetInstanceFieldSymbols Method](icordebugsymbolprovider-getinstancefieldsymbols-method.md)
- [ICorDebugSymbolProvider Interface](icordebugsymbolprovider-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
