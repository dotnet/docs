---
description: "Learn more about: ICorDebugSymbolProvider2::GetFrameProps Method"
title: "ICorDebugSymbolProvider2::GetFrameProps Method"
ms.date: "03/30/2017"
ms.assetid: f07b73f3-188d-43a9-8f7d-44dce2f1ddb7
---
# ICorDebugSymbolProvider2::GetFrameProps Method

Returns the method starting relative virtual address of a method and the parent frame given a code relative virtual address.  
  
## Syntax  
  
```cpp  
HRESULT GetFrameProps(  
   [in] ULONG32 codeRva,  
   [out] ULONG32 *pCodeStartRva,  
   [out] ULONG32 *pParentFrameStartRva  
);  
```  
  
## Parameters  

 `codeRva`  
 [in] A code relative virtual address.  
  
 `pCodeStartRva`  
 [out] A pointer to the method's starting relative virtual address.  
  
 `pParentFrameStartRva`  
 [out] A pointer to the frame's starting relative virtual address.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugSymbolProvider2 Interface](icordebugsymbolprovider2-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
