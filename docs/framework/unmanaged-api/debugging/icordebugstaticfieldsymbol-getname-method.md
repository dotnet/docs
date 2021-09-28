---
description: "Learn more about: ICorDebugStaticFieldSymbol::GetName Method"
title: "ICorDebugStaticFieldSymbol::GetName Method"
ms.date: "03/30/2017"
ms.assetid: e2be4af2-15d1-4e6a-8b68-1d78c93294a4
---
# ICorDebugStaticFieldSymbol::GetName Method

Gets the name of the static field.  
  
## Syntax  
  
```cpp  
HRESULT GetName(  
   [in] ULONG32 cchName,
   [out] ULONG32 *pcchName,
   [out, size_is(cchName), length_is(*pcchName)] WCHAR szName[]  
);  
```  
  
## Parameters  

 `cchName`  
 [in] The number of characters in the `szName` buffer.  
  
 `pcchName`  
 [out] A pointer to the number of characters actually written to the `szName` buffer.  
  
 `szName`  
 [out] A character array that stores the returned name.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugStaticFieldSymbol Interface](icordebugstaticfieldsymbol-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
