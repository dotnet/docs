---
description: "Learn more about: ICorDebugInstanceFieldSymbol::GetOffset Method"
title: "ICorDebugInstanceFieldSymbol::GetOffset Method"
ms.date: "03/30/2017"
ms.assetid: 7e470150-2b92-4425-989c-315f48964fd2
---
# ICorDebugInstanceFieldSymbol::GetOffset Method

Gets the offset in bytes of this instance field in its parent class.  
  
## Syntax  
  
```cpp  
HRESULT GetOffset(  
   [out] ULONG32 *pcbOffset  
);  
```  
  
## Parameters  

 `pcbOffset`  
 A pointer to the number of bytes that this instance field is offset in its parent class.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugInstanceFieldSymbol Interface](icordebuginstancefieldsymbol-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
