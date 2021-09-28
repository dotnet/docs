---
description: "Learn more about: ICorDebugSymbolProvider::GetMethodParameterSymbols Method"
title: "ICorDebugSymbolProvider::GetMethodParameterSymbols Method"
ms.date: "03/30/2017"
ms.assetid: 58b7c0b9-f6ad-4b49-b92d-0e421cfd0ec6
---
# ICorDebugSymbolProvider::GetMethodParameterSymbols Method

Gets a method's parameter symbols given the relative virtual address (RVA) of that method.  
  
## Syntax  
  
```cpp  
HRESULT GetMethodParameterSymbols(  
   [in] ULONG32 nativeRVA,  
   [in] ULONG32 cRequestedSymbols,  
   [out] ULONG32 *pcFetchedSymbols,  
   [out, size_is(cRequestedSymbols), length_is(*pcFetchedSymbols)] ICorDebugVariableSymbol *pSymbols[]  
);  
```  
  
## Parameters  

 `nativeRVA`  
 [in] The native relative virtual address of the method.  
  
 `cRequestedSymbols`  
 [in] The number of local symbols requested.  
  
 `pcFetchedSymbols`  
 [out] A pointer to the number of symbols retrieved by the method.  
  
 `pcFetchedSymbols`  
 [out] A pointer to an [ICorDebugVariableSymbol](icordebugvariablesymbol-interface.md) array that contains the method's local symbols.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [GetMethodLocalSymbols Method](icordebugsymbolprovider-getmethodlocalsymbols-method.md)
- [ICorDebugSymbolProvider Interface](icordebugsymbolprovider-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
