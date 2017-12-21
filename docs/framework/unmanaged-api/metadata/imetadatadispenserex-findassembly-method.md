---
title: "IMetaDataDispenserEx::FindAssembly Method"
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
  - "IMetaDataDispenserEx.FindAssembly"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataDispenserEx::FindAssembly"
helpviewer_keywords: 
  - "FindAssembly method [.NET Framework metadata]"
  - "IMetaDataDispenserEx::FindAssembly method [.NET Framework metadata]"
ms.assetid: 3afe7252-5f28-48d9-a74d-1927566c404c
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataDispenserEx::FindAssembly Method
This method is not implemented. If called, it returns E_NOTIMPL.  
  
## Syntax  
  
```  
HRESULT FindAssembly(  
    [in]  LPCWSTR  szAppBase,  
    [in]  LPCWSTR  szPrivateBin,  
    [in]  LPCWSTR  szGlobalBin,  
    [in]  LPCWSTR  szAssemblyName,  
    [out] LPCWSTR  szName,  
    [in]  ULONG    cchName,  
    [out] ULONG    *pcName  
);  
```  
  
#### Parameters  
 `szAppBase`  
 [in] Not used.  
  
 `szPrivateBin`  
 [in] Not used.  
  
 `szGlobalBin`  
 [in] Not used.  
  
 `szAssemblyName`  
 [in] The assembly to be found.  
  
 `szName`  
 [out] The simple name of the assembly.  
  
 `cchName`  
 [in] The size, in bytes, of `szName`.  
  
 `pcName`  
 [out] The number of characters actually returned in `szName`.  
  
## Requirements  
 **Platform:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataDispenserEx Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenserex-interface.md)  
 [IMetaDataDispenser Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenser-interface.md)
