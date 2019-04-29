---
title: "ICorDebugMergedAssemblyRecord::GetCulture Method"
ms.date: "03/30/2017"
ms.assetid: 030b2f8c-8c21-40b7-855d-3afa78975a17
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugMergedAssemblyRecord::GetCulture Method
Gets the culture name string of the assembly.  
  
## Syntax  
  
```  
HRESULT GetCulture(  
   [in] ULONG32 cchCulture,   
   [out] ULONG32 *pcchCulture,   
   [out, size_is(cchCulture), length_is(*pcchCulture)] WCHAR szCulture[]  
);  
```  
  
## Parameters  
 `cchCulture`  
 [in] The number of characters in the `szCulture` buffer.  
  
 `pcchCulture`  
 [out] The number of characters actually written to the `szCulture` buffer.  
  
 `szCulture`  
 [out] A character array that contains the culture name.  
  
## Remarks  
 The culture name is a unique string that identifies a culture, such as "en-US" (for the English (United States) culture), or "neutral" (for a neutral culture).  
  
> [!NOTE]
>  This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugMergedAssemblyRecord Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmergedassemblyrecord-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
