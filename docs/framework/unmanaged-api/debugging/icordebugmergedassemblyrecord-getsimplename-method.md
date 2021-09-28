---
description: "Learn more about: ICorDebugMergedAssemblyRecord::GetSimpleName Method"
title: "ICorDebugMergedAssemblyRecord::GetSimpleName Method"
ms.date: "03/30/2017"
ms.assetid: bc3410f6-ebca-4bca-9b45-fc38c74fa9cb
---
# ICorDebugMergedAssemblyRecord::GetSimpleName Method

Gets the simple name of the assembly.  
  
## Syntax  
  
```cpp  
HRESULT GetSimpleName(  
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
 A pointer to a character array.  
  
## Remarks  

 This method retrieves the simple name of an assembly (such as "System.Collections"), without a file extension, version, culture, or public key token. It corresponds to the <xref:System.Reflection.AssemblyName.Name%2A?displayProperty=nameWithType> property in managed code.  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugMergedAssemblyRecord Interface](icordebugmergedassemblyrecord-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
