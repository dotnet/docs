---
description: "Learn more about: ICorDebugSymbolProvider::GetTypeProps Method"
title: "ICorDebugSymbolProvider::GetTypeProps Method"
ms.date: "03/30/2017"
ms.assetid: 35ac4140-91ea-4c77-b1c4-1daf41986ca5
---
# ICorDebugSymbolProvider::GetTypeProps Method

Returns information about a type's properties, such as the number of signature of its generic parameters, given a relative virtual address (RVA) in a vtable.  
  
## Syntax  
  
```cpp  
HRESULT GetTypeProps(  
   [in]  ULONG32 vtableRva,  
   [in]  ULONG32 cbSignature,  
   [out] ULONG32 *pcbSignature,  
   [out, size_is(cbSignature), length_is(*pcbSignature)] BYTE signature[]  
);  
```  
  
## Parameters  

 `tableRva`  
 [in] A relative virtual address (RVA) in a vtable.  
  
 `cbSignature`  
 [in] The size of the `signature` array. See the Remarks section.  
  
 `pcbSignature`  
 [out] [out] A pointer to the size of the returned `signature` array.  
  
 `signature`  
 [out] A buffer that holds the typespec signatures of all generic parameters.  
  
## Remarks  

 To get the required size of the type's `signature` array, set the `cbSignature` argument to 0 and `signature` to **null**. When the method returns, `pcbSignature` will contain the number of bytes required for the `signature` array.  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [GetMethodProps Method](icordebugsymbolprovider-getmethodprops-method.md)
- [ICorDebugSymbolProvider Interface](icordebugsymbolprovider-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
