---
description: "Learn more about: ICorDebugVariableSymbol::GetValue Method"
title: "ICorDebugVariableSymbol::GetValue Method"
ms.date: "03/30/2017"
ms.assetid: 90abece1-392e-4ade-94a1-30c75b0f7074
---
# ICorDebugVariableSymbol::GetValue Method

Gets the value of a variable as a byte array.  
  
## Syntax  
  
```cpp  
HRESULT GetValue(  
   [in] ULONG32 offset,  
   [in] ULONG32 cbContext,  
   [in, size_is(cbContext)] BYTE context[],  
   [in] ULONG32 cbValue,  
   [out] ULONG32 *pcbValue,  
   [out, size_is(cbValue), length_is(*pcbValue)] BYTE pValue[]  
);  
```  
  
## Parameters  

 `offset`  
 [in] The starting offset in the variable from which to read the value. This parameter is used when reading member fields in an object.  
  
 `cbContext`  
 [in] The size in bytes of the `context` argument.  
  
 `context`  
 [in] The thread context used to read the value.  
  
 `cbValue`  
 [in] The size in bytes of the `pValue` buffer.  
  
 `pcbValue`  
 [out] The number of bytes actually written to the `pValue` buffer.  
  
 `pValue`  
 [out] A byte array that contains the value of the variable.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugVariableSymbol Interface](icordebugvariablesymbol-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
