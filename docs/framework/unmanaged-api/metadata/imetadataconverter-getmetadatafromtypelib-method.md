---
title: "IMetaDataConverter::GetMetaDataFromTypeLib Method"
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
  - "IMetaDataConverter.GetMetaDataFromTypeLib"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataConverter::GetMetaDataFromTypeLib"
helpviewer_keywords: 
  - "IMetaDataConverter::GetMetaDataFromTypeLib method [.NET Framework metadata]"
  - "GetMetaDataFromTypeLib method [.NET Framework metadata]"
ms.assetid: 97dc3a56-adfa-431f-889e-06a35ac84d51
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataConverter::GetMetaDataFromTypeLib Method
Gets an interface pointer to an [IMetaDataImport](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md) instance that represents the metadata signature of the type library represented by the specified `ITypeLib` instance.  
  
## Syntax  
  
```  
HRESULT GetMetaDataFromTypeLib (  
    [in]  ITypeLib        *pITL,   
    [out] IMetaDataImport **ppMDI  
);  
```  
  
#### Parameters  
 `pITL`  
 [in] Pointer to an `ITypeLib` object that represents the type library.  
  
 `ppMDI`  
 [out] Pointer to a location that receives the address of the `IMetaDataImport` instance that represents the metadata signature.  
  
## Requirements  
 **Platform:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
