---
description: "Learn more about: ICorDebugSymbolProvider::GetCodeRange Method"
title: "ICorDebugSymbolProvider::GetCodeRange Method"
ms.date: "03/30/2017"
ms.assetid: 49a2451f-d250-4e73-aa96-9ff49d9f11c6
---
# ICorDebugSymbolProvider::GetCodeRange Method

Gets the method start address and size given a relative virtual address (RVA) in a method.  
  
## Syntax  
  
```cpp  
HRESULT GetCodeRange(  
   [in] ULONG32 codeRva,
   [out] ULONG32* pCodeStartAddress,
   [out] ULONG32* pCodeSize  
);  
```  
  
## Parameters  

 `codeRva`  
 [in] The relative virtual address (RVA) in a method.  
  
 `pCodeStartAddress`  
 [out] A pointer to the starting address of the method.  
  
 `pCodeSize`  
 A pointer to the method code size (the number of bytes of the method's code).  
  
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
