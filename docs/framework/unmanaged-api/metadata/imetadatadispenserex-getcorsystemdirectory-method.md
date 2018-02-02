---
title: "IMetaDataDispenserEx::GetCORSystemDirectory Method"
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
  - "IMetaDataDispenserEx.GetCORSystemDirectory"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataDispenserEx::GetCORSystemDirectory"
helpviewer_keywords: 
  - "IMetaDataDispenserEx::GetCORSystemDirectory method [.NET Framework metadata]"
  - "GetCORSystemDirectory method [.NET Framework metadata]"
ms.assetid: d9e0f3b6-e106-4820-bada-5bfba34ce360
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataDispenserEx::GetCORSystemDirectory Method
Gets the directory that holds the current common language runtime (CLR). This method is supported only for use by out-of-process debuggers. If called from another component, it will return E_NOTIMPL.  
  
## Syntax  
  
```  
HRESULT GetCORSystemDirectory (  
    [out] LPWSTR      szBuffer,   
    [in]  DWORD       cchBuffer,   
    [out] DWORD*      pchBuffer  
);  
```  
  
#### Parameters  
 `szBuffer`  
 [out] The buffer to receive the directory name.  
  
 `cchBuffer`  
 [in] The size, in bytes, of `szBuffer`.  
  
 `pchBuffer`  
 [out] The number of bytes actually returned in `szBuffer`.  
  
## Requirements  
 **Platform:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataDispenserEx Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenserex-interface.md)  
 [IMetaDataDispenser Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenser-interface.md)
