---
title: "IInstallReferenceEnum::GetNextInstallReferenceItem Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IInstallReferenceEnum::GetNextInstallReferenceItem Method
Gets a pointer to the next [IInstallReferenceItem](../../../../docs/framework/unmanaged-api/fusion/iinstallreferenceitem-interface.md) object contained in this [IInstallReferenceEnum](../../../../docs/framework/unmanaged-api/fusion/iinstallreferenceenum-interface.md) object.  
  
## Syntax  
  
```  
HRESULT GetNextInstallReferenceItem (  
    [out] IInstallReferenceItem **ppRefItem,  
    [in]  DWORD dwFlags,  
    [in]  LPVOID pvReserved  
);  
```  
  
#### Parameters  
 `ppRefItem`  
 [out] The returned `IInstallReferenceItem` pointer.  
  
 `dwFlags`  
 [in] Reserved for future extensibility. `dwFlags` must be 0 (zero).  
  
 `pvReserved`  
 [in] Reserved for future extensibility. `pvReserved` must be a null reference.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IInstallReferenceItem Interface](../../../../docs/framework/unmanaged-api/fusion/iinstallreferenceitem-interface.md)  
 [IInstallReferenceEnum Interface](../../../../docs/framework/unmanaged-api/fusion/iinstallreferenceenum-interface.md)
