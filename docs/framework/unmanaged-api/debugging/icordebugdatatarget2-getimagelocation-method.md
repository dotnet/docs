---
description: "Learn more about: ICorDebugDataTarget2::GetImageLocation Method"
title: "ICorDebugDataTarget2::GetImageLocation Method"
ms.date: "03/30/2017"
ms.assetid: 696afe71-5852-478d-a33f-b2d2dbc4b91f
---
# ICorDebugDataTarget2::GetImageLocation Method

Returns the path of a module from the module's base address.  
  
## Syntax  
  
```cpp  
HRESULT GetImageLocation(    [in] CORDB_ADDRESS baseAddress,  
    [in] ULONG32 cchName,  
    [out] ULONG32 *pcchName,  
    [out, size_is(cchName), length_is(*pcchName)] WCHAR szName[]  
);  
```  
  
## Parameters  

 `baseAddress`  
 [in] A [CORDB_ADDRESS](../common-data-types-unmanaged-api-reference.md) value that represents the module's base address.  
  
 `cchName`  
 [in] The number of characters in the buffer that is to receive the module path.  
  
 `pcchName`  
 [out] A pointer to the number of characters written to the `szName` buffer.  
  
 `szName`  
 [out] The path of the module.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugDataTarget2 Interface](icordebugdatatarget2-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
