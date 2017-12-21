---
title: "IMetaDataDispenserEx::FindAssemblyModule Method"
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
  - "IMetaDataDispenserEx.FindAssemblyModule"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataDispenserEx::FindAssemblyModule"
helpviewer_keywords: 
  - "FindAssemblyModule method [.NET Framework metadata]"
  - "IMetaDataDispenserEx::FindAssemblyModule method [.NET Framework metadata]"
ms.assetid: d1fb65e1-7e19-4513-85b1-44f87c294d3e
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataDispenserEx::FindAssemblyModule Method
This method is not implemented. If called, it returns E_NOTIMPL.  
  
## Syntax  
  
```  
HRESULT FindAssemblyModule(  
    [in]  LPCWSTR  szAppBase,  
    [in]  LPCWSTR  szPrivateBin,  
    [in]  LPCWSTR  szGlobalBin,  
    [in]  LPCWSTR  szAssemblyName,  
    [in]  LPCWSTR  szModuleName,  
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
 [in] The name of the module.  
  
 `szModuleName`  
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
