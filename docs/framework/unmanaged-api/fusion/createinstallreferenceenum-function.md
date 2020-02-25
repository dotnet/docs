---
title: "CreateInstallReferenceEnum Function"
ms.date: "03/30/2017"
api_name: 
  - "CreateInstallReferenceEnum"
api_location: 
  - "fusion.dll"
  - "clr.dll"
  - "mscorwks.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CreateInstallReference"
helpviewer_keywords: 
  - "CreateInstallReference function [.NET Framework fusion]"
ms.assetid: 80dbbbf8-54fc-4894-b74a-0179d3201083
topic_type: 
  - "apiref"
---
# CreateInstallReferenceEnum Function
Gets a pointer to an [IInstallReferenceEnum](iinstallreferenceenum-interface.md) instance that represents a list of an application's references to the specified assembly.  
  
## Syntax  
  
```cpp  
HRESULT CreateInstallReferenceEnum (  
    [out] IInstallReferenceEnum **ppRefEnum,  
    [in]  IAssemblyName         *pName,  
    [in]  DWORD                 dwFlags,  
    [in]  LPVOID                pvReserved  
 );  
```  
  
## Parameters  
 `ppRefEnum`  
 [out] The returned `IInstallReferenceEnum` pointer.  
  
 `pName`  
 [in] The [IAssemblyName](iassemblyname-interface.md) that identifies the assembly for which to enumerate references.  
  
 `dwFlags`  
 [in] Flags that influence the enumerator's behavior.  
  
 `pvReserved`  
 [in] Reserved for future extensibility. `pvReserved` must be a null reference.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Fusion.dll and Mscorwks.dll. Use Fusion.dll instead of Mscorwks.dll to ensure that you target the correct version of the .NET Framework.  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IInstallReferenceEnum Interface](iinstallreferenceenum-interface.md)
- [IAssemblyName Interface](iassemblyname-interface.md)
- [Fusion Global Static Functions](fusion-global-static-functions.md)
