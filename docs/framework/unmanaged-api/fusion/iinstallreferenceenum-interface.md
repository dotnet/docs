---
title: "IInstallReferenceEnum Interface"
ms.date: "03/30/2017"
api_name: 
  - "IInstallReferenceEnum"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IInstallReferenceEnum"
helpviewer_keywords: 
  - "IInstallReferenceEnum interface [.NET Framework fusion]"
ms.assetid: 2863b33b-a541-462c-bbe8-702a2832898e
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# IInstallReferenceEnum Interface
Represents an enumerator for the referenced assemblies installed in the global assembly cache.  
  
## Syntax  
  
```cpp  
interface IInstallReferenceEnum : IUnknown {  
    HRESULT GetNextInstallReferenceItem (  
        [out] IInstallReferenceItem **ppRefItem,  
        [in]  DWORD dwFlags,  
        [in]  LPVOID pvReserved  
    );  
};  
```  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetNextInstallReferenceItem Method](iinstallreferenceenum-getnextinstallreferenceitem-method.md)|Gets a pointer to the next `IInstallReferenceItem` contained in this `IInstallReferenceEnum`.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Fusion Interfaces](fusion-interfaces.md)
- [IInstallReferenceItem Interface](iinstallreferenceitem-interface.md)
