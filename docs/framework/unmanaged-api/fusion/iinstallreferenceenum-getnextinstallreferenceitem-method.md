---
description: "Learn more about: IInstallReferenceEnum::GetNextInstallReferenceItem Method"
title: "IInstallReferenceEnum::GetNextInstallReferenceItem Method"
ms.date: "03/30/2017"
api_name: 
  - "IInstallReferenceEnum.GetNextInstallReferenceItem"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IInstallReferenceEnum::GetNextInstallReferenceItem"
helpviewer_keywords: 
  - "IInstallReferenceEnum::GetNextInstallReferenceItem method [.NET Framework fusion]"
  - "GetNextInstallReferenceItem method [.NET Framework fusion]"
ms.assetid: ce969c9d-6538-4c34-8784-148ffd99fe7a
topic_type: 
  - "apiref"
---
# IInstallReferenceEnum::GetNextInstallReferenceItem Method

Gets a pointer to the next [IInstallReferenceItem](iinstallreferenceitem-interface.md) object contained in this [IInstallReferenceEnum](iinstallreferenceenum-interface.md) object.  
  
## Syntax  
  
```cpp  
HRESULT GetNextInstallReferenceItem (  
    [out] IInstallReferenceItem **ppRefItem,  
    [in]  DWORD dwFlags,  
    [in]  LPVOID pvReserved  
);  
```  
  
## Parameters  

 `ppRefItem`  
 [out] The returned `IInstallReferenceItem` pointer.  
  
 `dwFlags`  
 [in] Reserved for future extensibility. `dwFlags` must be 0 (zero).  
  
 `pvReserved`  
 [in] Reserved for future extensibility. `pvReserved` must be a null reference.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IInstallReferenceItem Interface](iinstallreferenceitem-interface.md)
- [IInstallReferenceEnum Interface](iinstallreferenceenum-interface.md)
