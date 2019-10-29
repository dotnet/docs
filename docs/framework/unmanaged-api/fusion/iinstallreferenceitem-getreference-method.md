---
title: "IInstallReferenceItem::GetReference Method"
ms.date: "03/30/2017"
api_name: 
  - "IInstallReferenceItem.GetReference"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IInstallReferenceItem::GetReference"
helpviewer_keywords: 
  - "IInstallReferenceItem::GetReference method [.NET Framework fusion]"
  - "GetReference method [.NET Framework fusion]"
ms.assetid: 8960332f-c98a-405a-ba92-7003de0c1187
topic_type: 
  - "apiref"
---
# IInstallReferenceItem::GetReference Method
Gets a pointer to the [FUSION_INSTALL_REFERENCE](fusion-install-reference-structure.md) structure represented by this [IInstallReferenceItem](iinstallreferenceitem-interface.md) object.  
  
## Syntax  
  
```cpp  
HRESULT GetReference (  
    [out] LPFUSION_INSTALL_REFERENCE *ppRefData,  
    [in]  DWORD dwFlags,  
    [in]  LPVOID pvReserved  
);  
```  
  
## Parameters  
 `ppRefData`  
 [out] The returned `FUSION_INSTALL_REFERENCE` pointer.  
  
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
- [FUSION_INSTALL_REFERENCE Structure](fusion-install-reference-structure.md)
